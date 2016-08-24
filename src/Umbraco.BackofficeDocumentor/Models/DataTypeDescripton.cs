using System.Collections.Generic;
using Umbraco.Core.Models;

namespace Umbraco.BackofficeDocumentor.Models
{
    public class DataTypeDescripton
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PropertyEditorAlias { get; set; }
        public IDictionary<string, PreValue> PreValues { get; set; }
    }
}