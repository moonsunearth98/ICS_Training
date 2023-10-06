/*A small IT firm designing business software for its clients wants to store and manage its data.
It has identified following entities for which, it will maintain data.
Clients
Employees
Departments
Projects
EmpProjectTasks * 
* This will hold data of employees working on projects.
You are required to create the tables using the information provided below. Once tables are ready, fill in the given data in each table.
NOTE: Submit the CREATE TABLE, INSERT and SELECT commands as answer to this assignment.
The tables below describe attributes for each entity.*/


create database prachi_assignment1
use prachi_assignment1

/* Creating clients table */

create table clients(
c_id numeric(4) primary key,
c_name varchar(40) not null,
c_address varchar(30),
c_email varchar(30) unique,
c_phone numeric(10),
c_business varchar(20) not null
)

insert into clients(c_id,c_name,c_address,c_email,c_phone,c_business)
values
(1001,'ACME Utilities','Noida','contact@acmeutil.com',9567880032,'Manufacturing'),
(1002,'Trackon Consultants','Mumbai','consult@trackon.com',8734210090,'Consultant'),
(1003,'MoneySaver Distributors','Kolkata','save@moneysaver.com',7799886655,'Reseller'),
(1004,'Lawful Corp','Chennai','justice@lawful.com',9210342219,'Professional')

select * from clients

/* Creating Departments Table */

create table departments(
deptno numeric(2) primary key,
dname varchar(15) not null,
loc varchar(20)
)

insert into departments(deptno,dname,loc)
values
(10,'Design','Pune'),
(20,'Development','Pune'),
(30,'Testing','Mumbai'),
(40,'Document','Mumbai')

select * from departments

/* Creating Employees Table */

create table employees(
emp_num numeric(4) primary key,
emp_name varchar(20) not null,
emp_job varchar(15),
emp_salary numeric(7) check(emp_salary>=0),
deptno numeric(2),
foreign key (deptno) references departments(deptno)
)

insert into employees(emp_num,emp_name,emp_job,emp_salary,deptno)
values
(7001,'Sandeep','Analyst',25000,10),
(7002,'Rajesh','Analyst',25000,10),
(7003,'Madhav','Analyst',25000,10),
(7004,'Manoj','Analyst',25000,10),
(7005,'Abhay','Analyst',25000,10),
(7006,'Uma','Analyst',25000,10),
(7007,'Gita','Analyst',25000,10),
(7008,'Priya','Tester',35000,30),
(7009,'Nutan','Developer',45000,20),
(7010,'Smita','Analyst',20000,10),
(7011,'Anand','Project Mgr',65000,10)

select * from employees

/* Creating Projects Table */

create table projects(
project_id numeric(3) primary key,
descr varchar(30) not null,
st_date date,
end_date date ,
actual_end_date date,
budget numeric(10) check(budget>0),
c_id numeric(4), 
foreign key (c_id) references clients(c_id)
)

insert into projects(project_id,descr,st_date,end_date,actual_end_date,budget,c_id)
values
(401,'Inventory','01-Apr-11','01-Oct-11','31-Oct-11',150000,1001),
(402,'Accounting','01-Aug-11','01-Jan-12',null,500000,1002),
(403,'Payroll','01-Oct-11','31-Dec-11',null,75000,1003),
(404,'Contact Mgmt','01-Nov-11','31-Dec-11',null,50000,1004)

select * from projects

/* Creating Employees Project Task */

create table empprojectasks(
project_id numeric(3),
emp_num numeric (4),
s_date date,
end_date date,
task varchar(25) not null,
status varchar(15) not null,
foreign key (project_id) references projects(project_id),
foreign key (emp_num) references employees(emp_num),
primary key (project_id,emp_num)
)

insert into empprojectasks(project_id,emp_num,s_date,end_date,task,status)
values
(401,7001,'01-Apr-11','20-Apr-11','System Analysis','Completed'),
(401,7002,'21-Apr-11','30-May-11','System Design','Completed'),
(401,7003,'01-Jun-11','15-Jul-11','Coding','Completed'),
(401,7004,'18-Jul-11','01-Sep-11','Coding','Completed'),
(401,7005,'03-Sep-11','15-Sep-11','Testing','Completed'),
(401,7006,'18-Sep-11','05-Oct-11','Code Change','Completed'),
(401,7007,'06-Oct-11','16-Oct-11','Testing','Completed'),
(401,7008,'06-Oct-11','22-Oct-11','Documentation','Completed'),
(401,7009,'22-Oct-11','31-Oct-11','Sign off','Completed'),
(402,7010,'01-Aug-11','20-Aug-11','System Analysis','Completed'),
(402,7002,'22-Aug-11','30-Sep-11','System Design','Completed'),
(402,7004,'01-Oct-11',null,'Coding','In Progress')

select * from empprojectasks