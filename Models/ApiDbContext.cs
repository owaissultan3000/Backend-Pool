using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace carpool.Models
{
    public partial class ApiDbContext : DbContext
    {
        public ApiDbContext()
        {
        }

        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Captain> Captains { get; set; }
        public virtual DbSet<Ride> Rides { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=NOMANANJUM-HP47;Database=carpool;User ID=sa;Password=dingdong;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.BookingId).IsUnicode(false);

                entity.Property(e => e.CaptainId).IsUnicode(false);

                entity.Property(e => e.PassengerDestination).IsUnicode(false);

                entity.Property(e => e.PassengerId).IsUnicode(false);

                entity.Property(e => e.PassengerName).IsUnicode(false);

                entity.Property(e => e.PassengerPhoneNumber).IsUnicode(false);

                entity.HasOne(d => d.Captain)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CaptainId)
                    .HasConstraintName("FK__Booking__Captain__5CD6CB2B");

                entity.HasOne(d => d.Passenger)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.PassengerId)
                    .HasConstraintName("FK__Booking__Passeng__5DCAEF64");
            });

            modelBuilder.Entity<Captain>(entity =>
            {
                entity.Property(e => e.CaptainId).IsUnicode(false);

                entity.Property(e => e.CaptainName).IsUnicode(false);

                entity.Property(e => e.CaptainPhone).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Gender).IsUnicode(false);

                entity.Property(e => e.Passwords).IsUnicode(false);

                entity.Property(e => e.Role).IsUnicode(false);

                entity.Property(e => e.VehicleColor).IsUnicode(false);

                entity.Property(e => e.VehicleModel).IsUnicode(false);

                entity.Property(e => e.VehicleNumber).IsUnicode(false);
            });

            modelBuilder.Entity<Ride>(entity =>
            {
                entity.Property(e => e.RideId).IsUnicode(false);

                entity.Property(e => e.CaptainId).IsUnicode(false);

                entity.Property(e => e.FarePerSeats).IsUnicode(false);

                entity.Property(e => e.JourneyRoute).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.PhoneNumber).IsUnicode(false);

                entity.Property(e => e.VehicleId).IsUnicode(false);

                entity.HasOne(d => d.Captain)
                    .WithMany(p => p.Rides)
                    .HasForeignKey(d => d.CaptainId)
                    .HasConstraintName("FK__Rides__CaptainId__59FA5E80");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Gender).IsUnicode(false);

                entity.Property(e => e.Passwords).IsUnicode(false);

                entity.Property(e => e.PhoneNumber).IsUnicode(false);

                entity.Property(e => e.Role).IsUnicode(false);

                entity.Property(e => e.UserName).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
