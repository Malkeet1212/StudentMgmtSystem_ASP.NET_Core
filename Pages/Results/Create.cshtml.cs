using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Student_Management.BusinessLayer;
using Student_Management.Models;

namespace Student_Management.Pages.Results
{
    //Creats a new result.
    public class CreateModel : PageModel
    {
        private readonly Student_Management.Models.Student_ManagementDBContext _context;

        public CreateModel(Student_Management.Models.Student_ManagementDBContext context)
        {
            _context = context;
        }

        //Prepares the enter results form.
        public IActionResult OnGet()
        {
        ViewData["CourseId"] = new SelectList(_context.Course, "Id", "CourseSerialId");
        ViewData["StudentId"] = new SelectList(_context.Set<Student>(), "Id", "StudentSerialId");
        ViewData["Grade"] = new SelectList(Enum.GetValues(typeof(Grade)));
            return Page();
        }

        //Keeps the result.
        [BindProperty]
        public Result Result { get; set; }

        //Adds the result.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Result.Add(Result);
             _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}