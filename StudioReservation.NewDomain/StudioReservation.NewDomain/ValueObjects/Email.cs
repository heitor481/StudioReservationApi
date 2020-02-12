using System;
using Flunt.Notifications;
using Flunt.Validations;

namespace StudioReservation.NewDomain.ValueObjects
{
    public class Email
    {
        public Email()
        {

        }

        public Email(string userEmail, string password, string confirmPassword)
        {
            this.UserEmail = userEmail;
            this.Password = password;
            this.ConfirmPassword = confirmPassword;
        }

        public string UserEmail { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        //public void Validate()
        //{
        //    AddNotifications(new Contract()
        //            .IsNullOrEmpty(this.UserEmail, "User Email", "Please insert your email")
        //            .IsNullOrEmpty(this.Password, "Password", "Please insert your password")
        //            .IsEmail(this.UserEmail, "UserEmail", "This is not a valid Email, please try with a valid one")
        //        );
        //}
    }
}
