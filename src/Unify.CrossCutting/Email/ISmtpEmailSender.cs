using System.Threading.Tasks;

namespace Unify.CrossCutting.Email
{
    public interface ISmtpEmailSender
    {
        Task SendAsync(string to, string subject, string body);
    }
}
