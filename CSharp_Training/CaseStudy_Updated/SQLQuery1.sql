create database cs_p
use cs_p

CREATE TABLE Students (
    student_id INT PRIMARY KEY,
    student_name NVARCHAR(100),
    student_dob DATE
);

CREATE TABLE Courses (
    course_id INT PRIMARY KEY,
    course_name NVARCHAR(100)
);

CREATE TABLE Enrollments (
    enrollment_id INT PRIMARY KEY IDENTITY(1,1),
    student_id INT,
    course_id INT,
    enrollment_date DATETIME,
    FOREIGN KEY (student_id) REFERENCES Students(student_id),
    FOREIGN KEY (course_id) REFERENCES Courses(course_id)
);

select * from Students
select * from Courses