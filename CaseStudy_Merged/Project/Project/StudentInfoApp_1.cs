using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoApp
{
    //Student
    
        public class Student
        {
            public int StudentId { get; set; }
            public string Name { get; set; }
            public DateTime DateOfBirth { get; set; }
        }

        //Course
        public class Course
        {
            public int CourseId { get; set; }
            public string Name { get; set; }
        }

        //Enroll

        public class Enroll
        {
            public int EnrollmentId { get; set; }
            public int StudentId { get; set; }
            public int CourseId { get; set; }
            public DateTime EnrollmentDate { get; set; }
        }
    
}
