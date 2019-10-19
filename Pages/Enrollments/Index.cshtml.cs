using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Student_Management.BusinessLayer;
using Student_Management.Models;

namespace Student_Management.Pages.Enrollments
{
    //Returns all enrollements.
    public class IndexModel : PageModel
    {
        private readonly Student_Management.Models.Student_ManagementDBContext _context;

        public IndexModel(Student_Management.Models.Student_ManagementDBContext context)
        {
            _context = context;
        }

        //All the enrollments.
        public IList<Enrollment> Enrollment { get;set; }

        //Returns enrollments using lamda query with relationships.
        public void  OnGet()
        {
            Enrollment =  _context.Enrollment
                .Include(e => e.Course)
                .Include(e => e.Student).ToList();
        }
    }
}
