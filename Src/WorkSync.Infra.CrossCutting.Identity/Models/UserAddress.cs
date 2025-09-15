using System.ComponentModel.DataAnnotations.Schema;

using WorkSync.Domain.Core.Models;

namespace WorkSync.Infra.CrossCutting.Identity.Models;

public class UserAddress : EntityAudit
{
    public string UserId { get; private set; }

    public string Street { get; private set; }

    public string City { get; private set; }

    public string State { get; private set; }

    public string ZipCode { get; private set; }

    public string Country { get; private set; }

    [ForeignKey("UserId")]
    public ApplicationUser User { get; private set; }

    protected UserAddress()
    {
    }
}
