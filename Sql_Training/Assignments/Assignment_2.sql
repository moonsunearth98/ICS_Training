/*SQL Exercises 
Two tables to be created in the database that may be used for the following exercises. 
Their structure is as follows: 
EMP(empno, ename, job, mgr-id, hiredate, sal, comm., deptno) 
DEPT(deptno, dname, loc) 
*/

/* Creating Database */

create database prachib_assignment2
use prachib_assignment2

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

/* --------------------------Creating Department Table---------------------------------*/

create table department(
deptno numeric(2),
d_name varchar(30),
loc varchar(30)
)

insert into department(deptno,d_name,loc)
values
(10,' ACCOUNTING','NEW YORK'),
(20,'RESEARCH',' DALLAS'),
(30,'SALES','CHICAGO'),
(40,'OPERATIONS','BOSTON')

select * from department

/*-----------------------1. List all employees whose name begins with 'A'.--------------------------------- */

select * from employees where ename like 'A%'

/*-----------------------2. Select all those employees who don't have a manager.--------------------------- */

select * from employees where mrg_id is null
select * from employees where job = 'MANAGER'

/*---------------------- 3. List employee name, number and salary for those employees who earn in the range 1200 to 1400. */

select ename,empno,sal from employees where sal between 1200 and 1400

/*4. Give all the employees in the RESEARCH department a 10% pay rise. Verify that this has been done by listing all their details before and after the rise. */

-- List employee details before the pay rise---

select ename,sal as "Before Pay Rise" from employees where deptno = 20 

-- List employee details after the pay rise--

select ename,sal*1.10 as "After Pay Rise" from employees where deptno=20

/*-----5. Find the number of CLERKS employed. Give it a descriptive heading.----*/

select count(*) as "Number of Clerks" from employees where job='Clerk'

/*----6. Find the average salary for each job type and the number of people employed in each job. ---*/

select job,avg(sal) as "average salary",count(*) as "Number of Employees" from employees group by job

/*--------------7. List the employees with the lowest and highest salary. -----------------*/

select ename,sal from employees  where sal =(select min(sal) from employees)
union all 
select ename,sal from employees where sal=(select max(sal) from employees)

/*-------------8. List full details of departments that don't have any employees. --------*/
select * from department where deptno not in (select distinct deptno from employees)

/*------------9. Get the names and salaries of all the analysts earning more than 1200 who are based in department 20. Sort the answer by ascending order of name.------*/

select ename,sal from employees where job = 'Analyst' and sal > 1200 and deptno=20 order by ename asc

/*-----------10. For each department, list its name and number together with the total salary paid to employees in that department. ---------------------*/

select d.d_name as "Department Name",d.deptno as "Department Number" , sum(e.sal) as "Total Salary" from department d
left join employees e on d.deptno=e.deptno group by d.d_name,d.deptno

/*----------11. Find out salary of both MILLER and SMITH.----------------*/

select ename,sal from employees where ename='Miller'
union all
select ename,sal from employees where ename='Smith'

/*-----------12. Find out the names of the employees whose name begin with ‘A’ or ‘M’. ------*/

select ename, sal from employees where ename like 'A%'
union all
select ename,sal from employees where ename like 'M%'

/*-----13. Compute yearly salary of SMITH. -----*/

select ename,sal*12 as "Yearly Salary" from employees where ename='SMITH' 

/*-------14. List the name and salary for all employees whose salary is not in the range of 1500 and 2850. ----*/

select ename,sal from employees where sal not between 1500 and 2850

/*------15. Find all managers who have more than 2 employees reporting to them-----*/

select m.ename AS "Manager Name", COUNT(e.empno) AS "Number of Direct Reports" from employees m
inner join employees e on m.empno = e.mrg_id
group by m.ename
having count(e.empno) > 2;

