using System;
using System.Data.SqlClient;
using StudentInfoApp;
using System.Collections.Generic;

namespace AppEngine
{
    public class AppEngine_1
    {
        public const string ConnectionString = "Data Source=ICS-LT-5NW1ZD3\\SQLEXPRESS;Initial Catalog=casestudy_p;Integrated Security=true;"; // Replace with your database connection string

        public void RegisterStudent(Student student)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string insertStudentQuery = "INSERT INTO Student (Name, DateOfBirth) VALUES (@Name, @DateOfBirth)";
                SqlCommand insertStudentCmd = new SqlCommand(insertStudentQuery, connection);

                insertStudentCmd.Parameters.AddWithValue("@Name", student.Name);
                insertStudentCmd.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);

                insertStudentCmd.ExecuteNonQuery();
            }
        }

        public void IntroduceCourse(Course course)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string insertCourseQuery = "INSERT INTO Course (Name) VALUES (@Name)";
                SqlCommand insertCourseCmd = new SqlCommand(insertCourseQuery, connection);

                insertCourseCmd.Parameters.AddWithValue("@Name", course.Name);

                insertCourseCmd.ExecuteNonQuery();
            }
        }

        public void EnrollStudentInCourse(int studentId, int courseId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string enrollQuery = "INSERT INTO Enroll (StudentId, CourseId, EnrollmentDate) VALUES (@StudentId, @CourseId, @EnrollmentDate)";
                SqlCommand enrollCmd = new SqlCommand(enrollQuery, connection);

                enrollCmd.Parameters.AddWithValue("@StudentId", studentId);
                enrollCmd.Parameters.AddWithValue("@CourseId", courseId);
                enrollCmd.Parameters.AddWithValue("@EnrollmentDate", DateTime.Now);

                enrollCmd.ExecuteNonQuery();
            }
        }

        public List<Student> ListStudents()
        {
            List<Student> students = new List<Student>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string selectStudentsQuery = "SELECT * FROM Student";
                SqlCommand selectStudentsCmd = new SqlCommand(selectStudentsQuery, connection);

                using (SqlDataReader reader = selectStudentsCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Student student = new Student
                        {
                            StudentId = (int)reader["StudentId"],
                            Name = (string)reader["Name"],
                            DateOfBirth = (DateTime)reader["DateOfBirth"]
                        };
                        students.Add(student);
                    }
                }
            }

            return students;
        }

        public List<Course> ListCourses()
        {
            List<Course> courses = new List<Course>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string selectCoursesQuery = "SELECT * FROM Course";
                SqlCommand selectCoursesCmd = new SqlCommand(selectCoursesQuery, connection);

                using (SqlDataReader reader = selectCoursesCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Course course = new Course
                        {
                            CourseId = (int)reader["CourseId"],
                            Name = (string)reader["Name"]
                        };
                        courses.Add(course);
                    }
                }
            }

            return courses;
        }

    }
}

