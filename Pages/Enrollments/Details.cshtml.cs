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
    //Returns the enrollment.
    public class DetailsModel : PageModel
    {
        private readonly Student_Management.Models.Student_ManagementDBContext _context;

        public DetailsModel(Student_Management.Models.Student_ManagementDBContext context)
        {
            _context = context;
        }

        //Keeps enrollment details.
        public Enrollment Enrollment { get; set; }

        //Gets the enrollment using a lamda query with relationships.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Enrollment =  _context.Enrollment
                .Include(e => e.Course)
                .Include(e => e.Student).FirstOrDefault(m => m.Id == id);

            if (Enrollment == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
