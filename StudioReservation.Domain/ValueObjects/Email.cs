using System;
namespace StudioReservation.Domain.ValueObjects
{
    public class Email
    {

        public Email(string userEmail, string password, string confirmPassword)
        {
            this.UserEmail = userEmail;
            this.Password = password;
            this.ConfirmPassword = confirmPassword;
        }

        public string UserEmail { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
