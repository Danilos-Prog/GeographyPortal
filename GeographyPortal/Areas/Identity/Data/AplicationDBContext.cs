using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeographyPortal.Areas.Identity.Data;

public class AplicationDBContext : IdentityDbContext<GeographyPortalUser>
{
    public AplicationDBContext(DbContextOptions<AplicationDBContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }
}


public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<GeographyPortalUser>
{
    public void Configure(EntityTypeBuilder<GeographyPortalUser> builder)
    {
        builder.Property(o => o.FirstName).HasMaxLength(255);
        builder.Property(o => o.LastName).HasMaxLength(255);

    }
}