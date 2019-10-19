using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Student_Management.BusinessLayer;
using Student_Management.Models;

namespace Student_Management.Pages.Enrollments
{
    //Updates an enrollment.
    public class EditModel : PageModel
    {
        private readonly Student_Management.Models.Student_ManagementDBContext _context;

        public EditModel(Student_Management.Models.Student_ManagementDBContext context)
        {
            _context = context;
        }

        //Keeps enrollment details.
        [BindProperty]
        public Enrollment Enrollment { get; set; }

        //Returns the enrollment with the lamda query to edit.
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
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "CourseSerialId");
            ViewData["StudentId"] = new SelectList(_context.Set<Student>(), "Id", "StudentSerialId");
            ViewData["Semester"] = new SelectList(Enum.GetValues(typeof(Semester)), Enrollment.Semester);
            return Page();
        }

        //Updates the enrollment.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Enrollment).State = EntityState.Modified;

            try
            {
                 _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnrollmentExists(Enrollment.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        //Enrollment availability check using lamda.
        private bool EnrollmentExists(int id)
        {
            return _context.Enrollment.Any(e => e.Id == id);
        }
    }
}
