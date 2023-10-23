/*II. Write a Cursor program, that retrieves all the employees and updates salary for all employees 
of Department 10(Accounting) by 15%*/

USE prachiAssignment_3;

-- Declare the variables for the cursor
DECLARE @empno NUMERIC(4);
DECLARE @sal INT;

-- Declare the cursor
DECLARE employee_cursor CURSOR FOR
SELECT empno, sal
FROM employees
WHERE deptno = 10;

-- Open the cursor
OPEN employee_cursor;

-- Fetch the first row
FETCH NEXT FROM employee_cursor INTO @empno, @sal;

-- Loop through the cursor
WHILE @@FETCH_STATUS = 0
BEGIN
    -- Update the salary with a 15% increase
    UPDATE employees
    SET sal = sal * 1.15
    WHERE empno = @empno;

    -- Fetch the next row
    FETCH NEXT FROM employee_cursor INTO @empno, @sal;
END

-- Close and deallocate the cursor
CLOSE employee_cursor;
DEALLOCATE employee_cursor;

-- Select the updated records to verify
SELECT * FROM employees WHERE deptno = 10;
