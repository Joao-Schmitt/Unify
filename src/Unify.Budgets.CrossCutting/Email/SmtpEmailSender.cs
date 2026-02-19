using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Unify.Budgets.CrossCutting.Email
{
    public class SmtpEmailSender : ISmtpEmailSender
    {
        private readonly EmailSettings _cfg;
        public SmtpEmailSender(EmailSettings cfg)
        {
            _cfg = cfg;
        }

        public async Task SendAsync(string to, string subject,string body)
        {
            using (var client = new SmtpClient(_cfg.Host, _cfg.Port))
            {
                client.Credentials = new NetworkCredential(_cfg.User, _cfg.Password);

                client.EnableSsl = _cfg.Ssl;

                using (var mail = new MailMessage(_cfg.From, to, subject, body))
                {
                    await client.SendMailAsync(mail);
                }
            }
        }
    }
}
