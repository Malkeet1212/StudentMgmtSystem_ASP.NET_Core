using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Management.BusinessLayer
{
    //Result details
    public class Result
    {

        //Result Id 
        public int Id { get; set; }

        //Course Id from course 
        public int CourseId { get; set; }

        //Student id from student.
        public int StudentId { get; set; }

        //Relation course 
        public Course Course { get; set; }

        //Relation student.
        public Student Student { get; set; }

        //Grade obtained by student.
        public Grade Grade { get; set; }

    }

    //Enum keeps the possible grades.

    public enum Grade { A, B , C , F }
}
