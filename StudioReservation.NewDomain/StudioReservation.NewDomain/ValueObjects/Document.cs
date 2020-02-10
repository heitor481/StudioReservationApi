using System;
using Flunt.Notifications;
using Flunt.Validations;
using StudioReservation.NewDomain.Enum;

namespace StudioReservation.NewDomain.ValueObjects
{
    public class Document : Notifiable
    {
        public Document(string clientDocument, EDocumentType documentType)
        {
            this.ClientDocument = clientDocument;
            this.DocumentType = documentType;

            AddNotifications(new Contract()
                    .IsNotNullOrEmpty(clientDocument, "Client document", "Your identification cannot be null")
                );
        }

        public string ClientDocument { get; set; }

        public EDocumentType DocumentType { get; set; }

        public bool IsDocumentValid { get; set; }
    }
}
