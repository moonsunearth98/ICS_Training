USE prachiAssignment_3;

-- Declare the cursor
DECLARE employee_cursor CURSOR FOR
SELECT empno, sal
FROM employees
WHERE deptno = 10;

-- Open the cursor
OPEN employee_cursor;

-- Start a transaction
BEGIN TRANSACTION;

-- Fetch the first row
FETCH NEXT FROM employee_cursor;

-- Loop through the cursor
WHILE @@FETCH_STATUS = 0
BEGIN
    -- Update the salary with a 15% increase
    UPDATE employees
    SET sal = sal * 1.15
    WHERE CURRENT OF employee_cursor;

    -- Fetch the next row
    FETCH NEXT FROM employee_cursor;
END

-- Commit the transaction to save the changes
COMMIT TRANSACTION;

-- Close and deallocate the cursor
CLOSE employee_cursor;
DEALLOCATE employee_cursor;

-- Select the updated records to verify
SELECT * FROM employees WHERE deptno = 10;
SELECT * FROM employees