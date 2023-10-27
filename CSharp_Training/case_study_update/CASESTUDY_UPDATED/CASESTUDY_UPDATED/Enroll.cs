using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Case_Study
{
    public class Enrollment
    {
        public Student Student { get; set; }
        public Course Course { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public Enrollment(Student student, Course course, DateTime enrollmentDate)
        {
            Student = student;
            Course = course;
            EnrollmentDate = enrollmentDate;
        }

    }
}
