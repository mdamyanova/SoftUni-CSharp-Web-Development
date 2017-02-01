-- 01. Find names of all employees by first name
SELECT FirstName, LastName
FROM Employees
WHERE LEFT(FirstName, 2)  = 'sa'

-- 02. Find names of all employees by last name
SELECT FirstName, LastName
FROM Employees
WHERE LastName LIKE '%ei%' ESCAPE '!'

-- 03. Find first names of all employees
SELECT FirstName 
FROM Employees
WHERE DepartmentID IN(3, 10) 
AND (HireDate >= 1995 OR HireDate <= 2005)

-- 04. Find all employees except engineers
SELECT FirstName, LastName
FROM Employees
WHERE NOT JobTitle LIKE '%engineer%'

-- 05. Find towns with name length
SELECT Name 
FROM Towns
WHERE LEN(Name) IN(5, 6)
ORDER BY Name

-- 06. Find towns starting with
SELECT TownId, Name
FROM Towns
WHERE LEFT(Name, 1) IN('M', 'K', 'B', 'E')
ORDER BY Name

-- 07. Find towns not starting with
SELECT TownId, Name
FROM Towns
WHERE NOT LEFT(Name, 1) IN('R', 'B', 'D')
ORDER BY Name

-- 08. Create view employees hired after 2000 year
CREATE VIEW V_EmployeesHiredAfter2000
AS 
SELECT FirstName, LastName
FROM Employees
WHERE YEAR(HireDate) > 2000

-- 09. Length of last name 
SELECT FirstName, LastName
FROM Employees
WHERE LEN(LastName) = 5

-- 10. Countries holding A 3 or more times
SELECT CountryName, IsoCode
FROM Countries 
WHERE LEN(CountryName) - LEN(REPLACE(CountryName, 'a', '')) >= 3
ORDER BY IsoCode

-- 11. Mix of peak and river names
SELECT 
PeakName, 
RiverName, 
LOWER(PeakName + RIGHT(RiverName, LEN(RiverName) - 1)) AS Mix
FROM Rivers, Peaks
WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix

-- 12. Games from 2011 and 2012 year
SELECT TOP(50) Name, CONVERT(DATE, Start)
FROM Games
WHERE DATEPART(YEAR, Start) IN(2011, 2012)
ORDER BY Start, Name

-- 13. User email providers
SELECT Username, 
SUBSTRING(Email, CHARINDEX('@', Email, 1) + 1, LEN(Email)) 
AS [Email Provider]
FROM Users
ORDER BY [Email Provider], Username 

-- 14. Get users with ipaddress like pattern
SELECT Username, IpAddress
FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username

-- 15. Show all games with duration and part of the day
SELECT Game, 


-- 16. Orders table
SELECT ProductName, OrderDate, 
DATEADD(DAY, 3, OrderDate) AS 'Pay Due',
DATEADD(MONTH, 1, DATEADD(DAY, 3, OrderDate)) AS 'Delivery Due'
FROM Orders