using System;
using DTP.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DTP.Entity
{
    public partial class DTPDBContext : DbContext
    {
        public DTPDBContext()
        {
        }

        public DTPDBContext(DbContextOptions<DTPDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<MovementHistory> MovementHistories { get; set; }
        public virtual DbSet<Place> Places { get; set; }
        public virtual DbSet<Poll> Polls { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Route> Routes { get; set; }
        public virtual DbSet<RoutePlace> RoutePlaces { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer("Server=digitaltravelplatformsqlserver.database.windows.net;user id=admindb;password='x49yQpXVmXGy9xXKh5Ry';Database=DigitalTravelPlatformDB");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AnswerText)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK_Answers_Questions");
            });

            modelBuilder.Entity<MovementHistory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MovementHistory");
            });

            modelBuilder.Entity<Place>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Place1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Place");

                entity.Property(e => e.Rating).HasColumnType("decimal(5, 2)");
            });

            modelBuilder.Entity<Poll>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.PollName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.QuestionText)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Poll)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.PollId)
                    .HasConstraintName("FK_Questions_Polls");
            });

            modelBuilder.Entity<Route>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.RouteName)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<RoutePlace>(entity =>
            {
                entity.HasNoKey();

                entity.HasOne(d => d.Place)
                    .WithMany()
                    .HasForeignKey(d => d.PlaceId)
                    .HasConstraintName("FK_RoutePlaces_Places");

                entity.HasOne(d => d.Route)
                    .WithMany()
                    .HasForeignKey(d => d.RouteId)
                    .HasConstraintName("FK_RoutePlaces_Routes");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Login)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
