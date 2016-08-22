using System.Collections.Generic;
using System.Linq;

namespace Umbraco.BackofficeDocumentor.Models
{
    public class VisualizerContentTypeModel
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public int InheritsId { get; set; }
        public IEnumerable<int> ImplementsIds { get; set; }
        public List<VisualizerContentTypeModel> Implements { get; set; }
        public VisualizerContentTypeModel Inherits { get; set; }
        public DocTypePropertiesModel Properties { get; set; }

        public VisualizerContentTypeModel()
        {
            Implements=new List<VisualizerContentTypeModel>();
            ImplementsIds=Enumerable.Empty<int>();
        }
    }
}