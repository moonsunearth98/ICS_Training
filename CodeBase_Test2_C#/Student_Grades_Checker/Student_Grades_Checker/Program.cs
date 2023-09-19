using System;


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
