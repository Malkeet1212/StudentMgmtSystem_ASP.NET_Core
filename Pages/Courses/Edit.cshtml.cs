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

namespace Student_Management.Pages.Courses
{
    //Updates course details.
    public class EditModel : PageModel
    {
        private readonly Student_Management.Models.Student_ManagementDBContext _context;

        public EditModel(Student_Management.Models.Student_ManagementDBContext context)
        {
            _context = context;
        }

        //Keeps course details
        [BindProperty]
        public Course Course { get; set; }

        //retunrs the course details form. uses a lamda query.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course =  _context.Course.FirstOrDefault(m => m.Id == id);

            if (Course == null)
            {
                return NotFound();
            }
            return Page();
        }

        //Updates a course
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Course).State = EntityState.Modified;

            try
            {
                 _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(Course.Id))
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

        //uses a lamda to check course is available.
        private bool CourseExists(int id)
        {
            return _context.Course.Any(e => e.Id == id);
        }
    }
}
