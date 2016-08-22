using Umbraco.Core.Models;

namespace UmbBackofficeVisualizer.Models
{
    public class DataTypeDescripton
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PropertyEditorAlias { get; set; }
        public PreValueCollection PreValues { get; set; }
    }
}