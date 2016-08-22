using System.Collections.Generic;

namespace Umbraco.BackofficeDocumentor.Models
{
    public class BackofficeDocumentModel
    {
        public ContentHirarchy ContentTypes { get; set; }
        public IList<VisualizerContentTypeModel> Components { get; set; }
        public IList<VisualizerContentTypeModel> ContentDocTypes { get; set; }
        public List<DataTypeDescripton> DataTypes { get; set; }
    }
}