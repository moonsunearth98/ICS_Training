/**
1. Create an Abstract class Student with  Name, StudentId, Grade as members and also an abstract method Boolean Ispassed(grade) which takes grade as an input and checks whether student passed the course or not.  
Create 2 Sub classes Undergraduate and Graduate that inherits all members of the student and overrides Ispassed(grade) method
For the UnderGrad class, if the grade is above 70.0, then isPassed returns true, otherwise it returns false. For the Grad class, if the grade is above 80.0, then isPassed returns true, otherwise returns false.
Test the above by creating appropriate objects**/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_2
{
    class Student_Grades_Checker
    {
        public abstract class Student
        {
            public string Name;
            public int StudentId;
            public double Grade;

            public abstract bool IsPassed(double grade);
        }

        public class Undergraduate : Student
        {
            public Undergraduate(string name, int studentId, double grade)
            {
                Name = name;
                StudentId = studentId;
                Grade = grade;
            }
            public override bool IsPassed(double grade)
            {
                return grade > 70.0;
            }
        }
        public class Graduate : Student
        {
            public Graduate(string name, int studentId, double grade)
            {
                Name = name;
                StudentId = studentId;
                Grade = grade;
            }
            public override bool IsPassed(double grade)
            {
                return grade > 80.0;
            }
        }
        public class Program
        {
            public static void Main(string[] args)
            {
                Console.Write("Enter Undergraduate student name: ");
                string undergradName = Console.ReadLine();
                Console.Write("Enter Student ID: ");
                int undergradId = int.Parse(Console.ReadLine());
                Console.Write("Enter Grade: ");
                double undergradGrade = double.Parse(Console.ReadLine());
                var undergrad = new Undergraduate(undergradName, undergradId, undergradGrade);
                Console.WriteLine($"Undergraduate Student - Name: {undergrad.Name}, Student ID: {undergrad.StudentId}, Grade: {undergrad.Grade}, Passed: {undergrad.IsPassed(undergrad.Grade)}");
                Console.Write("Enter Graduate student name: ");
                string gradName = Console.ReadLine();
                Console.Write("Enter Student ID: ");
                int gradId = int.Parse(Console.ReadLine());
                Console.Write("Enter Grade: ");
                double gradGrade = double.Parse(Console.ReadLine());
                var grad = new Graduate(gradName, gradId, gradGrade);
                Console.WriteLine($"Graduate Student - Name: {grad.Name}, Student ID: {grad.StudentId}, Grade: {grad.Grade}, Passed: {grad.IsPassed(grad.Grade)}");
                Console.ReadLine();
            }
        }

    }
}
