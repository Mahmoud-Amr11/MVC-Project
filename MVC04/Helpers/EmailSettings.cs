using System.Net;
using System.Net.Mail;
using System.Security;

namespace MVC04.Helpers
{
    public static class EmailSettings
    {


        public static void SendEmail(Email email)
        {
            var client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("ma7moudzx123@gmail.com", "lxbzrbjdbzthkkiv" );
            client.Send("ma7moudzx123@gmail.com" , email.To, email.Subject, email.Body);
        }
    }
}
