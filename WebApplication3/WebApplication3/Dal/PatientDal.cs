using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace HospitalManagement.DAL
{
    public class PatientDAL: DbContext
    {

        string connstr = "";
        
        public PatientDAL(string connstr)
        {
            this.connstr = connstr;
        }
        public PatientDAL(DbContextOptions<PatientDAL> options) : base(options)
        {
          
        }
        public PatientDAL()
        {

        }
        public virtual DbSet<LoginModel> Login { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //   optionsBuilder.UseSqlServer(connectionString: conStr);
            optionsBuilder.UseSqlServer(@"Data Source=HP;Initial Catalog=PatientDB;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .ToTable("tblPatient");
            modelBuilder.Entity<problem>()
                .ToTable("tblProblem");

            modelBuilder.Entity<Registration>()
                .ToTable("tblRegister");
            

           

            modelBuilder.Entity<Registration>(entity => {
                entity.HasIndex(e => e.userName).IsUnique();
            });


            modelBuilder.Entity<Patient>()
                .HasKey(p => p.id);
            modelBuilder.Entity<problem>()
               .HasKey(p => p.id);

            //1 to many

            modelBuilder.Entity<Patient>()
       .HasMany(c => c.problems)
       .WithOne(e => e.patient);

            modelBuilder.Entity<Patient>();
            //     .Property(p => p.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed)
        }
       

        public DbSet<Patient> PatientModels { get; set; }
        public DbSet<problem> Problems { get; set; }
        public DbSet<Registration> Registrations { get; set; }

       
    }
}
