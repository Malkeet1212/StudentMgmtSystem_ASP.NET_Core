﻿using System;
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
    //Result details.
    public class DetailsModel : PageModel
    {
        private readonly Student_Management.Models.Student_ManagementDBContext _context;

        public DetailsModel(Student_Management.Models.Student_ManagementDBContext context)
        {
            _context = context;
        }

        //Keeps the result.
        public Result Result { get; set; }

        //Returns the result using a lamda query with relations.
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
    }
}
