using System;

using WorkSync.Domain.Core.Events;

namespace WorkSync.Domain.Events;

public class CustomerRemovedEvent : Event
{
    public CustomerRemovedEvent(Guid id)
    {
        Id = id;
        AggregateId = id;
    }

    public Guid Id { get; set; }
}
