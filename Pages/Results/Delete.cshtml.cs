using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Student_Management.BusinessLayer;
using Student_Management.Models;

namespace Student_Management.Pages.Results
{
    //Deletes the result.
    public class DeleteModel : PageModel
    {
        private readonly Student_Management.Models.Student_ManagementDBContext _context;

        public DeleteModel(Student_Management.Models.Student_ManagementDBContext context)
        {
            _context = context;
        }

        //Keeps the result
        [BindProperty]
        public Result Result { get; set; }

        //Returns the result using lamda including relations.
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
            return Page();
        }

        //Deletes the result .uses  linq query to get the result .
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Result = (from results in _context.Result
                     where results.Id == id select results).FirstOrDefault();

            if (Result != null)
            {
                _context.Result.Remove(Result);
                _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
