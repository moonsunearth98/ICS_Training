using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Case_Study
{
    public class UserInterface : IUserInterface
    {
        private AppEngine appEngine;

        public UserInterface(AppEngine appEngine)
        {
            this.appEngine = appEngine;
        }

        public void ShowFirstScreen()
        {
            Console.WriteLine("Welcome to SMS (Student Management System)");
            Console.WriteLine("Tell us who you are: \n1. Student\n2. Admin\n3. Exit");
            Console.Write("Enter your choice (1, 2, or 3): ");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    ShowStudentScreen();
                    break;
                case 2:
                    ShowAdminScreen();
                    break;
                case 3:
                    Console.WriteLine("Exiting the program.");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
                    ShowFirstScreen();
                    break;
            }
        }

        public void ShowStudentScreen()
        {
            Console.WriteLine("Student Menu:");
            Console.WriteLine("1. Show all Courses");
            Console.WriteLine("2. Register for a Course");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice (1, 2, or 3): ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ShowAllCoursesScreen();
                    break;
                case 2:
                    ShowStudentRegistrationScreen();
                    break;
                case 3:
                    Console.WriteLine("Exiting Student Name Menu.");
                    ShowFirstScreen();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option 1, 2, or 3.");
                    ShowStudentScreen();
                    break;
            }
        }

        public void ShowAdminScreen()
        {
            Console.WriteLine("Admin Menu:");
            Console.WriteLine("1. Introduce New Course");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice (1-3): ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    IntroduceNewCourseScreen();
                    break;
                case 2:
                    ShowAllStudentsScreen();
                    break;
                case 3:
                    Console.WriteLine("Exiting Admin Menu.");
                    ShowFirstScreen();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option 1, 2, or 3.");
                    ShowAdminScreen();
                    break;
            }
        }

        public void ShowAllStudentsScreen()
        {
            Console.WriteLine("List of Students:");
            string cs = ConfigurationManager.ConnectionStrings["student_registration"].ConnectionString;
            SqlConnection con = null;

            try
            {
                using (con = new SqlConnection(cs))
                {
                    string query = "select * from StudentManagementDB";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Console.WriteLine("Student ID: " + dr[0]);
                        Console.WriteLine("Student Name: " + dr[1]);
                        Console.WriteLine("Student Date of Birth: " + dr[2]);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

            Console.WriteLine("Press Enter to return to the previous menu");
            Console.ReadLine();
            ShowAdminScreen();
        }

        public void ShowStudentRegistrationScreen()
        {
            string cs = ConfigurationManager.ConnectionStrings["student_registration"].ConnectionString;
            SqlConnection con = null;

            try
            {
                using (con = new SqlConnection(cs))
                {
                    Console.WriteLine("Enter the student ID: ");
                    string studentId = Console.ReadLine();
                    Console.WriteLine("Enter the student name: ");
                    string studentName = Console.ReadLine();
                    Console.WriteLine("Enter the student date of birth (yyyy-MM-dd): ");
                    string dateOfBirth = Console.ReadLine();
                    Console.WriteLine("Enter the course you want to join: ");
                    string courseId = Console.ReadLine();

                    string query = "insert into Students values (@studentId, @studentName, @dateOfBirth, @courseId)";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@studentId", studentId);
                    cmd.Parameters.AddWithValue("@studentName", studentName);
                    cmd.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
                    cmd.Parameters.AddWithValue("@courseId", courseId);

                    con.Open();
                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        Console.WriteLine("The student has been added to the database.");
                    }
                    else
                    {
                        Console.WriteLine("Data insertion failed.");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

            Console.WriteLine("Press Enter to return to the previous menu...");
            Console.ReadLine();
            ShowStudentScreen();
        }

        public void IntroduceNewCourseScreen()
        {
            string cs = ConfigurationManager.ConnectionStrings["student_registration"].ConnectionString;
            SqlConnection con = null;

            try
            {
                using (con = new SqlConnection(cs))
                {
                    Console.WriteLine("Enter the course ID: ");
                    string courseId = Console.ReadLine();
                    Console.WriteLine("Enter the course name: ");
                    string courseName = Console.ReadLine();

                    string query = "insert into course values (@courseId, @courseName)";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@courseId", courseId);
                    cmd.Parameters.AddWithValue("@courseName", courseName);

                    con.Open();
                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        Console.WriteLine("The course has been added to the database.");
                    }
                    else
                    {
                        Console.WriteLine("Data insertion failed.");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

            Console.WriteLine("Press Enter to return to the previous menu...");
            Console.ReadLine();
            ShowAdminScreen();
        }

        public void ShowAllCoursesScreen()
        {
            Console.WriteLine("List of Courses:");
            string cs = ConfigurationManager.ConnectionStrings["student_registration"].ConnectionString;
            SqlConnection con = null;

            try
            {
                using (con = new SqlConnection(cs))
                {
                    string query = "select * from course";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Console.WriteLine("Course ID: " + dr[0]);
                        Console.WriteLine("Course Name: " + dr[1]);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

            Console.WriteLine("Press Enter to return to the previous menu...");
            Console.ReadLine();
            ShowStudentScreen();
        }
    }
}
