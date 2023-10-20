using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6
{
    class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee>
        {
            new Employee { EmployeeID = 1012, FirstName = "Prachi", LastName = "Baranwal", Title = "Manager", DOB = new DateTime(2001, 06, 27), DOJ = new DateTime(2011, 8, 6), City = "Mumbai" },
            new Employee { EmployeeID = 1002, FirstName = "Puru", LastName = "Baranwal", Title = "AsstManager", DOB = new DateTime(1984, 8, 20), DOJ = new DateTime(2012, 7, 7), City = "Mumbai" },
            new Employee { EmployeeID = 1003, FirstName = "Poorvi", LastName = "Baranwal", Title = "Consultant", DOB = new DateTime(1987, 11, 14), DOJ = new DateTime(2015, 12, 4), City = "Pune" },
            new Employee { EmployeeID = 1004, FirstName = "Prishu", LastName = "Baranwal", Title = "SE", DOB = new DateTime(1990, 6, 3), DOJ = new DateTime(2016, 2, 2), City = "Pune" },
            new Employee { EmployeeID = 1005, FirstName = "Ved", LastName = "Baranwal", Title = "SE", DOB = new DateTime(1991, 3, 8), DOJ = new DateTime(2016, 2, 2), City = "Mumbai" },
            new Employee { EmployeeID = 1006, FirstName = "Ishani", LastName = "Verma", Title = "Consultant", DOB = new DateTime(1989, 11, 7), DOJ = new DateTime(2014, 8, 8), City = "Chennai" },
            new Employee { EmployeeID = 1007, FirstName = "Aditi", LastName = "Srivstava", Title = "Consultant", DOB = new DateTime(1989, 12, 2), DOJ = new DateTime(2015, 1, 6), City = "Mumbai" },
            new Employee { EmployeeID = 1008, FirstName = "Palak", LastName = "Agrawal", Title = "Associate", DOB = new DateTime(1993, 11, 11), DOJ = new DateTime(2014, 6, 11), City = "Chennai" },
            new Employee { EmployeeID = 1009, FirstName = "Shikha", LastName = "Kumari", Title = "Associate", DOB = new DateTime(1992, 12, 8), DOJ = new DateTime(2014, 3, 12), City = "Chennai" },
            new Employee { EmployeeID = 1010, FirstName = "Sumit", LastName = "Yadav", Title = "Manager", DOB = new DateTime(1991, 4, 12), DOJ = new DateTime(2016, 2, 1), City = "Pune" }
        };

            // 1. Display a list of all employees who have joined before 1/1/2015
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("------------------------------------------------------");

            var joinedBefore2015 = empList.Where(e => e.DOJ < new DateTime(2015, 1, 1));
            Console.WriteLine("Employees joined before 1/1/2015:");
            foreach (var employee in joinedBefore2015)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName}");
            }
            Console.WriteLine("------------------------------------------------------");

            // 2. Display a list of all employees whose date of birth is after 1/1/1990
            var dobAfter1990 = empList.Where(e => e.DOB > new DateTime(1990, 1, 1));
            Console.WriteLine("\nEmployees with DOB after 1/1/1990:");
            foreach (var employee in dobAfter1990)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName}");
            }
            Console.WriteLine("------------------------------------------------------");


            // 3. Display a list of all employees whose designation is Consultant or Associate
            var consultantsAndAssociates = empList.Where(e => e.Title == "Consultant" || e.Title == "Associate");
            Console.WriteLine("\nConsultants and Associates:");
            foreach (var employee in consultantsAndAssociates)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName}");
            }
            Console.WriteLine("------------------------------------------------------");

            // 4. Display the total number of employees
            int totalEmployees = empList.Count;
            Console.WriteLine($"\nTotal number of employees: {totalEmployees}");
            Console.WriteLine("------------------------------------------------------");

            // 5. Display the total number of employees belonging to "Chennai"
            int chennaiEmployees = empList.Count(e => e.City == "Chennai");
            Console.WriteLine($"Total number of employees in Chennai: {chennaiEmployees}");
            Console.WriteLine("------------------------------------------------------");

            // 6. Display the highest employee ID from the list
            int highestEmployeeID = empList.Max(e => e.EmployeeID);
            Console.WriteLine($"Highest Employee ID: {highestEmployeeID}");
            Console.WriteLine("------------------------------------------------------");


            // 7. Display the total number of employees who have joined after 1/1/2015
            int joinedAfter2015 = empList.Count(e => e.DOJ > new DateTime(2015, 1, 1));
            Console.WriteLine($"Total employees joined after 1/1/2015: {joinedAfter2015}");
            Console.WriteLine("------------------------------------------------------");


            // 8. Display the total number of employees whose designation is not "Associate"
            int notAssociateEmployees = empList.Count(e => e.Title != "Associate");
            Console.WriteLine($"Total employees with designation other than Associate: {notAssociateEmployees}");
            Console.WriteLine("------------------------------------------------------");


            // 9. Display the total number of employees based on City
            var employeesByCity = empList.GroupBy(e => e.City);
            Console.WriteLine("\nTotal number of employees based on City:");
            foreach (var group in employeesByCity)
            {
                Console.WriteLine($"{group.Key}: {group.Count()}");
            }
            Console.WriteLine("------------------------------------------------------");


            // 10. Display the total number of employees based on City and Title
            var employeesByCityAndTitle = empList.GroupBy(e => new { e.City, e.Title });
            Console.WriteLine("\nTotal number of employees based on City and Title:");
            foreach (var group in employeesByCityAndTitle)
            {
                Console.WriteLine($"{group.Key.City}, {group.Key.Title}: {group.Count()}");
            }
            Console.WriteLine("------------------------------------------------------");

            // 11. Display the youngest employee in the list
            var youngestEmployee = empList.OrderBy(e => e.DOB).First();
            Console.WriteLine($"\nYoungest employee: {youngestEmployee.FirstName} {youngestEmployee.LastName}");
            Console.WriteLine("------------------------------------------------------");
            Console.ReadLine();
        }
    }
}
