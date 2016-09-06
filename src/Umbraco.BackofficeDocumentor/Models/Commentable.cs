using System.Collections.Generic;

namespace Umbraco.BackofficeDocumentor.Models
{
    public abstract class Commentable : ICommentable
    {
        public List<string> Comments { get; set; }

        protected Commentable()
        {
            Comments=new List<string>();
        }
    }
}