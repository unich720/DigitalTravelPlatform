using DTP.Entity.Models;
using Microsoft.EntityFrameworkCore;

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
                entity.Property(e => e.AnswerText).IsRequired();

                entity.Property(e => e.Count).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Answers_Questions");
            });

            modelBuilder.Entity<MovementHistory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MovementHistory");

                entity.HasOne(d => d.Place)
                    .WithMany()
                    .HasForeignKey(d => d.PlaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MovementHistory_Places");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MovementHistory_Users");
            });

            modelBuilder.Entity<Place>(entity =>
            {
                entity.Property(e => e.Place1).HasColumnName("Place");

                entity.Property(e => e.Rating)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Poll>(entity =>
            {
                entity.Property(e => e.PollName).IsRequired();
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.QuestionText).IsRequired();

                entity.HasOne(d => d.Poll)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.PollId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Questions_Polls");
            });

            modelBuilder.Entity<Route>(entity =>
            {
                entity.Property(e => e.RouteName).IsRequired();
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
                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastName).IsRequired();

                entity.Property(e => e.Login).IsRequired();

                entity.Property(e => e.Password).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
