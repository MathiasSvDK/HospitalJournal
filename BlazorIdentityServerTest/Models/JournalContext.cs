using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlazorIdentityServerTest.Models
{
    public partial class JournalContext : DbContext
    {
        public JournalContext()
        {
        }

        public JournalContext(DbContextOptions<JournalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attachment> Attachments { get; set; } = null!;
        public virtual DbSet<Journal> Journals { get; set; } = null!;
        public virtual DbSet<JournalApprove> JournalApproves { get; set; } = null!;
        public virtual DbSet<Page> Pages { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=116.203.36.14;database=journal;user=root;password=Sejkode123!", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.3.34-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Attachment>(entity =>
            {
                entity.ToTable("attachments");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.BlockId)
                    .HasMaxLength(255)
                    .HasColumnName("block_id");

                entity.Property(e => e.Type)
                    .HasMaxLength(255)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Journal>(entity =>
            {
                entity.ToTable("journals");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.AssignedEmp)
                    .HasMaxLength(255)
                    .HasColumnName("assigned_emp");

                entity.Property(e => e.AssignedPat)
                    .HasMaxLength(255)
                    .HasColumnName("assigned_pat");

                entity.Property(e => e.Attachments)
                    .HasMaxLength(255)
                    .HasColumnName("attachments");

                entity.Property(e => e.HospitalId)
                    .HasColumnType("int(11)")
                    .HasColumnName("hospital_id");

                entity.Property(e => e.Pages)
                    .HasColumnType("int(11)")
                    .HasColumnName("pages");
            });

            modelBuilder.Entity<JournalApprove>(entity =>
            {
                entity.ToTable("journal_approve");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.EditorId)
                    .HasColumnType("int(11)")
                    .HasColumnName("editor_id");

                entity.Property(e => e.OwnerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("owner_id");

                entity.Property(e => e.PageId)
                    .HasColumnType("int(11)")
                    .HasColumnName("page_id");
            });

            modelBuilder.Entity<Page>(entity =>
            {
                entity.ToTable("pages");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasMaxLength(255)
                    .HasColumnName("date");

                entity.Property(e => e.Text)
                    .HasMaxLength(255)
                    .HasColumnName("text");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
