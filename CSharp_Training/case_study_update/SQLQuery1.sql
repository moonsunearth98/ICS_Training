create database studentdb;
use studentdb;

create table students
(
student_id int primary key,
student_name varchar(30),
student_dob varchar(30),
course_id int foreign key references course(course_id)
);

create table course
(
course_id int primary key,
course_name varchar(30)
);

select * from students;
select * from course;