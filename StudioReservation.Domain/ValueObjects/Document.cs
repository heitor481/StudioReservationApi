using System;
using StudioReservation.Domain.Enum;

namespace StudioReservation.Domain.ValueObjects
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
    }
}
