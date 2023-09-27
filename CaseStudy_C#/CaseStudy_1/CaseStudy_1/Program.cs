using System;


class Student
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

class Info
{
    public void Display(Student student)
    {
        Console.WriteLine($"Student ID: {student.Id}");
        Console.WriteLine($"Student Name: {student.Name}");
        Console.WriteLine($"Date of Birth: {student.DateOfBirth.ToShortDateString()}");
    }
}

class App
{
    static void Main(string[] args)
    {
        Scenario1();
        Scenario2();
    }

    static void Scenario1()
    {
        Student student1 = new Student(1, "Prachi", new DateTime(2001, 06, 27));
        Student student2 = new Student(2, "Puru", new DateTime(1999, 8, 25));
        Info info = new Info();
        info.Display(student1);
        info.Display(student2);
    }
    static void Scenario2()
    {

        Student[] students = new Student[3];
        students[0] = new Student(101, "Prishu", new DateTime(2001, 3, 10));
        students[1] = new Student(102, "Poorvi", new DateTime(2002, 7, 5));
        students[2] = new Student(103, "Ved", new DateTime(2003, 12, 20));
        Info info = new Info();
        foreach (Student student in students)

        {
            info.Display(student);
            Console.WriteLine(); 
        }
        Console.ReadLine();
    }
}