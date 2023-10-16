create database Assignment_Q3
use prachib_assignment2

create table Holidays_details
(
holiday_date date primary key, 
holiday_name nvarchar(max)
)

insert into Holidays_details 
values
('2023-10-02','Gandhi jayanthi'),
('2023-11-30','Diwali'),
('2023-03-08','Holi'),
('2023-05-11','Eid'),
('2023-12-25', 'Christmas'),
('2023-08-15','Independence Day')

create trigger RestrictDataholiday
on employees
for insert, update, delete 
as
begin    
declare @holiday_name varchar(50), @holiday_date date
set @holiday_date = convert(date, getdate())
select @holiday_name = holiday_name     
from Holidays     
where holiday_date = @holiday_date 
if @holiday_name IS NOT NULL     
begin         
rollback transaction        
raiserror('Due to %s, you cannot manipulate data', 16, 1, @holiday_name)     
end
end

select * from employees;
insert into employees values(8090,'Prachi', 'Developer', 9000,'2021-10-28',7899,null,28)