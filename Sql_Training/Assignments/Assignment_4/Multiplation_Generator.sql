/*--2.Create a stored procedure to generate multiplication tables up to a given number.*/

create procedure GenerateMultiplicationTable
@n int
as 
begin
  declare @i int=1;
  while @i<=@n
  begin
  declare @j int =1;
        while @j<=@n
        begin
        Print cast(@i as nvarchar(10))+' x '+cast(@j as nvarchar(10))+' = ' + cast(@i * @j as nvarchar(10));
        set @j=@j+1;
        end
  set @i=@i+1;
  end
end;

 -- Replace 8 with the desired number
exec GenerateMultiplicationTable @n = 8; 