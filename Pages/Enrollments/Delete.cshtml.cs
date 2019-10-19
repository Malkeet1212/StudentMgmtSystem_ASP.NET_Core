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
    //Deletes an enrollment.
    public class DeleteModel : PageModel
    {
        private readonly Student_Management.Models.Student_ManagementDBContext _context;

        public DeleteModel(Student_Management.Models.Student_ManagementDBContext context)
        {
            _context = context;
        }

        //Keeps the enrollment.
        [BindProperty]
        public Enrollment Enrollment { get; set; }

        //Returns enrollment details using a lamda query.
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
        //Removes the enrollment. linq query is used to get the enrollment.
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Enrollment = (from enrollment in _context.Enrollment
                                                  where enrollment.Id == id
                         select enrollment).FirstOrDefault();

            if (Enrollment != null)
            {
                _context.Enrollment.Remove(Enrollment);
                 _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
