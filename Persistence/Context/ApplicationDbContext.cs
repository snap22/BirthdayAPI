using BirthdayAPI.Persistence.Models.Normal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Gift> Gifts { get; set; }
        public DbSet<Note> Notes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(
                ea =>
                {
                    ea.Property(a => a.AccountId).IsRequired();
                    ea.Property(a => a.Email).HasColumnType("varchar(50)").IsRequired();
                    ea.Property(a => a.DateCreated).HasColumnType("date").IsRequired();
                    ea.Property(a => a.Password).HasColumnType("varchar(50)").IsRequired();

                    ea.ToTable("Account");
                    ea.HasKey(a => a.AccountId);
                    ea.HasIndex(a => a.Email).IsUnique();

                    // one to one
                    ea.HasOne(a => a.Profile)
                        .WithOne(p => p.Account)
                        .HasForeignKey<Profile>(p => p.AccountId)
                        .OnDelete(DeleteBehavior.Cascade);
                });


            modelBuilder.Entity<Profile>(
                ep =>
                {
                    ep.Property(p => p.ProfileId).IsRequired();
                    ep.Property(p => p.Username).HasColumnType("varchar(50)").IsRequired();
                    ep.Property(p => p.Bio).HasColumnType("varchar(200)");
                    ep.Property(p => p.AccountId).IsRequired();

                    ep.ToTable("Profile");
                    ep.HasKey(p => p.ProfileId);
                    ep.HasIndex(p => p.Username).IsUnique();
                });

            modelBuilder.Entity<Contact>(
                ec =>
                {
                    ec.Property(c => c.ContactId).IsRequired();
                    ec.Property(c => c.Name).HasColumnType("varchar(50)").IsRequired();
                    ec.Property(c => c.Info).HasColumnType("varchar(200)");
                    ec.Property(c => c.Date).HasColumnType("date").IsRequired();
                    ec.Property(c => c.ProfileId).IsRequired();

                    ec.ToTable("Contact");
                    ec.HasKey(c => c.ContactId);

                    // one to many
                    ec.HasOne(c => c.Profile)
                        .WithMany(p => p.Contacts)
                        .HasForeignKey(c => c.ProfileId)
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity<Gift>(
                eg =>
                {
                    eg.Property(g => g.GiftId).IsRequired();
                    eg.Property(g => g.Name).HasColumnType("varchar(50)").IsRequired();
                    eg.Property(g => g.Description).HasColumnType("varchar(200)");
                    eg.Property(g => g.EstimatedPrice).HasColumnType("decimal(5, 2)").HasDefaultValue(0.00);
                    eg.Property(g => g.ContactId).IsRequired();

                    eg.ToTable("Gift");
                    eg.HasKey(g => g.GiftId);

                    eg.HasOne(g => g.Contact)
                        .WithMany(c => c.Gifts)
                        .HasForeignKey(g => g.ContactId)
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity<Note>(
                en =>
                {
                    en.Property(n => n.NoteId).IsRequired();
                    en.Property(n => n.Title).IsRequired().HasColumnType("varchar(50)");
                    en.Property(n => n.Description).HasColumnType("varchar(200)");
                    en.Property(n => n.ProfileId).IsRequired();

                    en.ToTable("Note");
                    en.HasKey(n => n.NoteId);

                    en.HasOne(n => n.Profile)
                        .WithMany(p => p.Notes)
                        .HasForeignKey(n => n.ProfileId)
                        .OnDelete(DeleteBehavior.Cascade);
                });

            base.OnModelCreating(modelBuilder);
        }


    }
}

