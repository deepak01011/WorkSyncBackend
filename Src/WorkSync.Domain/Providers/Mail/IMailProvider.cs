using System.Threading.Tasks;

namespace WorkSync.Domain.Providers.Mail;

public interface IMailProvider
{
    Task Send(MailMessage message);
}
