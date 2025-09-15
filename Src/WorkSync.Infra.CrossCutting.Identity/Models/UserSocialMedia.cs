using System.ComponentModel.DataAnnotations.Schema;

using WorkSync.Domain.Core.Models;

namespace WorkSync.Infra.CrossCutting.Identity.Models;

public class UserSocialMedia : EntityAudit
{
    public string UserId { get; private set; }

    public string Twitter { get; private set; }

    public string Facebook { get; private set; }

    public string Instagram { get; private set; }

    public string LinkedIn { get; private set; }

    [ForeignKey("UserId")]
    public ApplicationUser User { get; private set; }

    protected UserSocialMedia()
    {
    }
}
