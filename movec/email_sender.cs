using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace movec
{
    class EmailSender
    {
        public String sendEmailVerification(String ToEmail)
        {
            Random random = new Random();
            Constants constants = new Constants();

            String verificationCode = random.Next(100000, 999999).ToString();

            MailMessage mailMessage = new MailMessage(constants.kSenderEmail, ToEmail);
            mailMessage.Subject = "Movec App";
            mailMessage.Body = "Thanks for verifying your Movec account\nYour Verification Code - " + verificationCode + "\n\nDeveloped By Nihad Allahveranov\nLinkedIn - https://www.linkedin.com/in/nihadallahveranov/ \nGitHub - https://github.com/nihadallahveranov/movec";
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.UseDefaultCredentials = false;

            NetworkCredential networkCredential = new NetworkCredential(constants.kSenderEmail, HideInformation.kSenderPassword);
            smtpClient.Credentials = networkCredential;
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);

            return verificationCode;
        }
    }
}
