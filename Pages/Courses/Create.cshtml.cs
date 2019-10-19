using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Student_Management.BusinessLayer;
using Student_Management.Models;

namespace Student_Management.Pages.Courses
{
    //Adds a new course.
    public class CreateModel : PageModel
    {
        private readonly Student_Management.Models.Student_ManagementDBContext _context;

        public CreateModel(Student_Management.Models.Student_ManagementDBContext context)
        {
            _context = context;
        }

        //Returns the create course form.
        public IActionResult OnGet()
        {
            return Page();
        }


        //Keeps the course model 
        [BindProperty]
        public Course Course { get; set; }

        //Creates a new  course in databse.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Course.Add(Course);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}