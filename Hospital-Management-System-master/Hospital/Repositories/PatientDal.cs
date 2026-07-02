using Hospital.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.DAL
{
    public class PatientDal : DbContext
    {
        public PatientDal(DbContextOptions<PatientDal> options)
            : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Id)
                       .ValueGeneratedOnAdd();

                entity.ToTable("Patients");
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);

                entity.ToTable("Users");
            });
        }
    }
}