using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case_Study
{
    public class AppEngine
    {

        private List<Student> students = new List<Student>();
        private List<Course> courses = new List<Course>();
        private List<Enrollment> enrollments = new List<Enrollment>();

        // Constructor
        public AppEngine()
        {

            InitializeData();
        }
        private void InitializeData()
        {
            //students
            //students.Add(new Student(1033404, "SHREYANK", "2001-05-29"));

            //course
            //courses.Add(new Course(100, "Computer science and engg"));
            //courses.Add(new Course(101, "Information science and engg"));
            //courses.Add(new Course(102, "Electronics and communication"));
            //courses.Add(new Course(103, "Electrical and electronics engg"));
            //courses.Add(new Course(104, "Mechanical engg"));
            //courses.Add(new Course(104, "civil engg"));


        }

        public void RegisterStudent(Student student)
        {
            students.Add(student);
        }

        public void IntroduceCourse(Course course)
        {
            courses.Add(course);
        }

        public void EnrollStudent(Student student, Course course)
        {
            DateTime enrollmentDate = DateTime.Now;
            enrollments.Add(new Enrollment(student, course, enrollmentDate));
        }

        public List<Student> GetStudents()
        {
            return students;
        }

        public List<Course> GetCourses()
        {
            return courses;
        }

        public List<Enrollment> GetEnrollments()
        {
            return enrollments;
        }
    }
}