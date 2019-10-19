using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Student_Management.BusinessLayer;

namespace Student_Management.Models
{
    //Connects the business objects to database. Helps to query data  in to objects.
    public class Student_ManagementDBContext : DbContext
    {
        public Student_ManagementDBContext (DbContextOptions<Student_ManagementDBContext> options)
            : base(options)
        {
        }

        public DbSet<Student_Management.BusinessLayer.Course> Course { get; set; }

        public DbSet<Student_Management.BusinessLayer.Enrollment> Enrollment { get; set; }

        public DbSet<Student_Management.BusinessLayer.Result> Result { get; set; }

        public DbSet<Student_Management.BusinessLayer.Student> Student { get; set; }
    }
}
