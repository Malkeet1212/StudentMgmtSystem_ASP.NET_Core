using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Student_Management.BusinessLayer;
using Student_Management.Models;

namespace Student_Management.Pages.Courses
{
    //Returns all courses
    public class IndexModel : PageModel
    {
        private readonly Student_Management.Models.Student_ManagementDBContext _context;

        public IndexModel(Student_Management.Models.Student_ManagementDBContext context)
        {
            _context = context;
        }

        //Keeps all courses.
        public IList<Course> Course { get;set; }

        //Returns all couses using a linq query.
        public void OnGet()
        {
            Course = (from course in _context.Course select course).ToList();
        }
    }
}
