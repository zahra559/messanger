using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ZeMessanger.Models;

namespace ZeMessanger.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Message>()
                .HasOne<AppUser>(a => a.Sender)
                .WithMany(d => d.Messages)
                .HasForeignKey(d => d.UserID);
            builder.Entity<Noti>()
               .HasOne<AppUser>(a => a.Sender)
               .WithMany(d => d.Notis)
               .HasForeignKey(d => d.UserID);

        }
        public virtual  DbSet<Message> Messages { get; set; }
        public virtual DbSet<Noti> Notis { get; set; }
    }
}
