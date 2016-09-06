using System.Collections.Generic;
using Umbraco.BackofficeDocumentor.Models;

namespace Umbraco.BackofficeDocumentor.Services
{
    public interface ISnapshotService
    {
        IEnumerable<string> List();
        BackofficeDocumentModel Get(string file);
        string Save(string newNampe, string OldName, BackofficeDocumentModel model);
        string New();
        void Delete(string file);
    }
}