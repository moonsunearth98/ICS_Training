create database p_assignment5
use p_assignment5

CREATE PROCEDURE GeneratePayslip
    @EmployeeID INT,
    @Salary DECIMAL(10, 2)
AS
BEGIN
    DECLARE @HRA DECIMAL(10, 2)
    DECLARE @DA DECIMAL(10, 2)
    DECLARE @PF DECIMAL(10, 2)
    DECLARE @IT DECIMAL(10, 2)
    DECLARE @Deductions DECIMAL(10, 2)
    DECLARE @GrossSalary DECIMAL(10, 2)
    DECLARE @NetSalary DECIMAL(10, 2)

    -- Calculate HRA, DA, PF, and IT
    SET @HRA = 0.10 * @Salary
    SET @DA = 0.20 * @Salary
    SET @PF = 0.08 * @Salary
    SET @IT = 0.05 * @Salary

    -- Calculate Deductions
    SET @Deductions = @PF + @IT

    -- Calculate Gross Salary
    SET @GrossSalary = @Salary + @HRA + @DA

    -- Calculate Net Salary
    SET @NetSalary = @GrossSalary - @Deductions

    -- Display the payslip
    SELECT 'Employee ID: ' + CAST(@EmployeeID AS VARCHAR(10)) AS 'Payslip',
           'Basic Salary: ' + CAST(@Salary AS VARCHAR(10)) AS ' ',
           'HRA: ' + CAST(@HRA AS VARCHAR(10)) AS ' ',
           'DA: ' + CAST(@DA AS VARCHAR(10)) AS ' ',
           'PF: ' + CAST(@PF AS VARCHAR(10)) AS ' ',
           'IT: ' + CAST(@IT AS VARCHAR(10)) AS ' ',
           'Deductions: ' + CAST(@Deductions AS VARCHAR(10)) AS ' ',
           'Gross Salary: ' + CAST(@GrossSalary AS VARCHAR(10)) AS ' ',
           'Net Salary: ' + CAST(@NetSalary AS VARCHAR(10)) AS ' ';
END
EXEC GeneratePayslip @EmployeeID = 1, @Salary = 7000000.00;
