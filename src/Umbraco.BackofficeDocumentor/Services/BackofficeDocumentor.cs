using System.Collections.Generic;
using System.Linq;
using Umbraco.BackofficeDocumentor.Models;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Services;

namespace Umbraco.BackofficeDocumentor.Services
{
    public class BackofficeDocumentor : IBackofficeDocumentor
    {
        private ServiceContext _services;
        private List<IDataTypeDefinition> _dataTypes;
        private List<IDataTypeDefinition> _usedDataTypes;

        public BackofficeDocumentor()
        {
            this._services = ApplicationContext.Current.Services;
            this._dataTypes = _services.DataTypeService.GetAllDataTypeDefinitions().ToList();
            _usedDataTypes=new List<IDataTypeDefinition>();
        }

        public BackofficeDocumentModel CreateSnapshot()
        {

            var model = new BackofficeDocumentModel();
            var allCt = _services.ContentTypeService.GetAllContentTypes().ToList();
            var contentTypes =allCt.Where(x=>!x.IsContainer).Select(ToModel).ToList();


            var allContainerIds =
                contentTypes.Where(x => contentTypes.All(y => y.Id != x.ParentId))
                    .Select(x => x.ParentId)
                    .Distinct()
                    .ToArray();

            var allContainers = _services.ContentTypeService.GetContentTypeContainers(allContainerIds);

            var components = contentTypes.Where(cmp => contentTypes.Any(ct => ct.ImplementsIds.Contains(cmp.Id))).ToList();

            model.Components = components;

            foreach (var container in allContainers)
            {
                var group = new BackofficeDocumentGroupModel
                {
                    Id = container.Id,
                    Name = container.Name,
                    ContentTypeDocs = contentTypes.Where(ct => IsDescendantOf(container.Id, ct, contentTypes)).ToList()
                };
                model.Groups.Add(group);
            }

            //model.ContentDocTypes = contentTypes.Where(ct => components.All(cmp => cmp.Id != ct.Id)).ToList();

            //model.ContentDocTypes.ForEach(
            //    cdt =>
            //    {
            //        cdt.Implements = contentTypes.Where(ct => cdt.ImplementsIds.Contains(ct.Id)).ToList();
            //        cdt.Inherits = contentTypes.SingleOrDefault(ct => ct.Id == cdt.InheritsId);
            //    });



            model.DataTypes = CreateDataTypesDescriptor(_usedDataTypes);

            return model;
        }

        private bool IsDescendantOf(int id, VisualizerContentTypeModel ct, List<VisualizerContentTypeModel> contentTypes)
        {
            if (ct == null)
                return false;
            if (ct.ParentId == id)
                return true;

            var parent = contentTypes.FirstOrDefault(x => x.Id == ct.ParentId);
            return IsDescendantOf(id, parent, contentTypes);


        }

        private List<DataTypeDescripton> CreateDataTypesDescriptor(IEnumerable<IDataTypeDefinition> usedDataTypes)
        {
            return usedDataTypes.Where(x => x.Id > 0).Select(dt => new DataTypeDescripton
            {
                Id = dt.Id, Name = dt.Name, PropertyEditorAlias = dt.PropertyEditorAlias, PreValues = _services.DataTypeService.GetPreValuesCollectionByDataTypeId(dt.Id)
            }).ToList();
        }

        private VisualizerContentTypeModel ToModel(IContentType contentType)
        {
           
                return new VisualizerContentTypeModel
                {
                    Name = contentType.Name,
                    ParentId=contentType.ParentId,
                    Alias = contentType.Alias,
                    Id = contentType.Id,
                    Description = contentType.Description,
                    Icon = contentType.Icon,
                    InheritsId = contentType.ParentId,
                    ImplementsIds = contentType.CompositionIds(),
                    Properties= CreateDocTypePropertiesModel(contentType)

                };
        }

        private DocTypePropertiesModel CreateDocTypePropertiesModel(IContentType contentType)
        {
            var model = new DocTypePropertiesModel();

            model.Tabs = contentType.PropertyGroups.Select(x => new TabModel
            {
                Name = x.Name,
                Properties = x.PropertyTypes.Select(DescribePropertyType).ToList()
            }).ToList();

            return model;

        }

        private  PropertyDescriptorModel DescribePropertyType(PropertyType pt)
        {
         
   

            var rv= new PropertyDescriptorModel
            {
                Name=pt.Name,
                Alias=pt.Alias,
                EditorAlias=pt.PropertyEditorAlias,
                DefinitionId=pt.DataTypeDefinitionId,
                Description=pt.Description,
                Required=pt.Mandatory,
                Regex=pt.ValidationRegExp
                  


            };
            var dataType = _dataTypes.FirstOrDefault(x => x.Id == pt.DataTypeDefinitionId);
            if (dataType != null)
            {
                rv.DataTypeName = dataType.Name;
                rv.DataTypeId = dataType.Id;
                if (!_usedDataTypes.Contains(dataType))
                {
                    _usedDataTypes.Add(dataType);
                }
               

            }
            return rv;
        }
    }
}