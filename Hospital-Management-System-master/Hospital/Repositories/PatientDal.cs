using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Hospital.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.DAL
{
    public class PatientDal : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=ROHIT;Initial Catalog=PatientDB;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().HasKey(p => p.Id);

            modelBuilder.Entity<Patient>().Property(t => t.Id).ValueGeneratedNever();

            modelBuilder.Entity<Patient>()
                .ToTable("Patients");

            
        }

        public DbSet<Patient> Patients { get; set; }
    }
}
