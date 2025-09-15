using Microsoft.AspNetCore.Identity;

namespace WorkSync.Infra.CrossCutting.Identity.Models;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string Phone { get; private set; }

    public string ProfileUrl { get; private set; }

    public UserAddress Address { get; private set; }

    public UserSocialMedia SocialMedia { get; private set; }

    protected ApplicationUser()
    {
    }

    public static ApplicationUser Create(string userName, string email, string firstName = null, string lastName = null, string phone = null, string profileUrl = null)
    {
        return new ApplicationUser
        {
            UserName = userName,
            Email = email,
            FirstName = firstName,
            LastName = lastName,
            Phone = phone,
            ProfileUrl = profileUrl,
            SecurityStamp = Guid.NewGuid().ToString(),
        };
    }
}
