using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace StudentDatabase
{
    
        public class DatabaseInitializer
        {
            public const string ConnectionString = "Data Source=ICS-LT-5NW1ZD3\SQLEXPRESS;Initial Catalog=pb_CaseSt;Integrated Security=true;"; // Replace with your database connection string

            public static void InitializeDatabase()
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    // Create tables
                //    string createStudentTable = "CREATE TABLE Student (StudentId INT PRIMARY KEY IDENTITY(1, 1), Name NVARCHAR(100) NOT NULL, DateOfBirth DATE NOT NULL);";
                //    string createCourseTable = "CREATE TABLE Course (CourseId INT PRIMARY KEY IDENTITY(1, 1), Name NVARCHAR(100) NOT NULL);";
                //    string createEnrollTable = "CREATE TABLE Enroll (EnrollmentId INT PRIMARY KEY IDENTITY(1, 1), StudentId INT, CourseId INT, EnrollmentDate DATETIME, FOREIGN KEY (StudentId) REFERENCES Student(StudentId), FOREIGN KEY (CourseId) REFERENCES Course(CourseId));";

                //    SqlCommand createStudentCmd = new SqlCommand(createStudentTable, connection);
                //    SqlCommand createCourseCmd = new SqlCommand(createCourseTable, connection);
                //    SqlCommand createEnrollCmd = new SqlCommand(createEnrollTable, connection);

                //    createStudentCmd.ExecuteNonQuery();
                //    createCourseCmd.ExecuteNonQuery();
                //    createEnrollCmd.ExecuteNonQuery();
                //}
            }
        }
        
}
