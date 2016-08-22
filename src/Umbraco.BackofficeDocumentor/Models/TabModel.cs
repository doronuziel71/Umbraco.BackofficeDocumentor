using System.Collections.Generic;

namespace Umbraco.BackofficeDocumentor.Models
{
    public class TabModel
    {
        public string Name { get; set; }
        public List<PropertyDescriptorModel> Properties { get; set; }
    }
}