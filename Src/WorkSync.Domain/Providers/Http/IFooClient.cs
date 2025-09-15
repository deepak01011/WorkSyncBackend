using System.Threading.Tasks;

using Refit;

namespace WorkSync.Domain.Providers.Http;

public interface IFooClient
{
    [Get("/")]
    Task<object> GetAll();
}
