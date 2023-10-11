create database prachiAssignment_3

use prachiAssignment_3
/* Creating Employee Table */
create table employees(
empno numeric(4) not null,
ename varchar(40),   
job varchar(200),   		
mrg_id numeric(4),   	
hiredate date,
sal int,    
comm int,   
deptno numeric(2)
)

insert into employees(empno,ename,job,mrg_id,hiredate,sal,comm,deptno)
values
(7369, 'SMITH', 'CLERK', 7902, '1980-12-17', 800, NULL, 20),
(7499, 'ALLEN', 'SALESMAN', 7698, '1981-02-20', 1600, 300, 30),
(7521, 'WARD', 'SALESMAN', 7698, '1981-02-22', 1250, 500, 30),
(7566, 'JONES', 'MANAGER', 7839, '1981-04-02', 2975, NULL, 20),
(7654, 'MARTIN', 'SALESMAN', 7698, '1981-09-28', 1250, 1400, 30),
(7698, 'BLAKE', 'MANAGER', 7839, '1981-05-01', 2850, NULL, 30),
(7782, 'CLARK', 'MANAGER', 7839, '1981-06-09', 2450, NULL, 10),
(7788, 'SCOTT', 'ANALYST', 7566, '1987-04-19', 3000, NULL, 20),
(7839, 'KING', 'PRESIDENT', NULL, '1981-11-17', 5000, NULL, 10),
(7844, 'TURNER', 'SALESMAN', 7698, '1981-09-08', 1500, 0, 30),
(7876, 'ADAMS', 'CLERK', 7788, '1987-05-23', 1100, NULL, 20),
(7900, 'JAMES', 'CLERK', 7698, '1981-12-03', 950, NULL, 30),
(7902, 'FORD', 'ANALYST', 7566, '1981-12-03', 3000, NULL, 20),
(7934, 'MILLER', 'CLERK', 7782, '1982-01-23', 1300, NULL, 10)

select *from employees

-------------- 1. Retrieve a list of MANAGERS.

select * from employees where job='MANAGER'

--------------2. Find out the names and salaries of all employees earning more than 1000 per month.

select ename,sal from employees where sal>1000

-------------3. Display the names and salaries of all employees except JAMES. 

select ename,sal from employees where ename !='JAMES'

-------------4. Find out the details of employees whose names begin with ‘S’. 

select * from employees where ename like 'S%'

-------------5. Find out the names of all employees that have ‘A’ anywhere in their name. 

select * from employees where ename like '%A%'

-------------6. Find out the names of all employees that have ‘L’ as their third character in their name

select * from employees where ename like '__L%'

-------------7. Compute daily salary of JONES. 

select (sal/30) as "Daily Salary" from employees where ename='JONES'

-------------8. Calculate the total monthly salary of all employees. 

select sum(sal) as "Total Salary" from employees

-------------9. Print the average annual salary . 

select (AVG(sal)*12) as "Average Annual Salary" from employees 

-------------10. Select the name, job, salary, department number of all employees except SALESMAN from department number 30.

select ename,job,sal,deptno from employees where job not in (select job from employees where deptno=30)

-------------11. List unique departments of the EMP table. 

select distinct deptno from employees

-------------12. List the name and salary of employees who earn more than 1500 and are in department 10 or 30. Label the columns Employee and Monthly Salary respectively.

select ename as "Employee",sal as "Monthly Salary" from employees where sal >1500 and (deptno=10 or deptno=30)

-------------13. Display the name, job, and salary of all the employees whose job is MANAGER or ANALYST and their salary is not equal to 1000, 3000, or 5000. 

select ename,job,sal from employees where job='MANAGER' or job ='ANALYST' and sal !=1000 or sal !=3000 or sal != 5000

-------------14. Display the name, salary and commission for all employees whose commission amount is greater than their salary increased by 10%. 

select ename,sal,comm from employees where comm>(sal*1.10)

-------------15. Display the name of all employees who have two Ls in their name and are in department 30 or their manager is 7782.

select ename from employees where ename like '%L%L' and deptno=30 or mrg_id=7782

-------------16. Display the names of employees with experience of over 30 years and under 40 yrs.Count the total number of employees. 
select ename from employees where ('2023'-YEAR(hiredate))>30 and ('2023'-YEAR(hiredate))<40
select count(*) as "total number of employee" from employees where (('2023'-YEAR(hiredate))>30 and ('2023'-YEAR(hiredate))<40)

-------------17. Retrieve the names of departments in ascending order and their employees in descending order.
select ename,deptno from employees where ename is not null order by deptno asc, ename desc

------------18. Find out experience of MILLER. 
select YEAR('2023')-YEAR(hiredate) as "Experience" from employees where ename='Miller'

