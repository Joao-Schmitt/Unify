using System.Threading.Tasks;

namespace Unify.Budgets.CrossCutting.Email
{
    public interface ISmtpEmailSender
    {
        Task SendAsync(string to, string subject, string body);
    }
}
