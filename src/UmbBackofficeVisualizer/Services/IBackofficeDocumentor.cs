using UmbBackofficeVisualizer.Models;

namespace UmbBackofficeVisualizer.Services
{
    public interface IBackofficeDocumentor
    {
        BackofficeDocumentModel CreateSnapshot();
    }
}