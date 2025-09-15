using System.Threading.Tasks;

using WorkSync.Domain.Core.Commands;
using WorkSync.Domain.Core.Events;

namespace WorkSync.Domain.Core.Bus;

public interface IMediatorHandler
{
    Task SendCommand<T>(T command)
        where T : Command;

    Task RaiseEvent<T>(T @event)
        where T : Event;
}
