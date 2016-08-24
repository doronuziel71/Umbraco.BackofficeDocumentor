using System.Collections.Generic;

namespace Umbraco.BackofficeDocumentor.Models
{
    public class BackofficeDocumentModel
    {
        public ContentHirarchy ContentTypes { get; set; }
        public IList<VisualizerContentTypeModel> Components { get; set; }
        public IList<BackofficeDocumentGroupModel> Groups { get; set; }
        public List<DataTypeDescripton> DataTypes { get; set; }

        public BackofficeDocumentModel()
        {
            Groups=new List<BackofficeDocumentGroupModel>();
        }
    }

    public class BackofficeDocumentGroupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<VisualizerContentTypeModel> ContentTypeDocs { get; set; }

        public BackofficeDocumentGroupModel()
        {
            ContentTypeDocs=new List<VisualizerContentTypeModel>();
        }
    }
}