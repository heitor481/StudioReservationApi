using System;
using StudioReservation.Domain.Enum;

namespace StudioReservation.Domain.ValueObjects
{
    public class Document
    {
        public Document()
        {
        }

        public string ClientDocument { get; set; }

        public EDocumentType DocumentType { get; set; }
    }
}
