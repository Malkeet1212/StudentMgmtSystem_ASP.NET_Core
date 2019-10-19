using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Management.BusinessLayer
{
    //Keeps course details
    public class Course
    {
        //Course Id
        public int Id { get; set; }

        [Required]
        //Name of course 
        public string CourseName { get; set; }
        

        //Course serial id combination of Id and name
        [NotMapped]
        public string CourseSerialId { get {
                return CourseName + Id;
            }}
        
        //Course credits.
        public int Credits { get; set; }

    }
}
