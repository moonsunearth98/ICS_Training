

--3.  Create a trigger to restrict data manipulation on EMP table during General holidays. Display the error message like “Due to Independence day you cannot manipulate data” or "Due To Diwali", you cannot manupulate" etc Note: Create holiday table as (holiday_date,Holiday_name) store at least 4 holiday details. try to match and stop manipulation 

create table Holidays
(holiday_date Date Primary Key, holiday_name nvarchar(max));

 

INSERT INTO HOLIDAYs values
('2023-01-01','NewYear'),
('2023-08-15','Independence Day'),
('2023-10-27','Diwali'),
('2023-12-25','Christmas'),
('2023-10-16','Homieday');

update Holidays
set holiday_name='Navrati Day-1'
where holiday_date='2023-10-16';


 

CREATE TRIGGER RestrictDataholiday
ON employees
FOR INSERT, UPDATE, DELETE 
AS 
BEGIN     
DECLARE @Holiday_name VARCHAR(50), @holiday_date DATE
SET @holiday_date = CONVERT(DATE, GETDATE())
SELECT @Holiday_name = Holiday_name     
FROM Holidays     
WHERE holiday_date = @holiday_date 
IF @holiday_name IS NOT NULL     
BEGIN         
ROLLBACK TRANSACTION        
RAISERROR('Due to %s, you cannot manipulate data', 16, 1, @holiday_name)     
END 
END

select * from employees

 

insert into employees values(8001,'Prachi', 'Developer', 9200,'2022-12-20',9880,null,10)
