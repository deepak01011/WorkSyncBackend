using System.Threading.Tasks;

namespace WorkSync.Domain.Providers.Webhooks;

public interface IWebhookProvider
{
    Task Send(string message);
}
