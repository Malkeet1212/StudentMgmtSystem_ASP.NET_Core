using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Management.BusinessLayer
{
    //Enrollment details
    public class Enrollment
    {
        //Enrollment Id
        public int Id { get; set; }

        //Course Id from course 
        public int CourseId { get; set; }

        //Student Id from Student
        public int StudentId { get; set; }

        //Relationship to course 
        public Course Course { get; set; }

        //Relation to student.
        public Student Student { get; set; }

        //Enum representing a semester.
        public Semester Semester { get; set; }


    }
    //Enum semester with three semesters.
    public enum Semester { Semester_1, Semester_2 , Semester_3 }
}
