namespace Umbraco.BackofficeDocumentor.Models
{
    public class PropertyDescriptorModel
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public string EditorAlias { get; set; }
        public int DefinitionId { get; set; }
        public string Description { get; set; }
        public string DataTypeName { get; set; }
        public int DataTypeId { get; set; }
        public bool Required { get; set; }
        public string Regex { get; set; }
    }
}