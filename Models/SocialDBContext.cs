using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ISIT420_Project.Models
{
    public partial class SocialDBContext : DbContext
    {
        public SocialDBContext()
        {
        }

        public SocialDBContext(DbContextOptions<SocialDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AgeTable> AgeTables { get; set; } = null!;
        public virtual DbSet<FrequencyTable> FrequencyTables { get; set; } = null!;
        public virtual DbSet<FriendsTable> FriendsTables { get; set; } = null!;
        public virtual DbSet<GenderTable> GenderTables { get; set; } = null!;
        public virtual DbSet<ParticipationTable> ParticipationTables { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=SocialDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgeTable>(entity =>
            {
                entity.HasKey(e => e.AgeId);

                entity.ToTable("AgeTable");

                entity.Property(e => e.AgeId)
                    .ValueGeneratedNever()
                    .HasColumnName("AgeID");

                entity.Property(e => e.AgeRange).HasMaxLength(50);
            });

            modelBuilder.Entity<FrequencyTable>(entity =>
            {
                entity.HasKey(e => e.FrequencyId);

                entity.ToTable("FrequencyTable");

                entity.Property(e => e.FrequencyId)
                    .ValueGeneratedNever()
                    .HasColumnName("FrequencyID");

                entity.Property(e => e.Frequency).HasMaxLength(50);
            });

            modelBuilder.Entity<FriendsTable>(entity =>
            {
                entity.HasKey(e => e.FriendsId);

                entity.ToTable("FriendsTable");

                entity.Property(e => e.FriendsId).HasColumnName("FriendsID");

                entity.Property(e => e.AgeId).HasColumnName("AgeID");

                entity.Property(e => e.FrequencyId).HasColumnName("FrequencyID");

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.Region).HasMaxLength(50);

                entity.HasOne(d => d.Age)
                    .WithMany(p => p.FriendsTables)
                    .HasForeignKey(d => d.AgeId)
                    .HasConstraintName("FK_FriendsTable_AgeTable");

                entity.HasOne(d => d.Frequency)
                    .WithMany(p => p.FriendsTables)
                    .HasForeignKey(d => d.FrequencyId)
                    .HasConstraintName("FK_FriendsTable_FrequencyTable");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.FriendsTables)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("FK_FriendsTable_GenderTable");
            });

            modelBuilder.Entity<GenderTable>(entity =>
            {
                entity.HasKey(e => e.GenderId);

                entity.ToTable("GenderTable");

                entity.Property(e => e.GenderId)
                    .ValueGeneratedNever()
                    .HasColumnName("GenderID");

                entity.Property(e => e.Gender).HasMaxLength(25);
            });

            modelBuilder.Entity<ParticipationTable>(entity =>
            {
                entity.HasKey(e => e.ParticipationId);

                entity.ToTable("ParticipationTable");

                entity.Property(e => e.ParticipationId).HasColumnName("ParticipationID");

                entity.Property(e => e.AgeId).HasColumnName("AgeID");

                entity.Property(e => e.FrequencyId).HasColumnName("FrequencyID");

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.Region).HasMaxLength(50);

                entity.HasOne(d => d.Age)
                    .WithMany(p => p.ParticipationTables)
                    .HasForeignKey(d => d.AgeId)
                    .HasConstraintName("FK_ParticipationTable_AgeTable");

                entity.HasOne(d => d.Frequency)
                    .WithMany(p => p.ParticipationTables)
                    .HasForeignKey(d => d.FrequencyId)
                    .HasConstraintName("FK_ParticipationTable_FrequencyTable");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.ParticipationTables)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("FK_ParticipationTable_GenderTable");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
