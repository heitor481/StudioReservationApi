using StudioReservation.NewDomain.Enum;

namespace StudioReservation.NewDomain.ValueObjects
{
    public class Document
    {

        public Document(string clientDocument, EDocumentType documentType)
        {
            this.ClientDocument = clientDocument;
            this.DocumentType = documentType;
        }

        public string ClientDocument { get; set; }

        public EDocumentType DocumentType { get; set; }

        public bool IsDocumentValid { get; set; }
    }
}
