using System.Collections.Generic;

namespace Umbraco.BackofficeDocumentor.Models
{
    public class BackofficeDocumentModel : Commentable
    {
        public IList<BackofficeDocumentGroupModel> Groups { get; set; }
        public List<DataTypeDescripton> DataTypes { get; set; }
    

        public BackofficeDocumentModel() : base()
        {
            Groups=new List<BackofficeDocumentGroupModel>();
        
        }

    }
}