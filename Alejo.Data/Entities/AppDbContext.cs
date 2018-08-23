using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alejo.Data.Entities
{
     public class AppDbContext : IdentityDbContext<AppUser>
     {
          public AppDbContext()
          {

          }

          public AppDbContext(DbContextOptions options) : base(options)
          {

          }

          public static AppDbContext Create()
          {
               return new AppDbContext();
          }

          public virtual DbSet<AppUser> AppUsers { get; set; }
          public virtual DbSet<Schedule> Schedules { get; set; }

          protected override void OnModelCreating(ModelBuilder builder)
          {
               // Single Property Configuration
               builder.Entity<AppUser>().HasKey(e => e.Id);
               builder.Entity<IdentityUserLogin<string>>().HasKey(e => e.UserId);
               builder.Entity<IdentityUserRole<string>>().HasKey(e => new { e.RoleId, e.UserId });
               builder.Entity<IdentityRole<string>>().HasKey(e => e.Id);
               builder.Entity<IdentityRoleClaim<string>>().HasKey(e => e.Id);
               builder.Entity<IdentityUserClaim<string>>().HasKey(e => e.Id);
               builder.Entity<IdentityUserToken<string>>().HasKey(e => e.UserId);

               // ToTable Property Configuration
               builder.Entity<IdentityUserLogin<string>>().ToTable("AspNetUserLogin");
               builder.Entity<IdentityUserRole<string>>().ToTable("AspNetUserRole");
               builder.Entity<IdentityRole<string>>().ToTable("AspNetRole");
               builder.Entity<IdentityRoleClaim<string>>().ToTable("AspNetRoleClaim");
               builder.Entity<IdentityUserClaim<string>>().ToTable("AspNetUserClaim");
               builder.Entity<IdentityUserToken<string>>().ToTable("AspNetUserToken");

               builder.Entity<AppUser>()
                   .HasMany(a => a.Schedules)
                   .WithOne(s => s.AppUser)
                   .HasForeignKey(s => s.AppUserId);
          }

          protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          {
               //Local Connection String
               optionsBuilder.UseSqlServer("Server=.;Database=Alejo;Trusted_Connection=True;MultipleActiveResultSets=true");
          }
     }
}
