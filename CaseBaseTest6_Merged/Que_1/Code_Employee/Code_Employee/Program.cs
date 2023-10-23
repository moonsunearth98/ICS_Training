using System;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeManagementApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=ICS-LT-5NW1ZD3\\SQLEXPRESS;Database=prachi_codebase6;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("AddEmployee", connection))
                {
                    Console.WriteLine("Enter Emlpoyee Name");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter the Employee Salary");
                    decimal sal = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Employee Type P or F");
                    char type = Convert.ToChar(Console.Read());

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@empname", name);
                    command.Parameters.AddWithValue("@empsal", sal);
                    command.Parameters.AddWithValue("@emptype", type);

                    command.ExecuteNonQuery();
                }
                
            }

            Console.WriteLine("Employee added successfully.");

            // Display all records
            DisplayAllEmployeeRecords(connectionString);
            Console.Read();
        }

        // Define the DisplayAllEmployeeRecords method outside of Main
        static void DisplayAllEmployeeRecords(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Code_Employee", connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Employee ID: {reader["empno"]}, Name: {reader["empname"]}, Salary: {reader["empsal"]}, Type: {reader["emptype"]}");
                    }
                }
                Console.ReadLine();
            }
        }
    }
}
