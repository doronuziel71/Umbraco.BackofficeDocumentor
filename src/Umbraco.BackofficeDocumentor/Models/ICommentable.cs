using System.Collections.Generic;

namespace Umbraco.BackofficeDocumentor.Models
{
    public interface ICommentable
    {
        List<string> Comments { get; set; }

    }
}