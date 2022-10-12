using Microsoft.AspNetCore.Identity;

namespace GeographyPortal.Areas.Identity.Data;

// Add profile data for application users by adding properties to the GeographyPortalUser class
public class GeographyPortalUser : IdentityUser
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }
}

