using System.Collections.Generic;

namespace Umbraco.BackofficeDocumentor.Models
{
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