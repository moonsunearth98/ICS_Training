/*--------- Creating Database ----------------*/

create database Test_1
use Test_1
/*1.Create a book table with id as primary key and provide the appropriate data type to other attributes .isbn no should be unique for each book
  Write a query to fetch the details of the books written by author whose name ends with er.
  Display the Title ,Author and ReviewerName for all the books from the above table */

-----Creating a table--------------

-- Creating the "books" table
CREATE TABLE books (
    id INT PRIMARY KEY,
    title VARCHAR(100),
    author VARCHAR(50),
    isbn NUMERIC(20, 0) UNIQUE,
    published_date DATE
)

-- Inserting values into the "books" table
INSERT INTO books (id, title, author, isbn, published_date)
VALUES
    (1, 'My First SQL book', 'Mary Parker', 981483029127, '2012-02-22'),
    (2, 'My Second SQL book', 'John Mayer', 857300923713, '1972-07-03'),
    (3, 'My Third SQL book', 'Cary Flint', 523120967812, '2015-10-18')

-- Creating the "reviews" table
CREATE TABLE reviews (
    id INT FOREIGN KEY REFERENCES books (id),
    book_id INT,
    reviewer_name VARCHAR(50),
    content VARCHAR(50),
    rating INT,
    published_date DATE
)

-- Inserting values into the "reviews" table
INSERT INTO reviews (id, book_id, reviewer_name, content, rating, published_date)
VALUES
    (1, 1, 'John Smith', 'My first review', 4, '2017-12-10'),
    (2, 2, 'John Smith', 'My second review', 5, '2017-10-13'),
    (3, 2, 'Alice Walker', 'Another review', 1, '2017-10-22')

------------SELECT * FROM books
------------SELECT * FROM reviews
-- Query to fetch details of books written by authors whose name ends with "er"

SELECT title, author FROM books WHERE author LIKE '%er';

-- Query to display Title, Author, and ReviewerName for all books
SELECT b.title, b.author, r.reviewer_name FROM books b JOIN reviews r ON b.id = r.id;

/*2.Display the  reviewer name who reviewed more than one book. */

SELECT reviewer_name FROM reviews GROUP BY reviewer_name HAVING COUNT(DISTINCT book_id) > 1;

/*3.Display the Name for the customer from above customer table  who live in same address which has character o anywhere in address--------*/

---------- Creating a table---------

CREATE TABLE Customer (
    CustomerID INT PRIMARY KEY,
    Name VARCHAR(255),
    Age INT,
    Address VARCHAR(255),
    Salary DECIMAL(10, 2)
)

-- Insert data into the Customers table
INSERT INTO Customer (CustomerID, Name, Age, Address, Salary)
VALUES
    (1, 'Ramesh', 32, 'Ahmedabad', 200.00),
    (2, 'Khilan', 25, 'Delhi', 1500.00),
    (3, 'Kaushik', 23, 'Kota', 2000.00),
    (4, 'Chaitali', 25, 'Mumbai', 6500.00),
    (5, 'Hardik', 27, 'Bhopal', 8500.00),
    (6, 'Komal', 22, 'MP', 4500.00),
    (7, 'Muffy', 24, 'Indore', 10000.00)

--------------SELECT * FROM Customer

-- Query to find customer names with 'o' in the address

SELECT C1.Name FROM Customer C1 WHERE EXISTS (SELECT 1 FROM Customer C2 WHERE C2.Address LIKE '%o%' AND C1.Address = C2.Address)

/* 4.Write a query to display the Date,Total no of customer  placed order on same Date */

---- creating table for orders---------

-- Creating table for orders
CREATE TABLE ORDERS (
    Order_ID INT,
    Order_Date DATE,
    Customer_ID INT,
    Amount INT
)


-- Insert data into the ORDERS table
INSERT INTO ORDERS (Order_ID, Order_Date, Customer_ID, Amount)
VALUES
    (102, '2009-10-08', 3, 3000),
    (100, '2009-10-08', 3, 1500),
    (101, '2009-11-20', 2, 1560),
    (103, '2008-05-20', 4, 2060);

-- Query to display the date and the total number of customers who placed orders on the same date
SELECT Order_Date,COUNT(DISTINCT Customer_ID) 'NO_OF_ORDER' FROM ORDERS GROUP BY Order_Date 



/* 5.Display the Names of the Employee in lower case, whose salary is null */

-----Creating Employee Table------------

CREATE TABLE Employee (
    EmpID INT PRIMARY KEY,
    EmpName VARCHAR(255),
    EmpAge INT,
    EmpAddress VARCHAR(255),
    EmpSalary DECIMAL(10, 2)
)

-- Insert data into the Employee table
INSERT INTO Employee(EmpID, EmpName, EmpAge, EmpAddress, EmpSalary)
VALUES
    (1, 'Ramesh', 32, 'Ahmedabad', 200.00),
    (2, 'Khilan', 25, 'Delhi', 1500.00),
    (3, 'Kaushik', 23, 'Kota', 2000.00),
    (4, 'Chaitali', 25, 'Mumbai', 6500.00),
    (5, 'Hardik', 27, 'Bhopal', 8500.00),
    (6, 'Komal', 22, 'MP', Null),
    (7, 'Muffy', 24, 'Indore', Null)

------------------SELECT * FROM Employee
--Query to display the names of the employee in lower case, whose salary is null

SELECT LOWER(EmpName) AS "LowerCse" FROM Employee WHERE EmpSalary IS NULL;

/*-----6. Write a sql server query to display the Gender,Total no of male and female from the above 
                   relation in Student Table----*/

------------ Creating a Student Table--------

CREATE TABLE StudentDetails (
    RegisterNo INT PRIMARY KEY,
    Student_Name VARCHAR(255),
    Age INT,
    Qualification VARCHAR(255),
    MobileNo VARCHAR(255),
    Email VARCHAR(255),
    Student_Location VARCHAR(255),
	Gender VARCHAR(1)
)
INSERT INTO StudentDetails(RegisterNo,Student_Name,Age,Qualification,MobileNo,Email,Student_Location,Gender)
VALUES
    (2, 'Sai', 22, 'B.E', '9952836777','Sai@gmail.com', 'Chennai','M'),
    (3, 'Kumar', 20, 'BSE', '7890125648', 'Kumar@gmail.com','Madurai','M'),
    (4, 'Selvi', 22, 'B. Tech', '8904567342', 'Salvi@gmail.com', 'Selam','F'),
    (5, 'Nisha', 25, 'ME', '783467210', 'Nisha@gmail.com','Theni','F'),
    (6, 'SaiSaran', 21,'BA','7890345678','saran@gmail.com','Madurai','F'),
    (7, 'Torn', 23, 'BCA', '8901234675', 'Torn@gmail.com', 'Pune','M')

------- Write a sql server query to display the Gender,Total no of male and female
          
SELECT Gender, COUNT(*) AS Total_Count FROM StudentDetails GROUP BY Gender;

