using System.Collections.Generic;
using Umbraco.Core.Models;

namespace Umbraco.BackofficeDocumentor.Models
{
    public class DataTypeDescripton : Commentable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PropertyEditorAlias { get; set; }
        public IDictionary<string, PreValueModel> PreValues { get; set; }


        public DataTypeDescripton() :base()
        {
            PreValues = new Dictionary<string, PreValueModel>();
        }

    }
}