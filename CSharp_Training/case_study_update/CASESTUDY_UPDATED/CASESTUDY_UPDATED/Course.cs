using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case_Study
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public Course(int courseId, string courseName)
        {
            CourseId = courseId;
            CourseName = courseName;
        }
    }
}