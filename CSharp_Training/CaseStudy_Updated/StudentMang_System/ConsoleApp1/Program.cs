using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementSystem
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Student(int id, string name, DateTime dateOfBirth)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
        }
    }

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

    public class AppEngine
    {
        public string connectionString;

        public AppEngine()
        {
            // Initialize the connection string from the configuration.
            connectionString = ConfigurationManager.ConnectionStrings["StudentDB"].ConnectionString;
        }

        public void IntroduceCourse(Course course)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Courses (course_id, course_name) VALUES (@CourseId, @CourseName)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@CourseId", course.CourseId);
                command.Parameters.AddWithValue("@CourseName", course.CourseName);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void RegisterStudent(Student student)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Students (student_id, student_name, student_dob) VALUES (@Id, @Name, @DateOfBirth)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Id", student.Id);
                command.Parameters.AddWithValue("@Name", student.Name);
                command.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Course[] ListCourses()
        {
            List<Course> courses = new List<Course>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Courses";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {   
                        Course course = new Course(
                        (int)reader["course_id"],
                        (string)reader["course_name"]
                         );
                        courses.Add(course);
                    }
                }
            }

            return courses.ToArray();
        }

        public Student[] ListStudents()
        {
            List<Student> students = new List<Student>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Students";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    //while (reader.Read())
                    //{
                    //    Student student = new Student
                    //    {
                    //        Id = (int)reader["student_id"],
                    //        Name = (string)reader["student_name"],
                    //        DateOfBirth = (DateTime)reader["student_dob"]
                    //    };
                    //    students.Add(student);
                    //}
                    Student student = new Student(
      (int)reader["student_id"],
      (string)reader["student_name"],
      (DateTime)reader["student_dob"]
  );
                    students.Add(student);
                }
            }

            return students.ToArray();
        }

        public void EnrollStudent(int studentId, int courseId)
        {
            Student studentToEnroll = ListStudents().FirstOrDefault(s => s.Id == studentId);
            Course courseToEnroll = ListCourses().FirstOrDefault(c => c.CourseId == courseId);

            if (studentToEnroll != null && courseToEnroll != null)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Enrollments (student_id, course_id, enrollment_date) VALUES (@StudentId, @CourseId, @EnrollmentDate)";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@StudentId", studentToEnroll.Id);
                    command.Parameters.AddWithValue("@CourseId", courseToEnroll.CourseId);
                    command.Parameters.AddWithValue("@EnrollmentDate", DateTime.Now);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                Console.WriteLine($"Enrollment successful: '{studentToEnroll.Name}' in '{courseToEnroll.CourseName}'");
            }
            else
            {
                Console.WriteLine("Student or course not found.");
            }
        }

        public Enrollment[] ListEnrollments()
        {
            List<Enrollment> enrollments = new List<Enrollment>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Students.student_id, student_name, student_dob, course_id, course_name, enrollment_date " +
                               "FROM Enrollments " +
                               "INNER JOIN Students ON Enrollments.student_id = Students.student_id " +
                               "INNER JOIN Courses ON Enrollments.course_id = Courses.course_id";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                   
                    Student student = new Student(
                    (int)reader["student_id"],
                    (string)reader["student_name"],
                    (DateTime)reader["student_dob"]
                     );

                    Course course = new Course(
                        (int)reader["course_id"],
                        (string)reader["course_name"]
                    );

                    DateTime enrollmentDate = (DateTime)reader["enrollment_date"];

                    enrollments.Add(new Enrollment(student, course, enrollmentDate));
                }
            }

            return enrollments.ToArray();
        }
    }

    public class Info
    {
        public void DisplayEnrollments(Enrollment[] enrollments)
        {
            Console.WriteLine("\nEnrollment Details:");
            Console.WriteLine("---------------------------------------------------------------------");
            foreach (Enrollment enrollment in enrollments)
            {
                Console.WriteLine($"Student ID: {enrollment.Student.Id}");
                Console.WriteLine($"Student Name: {enrollment.Student.Name}");
                Console.WriteLine($"Course ID: {enrollment.Course.CourseId}");
                Console.WriteLine($"Course Name: {enrollment.Course.CourseName}");
                Console.WriteLine($"Enrollment Date: {enrollment.EnrollmentDate.ToShortDateString()}");
                Console.WriteLine("---------------------------------------------------------------------");
            }
        }
    }

    public abstract class UserInterface
    {
        public AppEngine engine;


        public UserInterface(AppEngine engine)
        {
            this.engine = engine;
        }

        public void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("  ----------------------------------------------- ");
            Console.WriteLine("|| Welcome to My Student Management System (SMS) ||");
            Console.WriteLine("  ----------------------------------------------- ");
            Console.WriteLine("1. Student");
            Console.WriteLine("2. Admin");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");
        }

        public void ShowAdminMenu()
        {
            Console.Clear();
            Console.WriteLine("Admin Menu");
            Console.WriteLine("1. Introduce New Course");
            Console.WriteLine("2. Show All Courses");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");
        }

        public void ShowStudentMenu()
        {
            Console.Clear();
            Console.WriteLine("Student Menu");
            Console.WriteLine("1. Register Student");
            Console.WriteLine("2. Enroll Student in Course");
            Console.WriteLine("3. Show All Students");
            Console.WriteLine("4. Show Enrollments");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");
        }

        public abstract void Run();
    }

    public class ConsoleUserInterface : UserInterface
    {
        public ConsoleUserInterface(AppEngine engine) : base(engine)
        {
        }

        public override void Run()
        {
            while (true)
            {
                ShowMainMenu();
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            RunStudentMenu();
                            break;
                        case 2:
                            RunAdminMenu();
                            break;
                        case 3:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        public void RunAdminMenu()
        {
            while (true)
            {
                ShowAdminMenu();
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            IntroduceNewCourse();
                            break;
                        case 2:
                            ShowAllCourses();
                            break;
                        case 3:
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        public void RunStudentMenu()
        {
            while (true)
            {
                ShowStudentMenu();
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            RegisterStudent();
                            break;
                        case 2:
                            EnrollStudentInCourse();
                            break;
                        case 3:
                            ShowAllStudents();
                            break;
                        case 4:
                            ShowEnrollments();
                            break;
                        case 5:
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        public void RegisterStudent()
        {
            Console.Clear();
            Console.Write("Enter Student ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Console.Write("Enter Student Name: ");
                string name = Console.ReadLine();
                engine.RegisterStudent(new Student(id, name, DateTime.Now));
                Console.WriteLine("Student registered successfully. Press Enter to continue...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        public void IntroduceNewCourse()
        {
            Console.Clear();
            Console.Write("Enter Course ID: ");
            if (int.TryParse(Console.ReadLine(), out int courseId))
            {
                Console.Write("Enter Course Name: ");
                string courseName = Console.ReadLine();
                engine.IntroduceCourse(new Course(courseId, courseName));
                Console.WriteLine("Course introduced successfully. Press Enter to continue...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        public void ShowAllCourses()
        {
            Console.Clear();
            Console.WriteLine("All Courses:");
            Course[] courses = engine.ListCourses();
            foreach (var course in courses)
            {
                Console.WriteLine($"Course ID: {course.CourseId}, Name: {course.CourseName}");
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        public void EnrollStudentInCourse()
        {
            Console.Clear();
            Console.Write("Enter Student ID to enroll: ");
            if (int.TryParse(Console.ReadLine(), out int studentId))
            {
                Console.Write("Enter Course ID to enroll in: ");
                if (int.TryParse(Console.ReadLine(), out int courseId))
                {
                    engine.EnrollStudent(studentId, courseId);
                    Console.WriteLine("Enrollment successful. Press Enter to continue...");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid Course ID.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid Student ID.");
            }
        }

        public void ShowAllStudents()
        {
            Console.Clear();
            Console.WriteLine("All Students:");
            Student[] students = engine.ListStudents();
            foreach (var student in students)
            {
                Console.WriteLine($"Student ID: {student.Id}, Name: {student.Name}");
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        public void ShowEnrollments()
        {
            Console.Clear();
            Enrollment[] enrollments = engine.ListEnrollments();
            Info info = new Info();
            info.DisplayEnrollments(enrollments);
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }

    class MainProgram
    {
        static void Main(string[] args)
        {
            AppEngine engine = new AppEngine();
            UserInterface userInterface = new ConsoleUserInterface(engine);
            userInterface.Run();
        }
    }
}
