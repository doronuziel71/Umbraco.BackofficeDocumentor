using System.Collections.Generic;

namespace Umbraco.BackofficeDocumentor.Models
{
    public class TabModel : Commentable
    {
        public string Name { get; set; }
        public List<PropertyDescriptorModel> Properties { get; set; }

        public TabModel() : base()
        {
            Properties=new List<PropertyDescriptorModel>();
        }
    }
}