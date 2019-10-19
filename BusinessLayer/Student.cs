using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Management.BusinessLayer
{
    //Student details.
    public class Student
    {
        //Student ID.
        public int Id { get; set; }

        //Student serial id combination of student name and Id.
        [NotMapped]
        public string  StudentSerialId { get {

                
                    return StudentName + Id;
                
            } }

        [Required]
        //Student name.
        public string StudentName { get; set; }

        // Contact number
        public string ContactNumber { get; set; }

    }
}
