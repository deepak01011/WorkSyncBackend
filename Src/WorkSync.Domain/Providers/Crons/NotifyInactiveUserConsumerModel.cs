using System.Collections.Generic;

namespace WorkSync.Domain.Providers.Crons;

public class NotifyInactiveUserConsumerModel
{
    public List<object> Data { get; set; }

    public int UserId { get; set; }

    public short TenantId { get; set; }
}
