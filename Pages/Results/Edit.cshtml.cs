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

namespace Student_Management.Pages.Results
{
    //Updates the result.
    public class EditModel : PageModel
    {
        private readonly Student_Management.Models.Student_ManagementDBContext _context;

        public EditModel(Student_Management.Models.Student_ManagementDBContext context)
        {
            _context = context;
        }

        //Keeps the result.
        [BindProperty]
        public Result Result { get; set; }

        //Gets the result for update uses a lamda query.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Result =  _context.Result
                .Include(r => r.Course)
                .Include(r => r.Student).FirstOrDefault(m => m.Id == id);

            if (Result == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "CourseSerialId");
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "StudentSerialId");
            ViewData["Grade"] = new SelectList(Enum.GetValues(typeof(Grade)), Result.Grade);
            return Page();
        }

        //Update the result
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Result).State = EntityState.Modified;

            try
            {
                 _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResultExists(Result.Id))
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

        //Checks result availability using lamda query.
        private bool ResultExists(int id)
        {
            return _context.Result.Any(e => e.Id == id);
        }
    }
}
