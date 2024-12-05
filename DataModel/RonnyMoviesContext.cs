using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;


namespace DataModel;

public partial class RonnyMoviesContext : IdentityDbContext<AppUser>
{
    public RonnyMoviesContext()
    {
    }

    public RonnyMoviesContext(DbContextOptions<RonnyMoviesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<ProducerCompany> ProducerCompanies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) { return; }
        //starting w I means interface
        IConfigurationBuilder builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false);

        IConfigurationRoot configuration = builder.Build();

        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasOne(d => d.Company).WithMany(p => p.Movies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Movies_Producers");
        });

        modelBuilder.Entity<ProducerCompany>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Producers");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
