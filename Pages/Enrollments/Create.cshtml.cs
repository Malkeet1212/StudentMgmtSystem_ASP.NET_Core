using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Student_Management.BusinessLayer;
using Student_Management.Models;

namespace Student_Management.Pages.Enrollments
{
    //Creats a new student enrollment.
    public class CreateModel : PageModel
    {
        private readonly Student_Management.Models.Student_ManagementDBContext _context;

        public CreateModel(Student_Management.Models.Student_ManagementDBContext context)
        {
            _context = context;
        }

        //Gets the enrollment form.
        public IActionResult OnGet()
        {
        ViewData["CourseId"] = new SelectList(_context.Course, "Id", "CourseSerialId");
        ViewData["StudentId"] = new SelectList(_context.Set<Student>(), "Id", "StudentSerialId");
            ViewData["Semester"] = new SelectList(Enum.GetValues(typeof(Semester)));
            return Page();
        }

        //Keeps enrollment details.
        [BindProperty]
        public Enrollment Enrollment { get; set; }

        //Adds an enrollment.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Enrollment.Add(Enrollment);
             _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}