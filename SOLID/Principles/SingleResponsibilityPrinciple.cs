using System;
using System.Net.Mail;

namespace SOLID.Principles
{
    public class SingleResponsibilityPrinciple
    {
        public class NewsletterServiceBad
        {
            /// <summary>
            /// This method is doing three things:
            /// 1) Validating the name 
            /// 2) Validating the email
            /// 3) Sending an email
            /// </summary>
            public void SendNewsletter(string email, string firstName, string lastName)
            {
                if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
                {
                    throw new Exception("Name is not valid.");
                }

                var emailAddress = new MailAddress(email);
                if (emailAddress.Address != email)
                {
                    throw new Exception("Email is not valid.");
                }

                var client = new SmtpClient();
                client.Send(new MailMessage("NewsletterService@SingleResponsibilityPrinciple.com", email) { Subject = "SOLID Principles!" });
            }
        }

        public class NewsletterServiceGood
        {
            private readonly NameService _nameService;
            private readonly EmailService _emailService;

            public NewsletterServiceGood(NameService nameService, EmailService emailService)
            {
                _nameService = nameService;
                _emailService = emailService;
            }

            public void SendNewsletter(string email, string firstName, string lastName)
            {
                _nameService.Validate(firstName, lastName);
                _emailService.Validate(email);

                var client = new SmtpClient();
                client.Send(new MailMessage("NewsletterService@SingleResponsibilityPrinciple.com", email) { Subject = "SOLID Principles!" });
            }
        }

        public class NameService
        {
            public void Validate(string firstName, string lastName)
            {
                if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
                {
                    throw new Exception("Name is not valid.");
                }
            }
        }

        public class EmailService
        {
            public void Validate(string email)
            {
                var emailAddress = new MailAddress(email);
                if (emailAddress.Address != email)
                {
                    throw new Exception("Email is not valid.");
                }
            }
        }
    }
}
