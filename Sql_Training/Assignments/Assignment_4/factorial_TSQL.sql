/*--1.Write a T-SQL Program to find the factorial of a given number.*/

create database TSQL_Assignment4;
use TSQL_Assignment4;

begin
-- Declare a variable to store the user's input
declare @n int;
-- Prompt the input. You can replace 7 with the number for which you want to find the factorial
set @n = 8; 
-- Initialize variables
declare @fact bigint=1;
declare @i int =1;
-- Calculate the factorial using a FOR loop
while @i<=@n
begin
  set @fact=@fact*@i;
  set @i=@i+1;
end
-- Print the factorial
print 'Factorial of ' + cast(@n as nvarchar(10)) + ' is ' + cast(@fact as nvarchar(20));
end