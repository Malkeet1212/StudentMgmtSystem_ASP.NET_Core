using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Student_Management.BusinessLayer;
using Student_Management.Models;

namespace Student_Management.Pages.Students
{
    //Removes a student from databse.
    public class DeleteModel : PageModel
    {
        private readonly Student_Management.Models.Student_ManagementDBContext _context;

        public DeleteModel(Student_Management.Models.Student_ManagementDBContext context)
        {
            _context = context;
        }

        //Keeps the student details.
        [BindProperty]
        public Student Student { get; set; }

        //Gets the student details using a lamda query.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student =  _context.Student.FirstOrDefault(m => m.Id == id);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }

        //Removes a student uses a lamda to check whether the student exists.
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = (from  student in _context.Student
                       where student.Id == id select student).FirstOrDefault();

            if (Student != null)
            {
                _context.Student.Remove(Student);
                 _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
