using Microsoft.EntityFrameworkCore;
using SisClin.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisClin.Infra.Data
{
    public class DbSisClin : DbContext
    {
        public DbSisClin()
        {
        }
        public DbSisClin(DbContextOptions<DbSisClin> options) : base(options)
        {
        }

        public DbSet<Tipe> Tipes { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<People> Peoples { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<Attendance> MyProperty { get; set; }
        public DbSet<EmployerAttendance> EmployersAttendances { get; set; }
        public DbSet<PeopleAttendance> PeoplesAttendances { get; set; }
        public DbSet<ProcedureAttendance> ProceduresAttendances { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployerAttendance>(entity =>
            {
                entity.HasKey(e => new { e.AttendanceId, e.EmployerId});
            });
            modelBuilder.Entity<PeopleAttendance>(entity =>
            {
                entity.HasKey(e => new { e.AttendanceId, e.PeopleId });
            });
            modelBuilder.Entity<ProcedureAttendance>(entity =>
            {
                entity.HasKey(e => new { e.AttendanceId, e.ProcedureId });
            });
        }
    }
}
