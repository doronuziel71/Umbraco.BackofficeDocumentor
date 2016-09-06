using System.Collections.Generic;
using umbraco.cms.businesslogic;

namespace Umbraco.BackofficeDocumentor.Models
{
    public class DocTypePropertiesModel : Commentable
    {
        public IEnumerable<TabModel> Tabs { get; set; }


        public DocTypePropertiesModel() : base()
        {
            Tabs = new List<TabModel>();
        }
    }
}