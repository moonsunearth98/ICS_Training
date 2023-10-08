/* 3. Now once the collection is created write down and execute the LINQ queries for collection 
as follows :

a. Display detail of all the employee
b. Display details of all the employee whose location is not Mumbai
c. Display details of all the employee whose title is AsstManager
d. Display details of all the employee whose Last Name start with S

*/


using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
{
    public int EmployeeID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Title { get; set; }
    public DateTime DOB { get; set; }
    public DateTime DOJ { get; set; }
    public string City { get; set; }
}

public class Program
{
    public static void Main()
    {
        // Create and populate the Generic List Collection (empList)
        List<Employee> empList = new List<Employee>
        {
           new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager", DOB = DateTime.Parse("16/11/1984"), DOJ = DateTime.Parse("8/6/2011"), City = "Mumbai" },
           new Employee { EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla", Title = "AsstManager", DOB = DateTime.Parse("20/08/1984"), DOJ = DateTime.Parse("7/7/2012"), City = "Mumbai" },
           new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza", Title = "Consultant", DOB = DateTime.Parse("14/11/1987"), DOJ = DateTime.Parse("12/4/2015"), City = "Pune" },
           new Employee { EmployeeID = 1004, FirstName = "Saba", LastName = "Shaikh", Title = "SE", DOB = DateTime.Parse("3/6/1990"), DOJ = DateTime.Parse("2/2/2016"), City = "Pune" },
           new Employee { EmployeeID = 1005, FirstName = "Nazia", LastName = "Shaikh", Title = "SE", DOB = DateTime.Parse("8/3/1991"), DOJ = DateTime.Parse("2/2/2016"), City = "Mumbai" },
           new Employee { EmployeeID = 1006, FirstName = "Amit", LastName = "Pathak", Title = "Consultant", DOB = DateTime.Parse("7/11/1989"), DOJ = DateTime.Parse("8/8/2014"), City = "Chennai" },
           new Employee { EmployeeID = 1007, FirstName = "Vijay", LastName = "Natrajan", Title = "Consultant", DOB = DateTime.Parse("2/12/1989"), DOJ = DateTime.Parse("1/6/2015"), City = "Mumbai" },
           new Employee { EmployeeID = 1008, FirstName = "Rahul", LastName = "Dubey", Title = "Associate", DOB = DateTime.Parse("11/11/1993"), DOJ = DateTime.Parse("6/11/2014"), City = "Chennai" },
           new Employee { EmployeeID = 1009, FirstName = "Suresh", LastName = "Mistry", Title = "Associate", DOB = DateTime.Parse("12/8/1992"), DOJ = DateTime.Parse("3/12/2014"), City = "Chennai" },
           new Employee { EmployeeID = 1010, FirstName = "Sumit", LastName = "Shah", Title = "Manager", DOB = DateTime.Parse("12/4/1991"), DOJ = DateTime.Parse("2/1/2016"), City = "Pune" },
    };

        // a. Display details of all employees
        var allEmployees = empList;
        DisplayEmployees("All Employees:", allEmployees);

        // b. Display details of employees whose location is not Mumbai
        var employeesNotInMumbai = empList.Where(e => e.City != "Mumbai");
        DisplayEmployees("Employees Not in Mumbai:", employeesNotInMumbai);

        // c. Display details of employees with the title "AsstManager"
        var asstManagers = empList.Where(e => e.Title == "AsstManager");
        DisplayEmployees("Asst Managers:", asstManagers);

        // d. Display details of employees whose Last Name starts with "S"
        var employeesWithLastNameStartingWithS = empList.Where(e => e.LastName.StartsWith("S"));
        DisplayEmployees("Employees with Last Name Starting with 'S':", employeesWithLastNameStartingWithS);
    }

    private static void DisplayEmployees(string header, IEnumerable<Employee> employees)
    {
        Console.WriteLine(header);
        foreach (var employee in employees)
        {
            Console.WriteLine($"EmployeeID: {employee.EmployeeID}, Name: {employee.FirstName} {employee.LastName}, Title: {employee.Title}, City: {employee.City}");
        }
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("Enter any Key To show the next Result: ");
        Console.ReadLine();
    }
}