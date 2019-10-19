using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Student_Management.BusinessLayer;
using Student_Management.Models;

namespace Student_Management.Pages.Students
{
    //Returns all the students .
    public class IndexModel : PageModel
    {
        private readonly Student_Management.Models.Student_ManagementDBContext _context;

        public IndexModel(Student_Management.Models.Student_ManagementDBContext context)
        {
            _context = context;
        }

        //All the students.
        public IList<Student> Student { get;set; }

        //Uses a linq query to fetch all students.
        public void  OnGetAsync()
        {
            Student = (from student in _context.Student select student).ToList();
        }
    }
}
