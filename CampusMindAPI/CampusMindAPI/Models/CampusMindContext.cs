using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CampusMindAPI.Models
{
    public partial class CampusMindContext : DbContext
    {
        public CampusMindContext()
        {
        }

        public CampusMindContext(DbContextOptions<CampusMindContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<Lead> Leads { get; set; }
        public virtual DbSet<Technology> Technologies { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=CampusMind;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Candidate>(entity =>
            {
                entity.ToTable("Candidate");

                entity.Property(e => e.CandidateId).ValueGeneratedNever();

                entity.Property(e => e.CandidateName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ImagePath)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Lead)
                    .WithMany(p => p.Candidates)
                    .HasForeignKey(d => d.LeadId)
                    .HasConstraintName("FK__Candidate__LeadI__286302EC");
            });

            modelBuilder.Entity<Lead>(entity =>
            {
                entity.ToTable("Lead");

                entity.Property(e => e.LeadId).ValueGeneratedNever();

                entity.Property(e => e.ImagePath)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LeadName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Technology)
                    .WithMany(p => p.Leads)
                    .HasForeignKey(d => d.TechnologyId)
                    .HasConstraintName("FK__Lead__Technology__25869641");
            });

            modelBuilder.Entity<Technology>(entity =>
            {
                entity.ToTable("Technology");

                entity.Property(e => e.TechnologyId).ValueGeneratedNever();

                entity.Property(e => e.TechnologyName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserName)
                    .HasName("PK__Users__C9F28457CC5C7F3F");

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RoleAssign)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
