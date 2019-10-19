using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Student_Management.BusinessLayer;
using Student_Management.Models;

namespace Student_Management.Pages.Students
{
    //Creates a new student.
    public class CreateModel : PageModel
    {
        private readonly Student_Management.Models.Student_ManagementDBContext _context;

        public CreateModel(Student_Management.Models.Student_ManagementDBContext context)
        {
            _context = context;
        }

        //Gets the resgistration form.
        public IActionResult OnGet()
        {
            return Page();
        }

        //Keeps the student.
        [BindProperty]
        public Student Student { get; set; }

        //Adds the student to databse.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Student.Add(Student);
             _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}