using Microsoft.EntityFrameworkCore;
using NewsHub.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace NewsHub.Infrastructure.Data;

public partial class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Secret> Secrets { get; set; }
    
    public virtual DbSet<Source> Sources { get; set; }

    public virtual DbSet<SourceItem> SourceItems { get; set; }

   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Source>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                .HasMaxLength(200);

            entity.Property(e => e.Url)
                .HasMaxLength(500);
        });

        modelBuilder.Entity<SourceItem>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime");

            entity.Property(e => e.Json)
                .HasColumnType("nvarchar(max)");
        });

        modelBuilder.Entity<Secret>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Key)
                .HasMaxLength(100);

            entity.Property(e => e.Value)
                .HasMaxLength(500);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}