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

        public bool DocumentIsValid() 
        {
            switch (DocumentType)
            {
                case EDocumentType.CPF:
                    return ValidateCPF();
                case EDocumentType.CEDULA_IDENTIDAD:
                    return false;
                case EDocumentType.PASSPORT:
                    return false;
                case EDocumentType.CNPJ:
                    return ValidateCNPJ();
                default:
                    return false;
            }
        }

        //You need to refactor this code, to use english
        public bool ValidateCPF() 
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            this.ClientDocument = this.ClientDocument.Trim().Replace(".", "").Replace("-", "");
            if (this.ClientDocument.Length != 11)
                return false;

            for (int j = 0; j < 10; j++)
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == this.ClientDocument)
                    return false;

            string tempCpf = this.ClientDocument.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCpf += digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito += resto.ToString();

            return this.ClientDocument.EndsWith(digito);
        }

        public bool ValidateCNPJ() 
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            this.ClientDocument = this.ClientDocument.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
            if (this.ClientDocument.Length != 14)
                return false;

            string tempCnpj = this.ClientDocument.Substring(0, 12);
            int soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            int resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCnpj += digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito += resto.ToString();

            return this.ClientDocument.EndsWith(digito);
        }
    }
}
