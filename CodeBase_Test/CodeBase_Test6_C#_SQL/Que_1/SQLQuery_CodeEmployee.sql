/*I
a. Create a table called Code_Employee(empno int primary key,
   empname varchar(35), (is a required field)
  empsal numeric(10,2) - (check empsal >=25000)
  emptype char(1) ) (either 'F' for fulltime or 'P' part time) (Empty Table)
b. Create a stored procedure to add new employee records. The procedure should accept all the employee details as input parameters,
except empno. Generate the new employee no in the procedure and then insert the record
Test the procedure
c. Using Ado.net classes/methods, insert employee record in the table by invoking the procedure  
d. Display all the records (including the newely added record)*/

create database prachi_codebase6
use prachi_codebase6


---- a)Create a table called Code_Employee

create table Code_Employee
(
    empno int primary key,
    empname varchar(35) NOT NULL,
    empsal numeric(10,2) check (empsal >= 25000),
    emptype char(1) check (emptype IN ('F', 'P'))
);
select * from Code_Employee

---- b)Create a stored procedure to add new employee records.
create procedure AddEmployee
    @empname VARCHAR(35),
    @empsal NUMERIC(10,2),
    @emptype CHAR(1)
as
begin
    declare @newEmpNo int;

    -- Generate a new employee number
    set @newEmpNo = (select isnull(max(empno), 0) + 1 from Code_Employee);

    -- Insert the record
    insert into Code_Employee (empno, empname, empsal, emptype)
    values (@newEmpNo, @empname, @empsal, @emptype);
end;


 
 ---- test the stored procedure
 -- Execute the stored procedure to add a new employee
exec AddEmployee 'Prachi Baranwal', 80000.00, 'F';

select * from Code_Employee

