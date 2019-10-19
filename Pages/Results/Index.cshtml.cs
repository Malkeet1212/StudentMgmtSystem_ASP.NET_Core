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
    //Returns all the results.
    public class IndexModel : PageModel
    {
        private readonly Student_Management.Models.Student_ManagementDBContext _context;

        public IndexModel(Student_Management.Models.Student_ManagementDBContext context)
        {
            _context = context;
        }

        //All results.
        public IList<Result> Result { get;set; }

        //Uses a lamda to get all results with relations.
        public void  OnGet()
        {
            Result =  _context.Result
                .Include(r => r.Course)
                .Include(r => r.Student).ToList();
        }
    }
}
