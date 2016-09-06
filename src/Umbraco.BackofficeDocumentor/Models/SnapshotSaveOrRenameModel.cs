namespace Umbraco.BackofficeDocumentor.Models
{
    public class SnapshotSaveOrRenameModel
    {
        public string OldName { get; set; }
        public string NewName { get; set; }
        public BackofficeDocumentModel Snapshot { get; set; }
    }
}