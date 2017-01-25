-- 02. Find all information about departments
SELECT * FROM Departments

-- 03. Find all departments names
SELECT Name FROM Departments

-- 04. Find salary of each employee
SELECT FirstName, LastName, Salary FROM Employees

-- 05. Find full name of each employee
SELECT FirstName, MiddleName, LastName FROM Employees

-- 06. Find email address of each employee
SELECT FirstName + '.' + LastName + '@softuni.bg'
AS [Full Email Address]
FROM Employees
-- 07. Find all different employee's salaries
SELECT DISTINCT Salary FROM Employees

-- 08. Find all information about employees
SELECT * FROM Employees WHERE JobTitle = 'Sales Representative'

-- 09. Find names of all employess by salary in range
SELECT FirstName, LastName, JobTitle FROM Employees WHERE Salary >= 20000 and Salary <= 30000  

-- 10. Find names of all employees
SELECT FirstName + ' ' + MiddleName + ' ' + LastName 
AS [Full Name] 
FROM Employees
WHERE Salary = 25000 OR Salary = 14000 OR Salary = 12500 OR Salary = 23600

-- 11. Find all employees without manager
SELECT FirstName, LastName 
FROM Employees
WHERE ManagerID IS NULL

-- 12. Find all employees with salary more than 50 000
SELECT FirstName, LastName, Salary 
FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC

-- 13. Find 5 best paid employees
SELECT TOP(5) FirstName, LastName 
FROM Employees
ORDER BY Salary DESC

-- 14. Find all employees except marketing
SELECT FirstName, LastName 
FROM Employees
WHERE DepartmentId != 4

-- 15. Sort employees table
SELECT * FROM Employees
ORDER BY Salary DESC, 
FirstName, 
LastName DESC, 
MiddleName

-- 16. Create view employees with salaries
CREATE VIEW V_EmployeesSalaries
AS
SELECT FirstName, LastName, Salary
FROM Employees

-- 17. Create view employees with job titles
CREATE VIEW V_EmployeeNameJobTitle 
AS
SELECT FirstName + ' ' + ISNULL(MiddleName, '') + ' ' + LastName 
AS [Full Name], JobTitle 
FROM Employees

-- 18. Distinct job titles
SELECT DISTINCT JobTitle FROM Employees

-- 19. Find first 10 started projects
SELECT TOP(10) * FROM Projects
ORDER BY StartDate, Name

-- 20. Last 7 hired employees
SELECT TOP(7) FirstName, LastName, HireDate
FROM Employees
ORDER BY HireDate DESC

-- 21. Increase salaries
UPDATE Employees
SET Salary += Salary * 0.12
WHERE DepartmentId = 1 
OR DepartmentId = 2 
OR DepartmentId = 4  
OR DepartmentId = 11

-- same as WHERE DeparmentId IN('Engineering', 'Tool Design', 'Marketing', 'Information Services')

SELECT Salary FROM Employees

-- 22. All mountain peaks
SELECT PeakName 
FROM Peaks
ORDER BY PeakName

-- 23. Biggest countries by population
SELECT TOP(30) CountryName, Population
FROM Countries WHERE ContinentCode = 'EU'
ORDER BY Population DESC, CountryName

-- 24. Countries and currency
SELECT CountryName, CountryCode, 
CASE CurrencyCode
WHEN 'EUR' THEN 'Euro'
ELSE 'Not Euro'
END AS Currency FROM Countries
ORDER BY CountryName

-- 25. All diablo characters
SELECT Name FROM Characters ORDER BY Name