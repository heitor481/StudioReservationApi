using System;
using Flunt.Notifications;
using Flunt.Validations;

namespace StudioReservation.Domain.ValueObjects
{
    public class Email : Notifiable
    {

        public Email(string userEmail, string password, string confirmPassword)
        {
            this.UserEmail = userEmail;
            this.Password = password;
            this.ConfirmPassword = confirmPassword;

            AddNotifications(new Contract()
                    .IsNullOrEmpty(userEmail, "User Email", "Please insert your email")
                    .IsNullOrEmpty(password, "Password", "Please insert your password")
                    .AreNotEquals(password, confirmPassword, "Password", "The password typed doesnt match")
                );
        }

        public string UserEmail { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
