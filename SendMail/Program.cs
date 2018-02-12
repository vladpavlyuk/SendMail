using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace SendMail
{
    class Program
    {
        static string login = "";
        static string password = "";
        static string toUser = "";
        static string subject = "";
        static string body = "";
        static string name = "";
        static int trigger;

        static SmtpClient clientSmtp;
        static MailMessage mail;

        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("Send Email using SMTP!");
                Console.Write("Enter a login: ");
                login = Console.ReadLine();
                Console.Write("Enter a password: ");
                password = Console.ReadLine();
                Console.Write("Your name: ");
                name = Console.ReadLine();
                Console.Write("Email to: ");
                toUser = Console.ReadLine();
                Console.Write("Subject: ");
                subject = Console.ReadLine();
                Console.Write("Body: ");
                body = Console.ReadLine();

                clientSmtp = new SmtpClient("smtp.gmail.com");
                clientSmtp.Credentials = new System.Net.NetworkCredential(login, password);
                clientSmtp.Port = 587;
                clientSmtp.EnableSsl = true;

                mail = new MailMessage()
                {
                    From = new MailAddress(login, name),
                    Subject = subject,
                    Body = body
                };

                mail.To.Add(toUser);
                clientSmtp.Send(mail);
                Console.WriteLine("Email has been sent!");
                Console.WriteLine("Do you want continue? [1] Yes   [2] No");
                trigger = Convert.ToInt32(Console.ReadLine());

                if (trigger == 2 || trigger == 0)
                    break;
            }
        }
    }
}
