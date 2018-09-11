using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SimpleBot.Model
{
    public partial class DbChatBotContext : DbContext
    {
        public DbChatBotContext()
        {
        }

        public DbChatBotContext(DbContextOptions<DbChatBotContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UserProfileSQLServer> UserProfile { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                string conn = ConfigurationManager.ConnectionStrings["SQLServer"].ToString();
                optionsBuilder.UseSqlServer(conn);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProfileSQLServer>(entity =>
            {
                entity.Property(e => e.IdUsuario)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}
