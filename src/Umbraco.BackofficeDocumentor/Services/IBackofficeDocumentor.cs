using Umbraco.BackofficeDocumentor.Models;

namespace Umbraco.BackofficeDocumentor.Services
{
    public interface IBackofficeDocumentor
    {
        BackofficeDocumentModel CreateSnapshot();
    }
}