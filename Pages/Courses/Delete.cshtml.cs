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
    //Deletes a course.
    public class DeleteModel : PageModel
    {
        private readonly Student_Management.Models.Student_ManagementDBContext _context;

        public DeleteModel(Student_Management.Models.Student_ManagementDBContext context)
        {
            _context = context;
        }

        //Keeps the course details.
        [BindProperty]
        public Course Course { get; set; }

        //returns the course details using a lamda query.
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

        //Removes the course. uses linq query  to return the course details
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course = (from course in _context.Course
                      where course.Id == id select course).FirstOrDefault();

            if (Course != null)
            {
                _context.Course.Remove(Course);
                _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
