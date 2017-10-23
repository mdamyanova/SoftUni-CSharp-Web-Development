-- 01. Employee address 
SELECT TOP 5 EmployeeId, JobTitle, e.AddressID, a.AddressText
FROM Employees AS e
INNER JOIN Addresses AS a
ON e.AddressID = a.AddressId
ORDER BY a.AddressId

-- 02. Addresses with towns
SELECT TOP 50 e.FirstName, e.LastName, t.Name, a.AddressText
FROM Employees AS e
INNER JOIN Addresses AS a
ON e.AddressId = a.AddressID
JOIN Towns AS t
ON a.TownID = t.TownID
ORDER BY e.FirstName, e.LastName

-- 03. Sales employee
SELECT EmployeeId, FirstName, LastName, d.Name
FROM Employees AS e
INNER JOIN Departments AS d
ON d.DepartmentID = e.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY EmployeeID

-- 04. Employee departments 
SELECT TOP 5 EmployeeId, FirstName, Salary, d.Name
FROM Employees AS e
INNER JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE Salary > 15000
ORDER BY e.DepartmentID

-- 05. Employees without projects 
SELECT TOP 3 EmployeeID, FirstName
FROM Employees AS e
WHERE e.EmployeeID NOT IN(SELECT EmployeeID FROM EmployeesProjects)
ORDER BY e.EmployeeID

-- 06. Employees hired after 
SELECT FirstName, LastName, HireDate, d.Name AS DeptName
FROM Employees AS e
INNER JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE HireDate > '1999-01-01'
AND (d.Name = 'Sales' OR d.Name = 'Finance')
ORDER BY HireDate

-- 07. Employees with project
SELECT TOP 5 e.EmployeeID, FirstName, p.Name
FROM Employees AS e
INNER JOIN EmployeesProjects AS ep
ON e.EmployeeID = ep.EmployeeID
INNER JOIN Projects AS p
ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL
ORDER BY e.EmployeeID

-- 08. Employee 24
SELECT e.EmployeeID, e.FirstName, 
  CASE 
    WHEN p.StartDate > '2005-01-01' THEN NULL 
    ELSE p.Name
END AS 'ProjectName'
FROM Employees AS e
INNER JOIN EmployeesProjects AS ep
ON e.EmployeeID = ep.EmployeeID
INNER JOIN Projects AS p
ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24

-- 09. Employee manager 
SELECT e.EmployeeID, e.FirstName, m.EmployeeID AS ManagerID, m.FirstName AS ManagerName
FROM Employees AS e
INNER JOIN Employees AS m
ON e.ManagerID = m.EmployeeID
WHERE e.ManagerID IN (3, 7)
ORDER BY e.EmployeeID

-- 10. Employee summary
SELECT TOP 50 e.EmployeeID, e.FirstName + ' ' + e.LastName AS EmployeeName, 
m.FirstName + ' ' + m.LastName AS ManagerName, d.Name AS DepartmentName
FROM Employees AS e
INNER JOIN Employees AS m
ON e.ManagerID = m.EmployeeID
INNER JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

-- 11. Min average salary 
SELECT MIN(m.Salary) FROM 
(SELECT e.DepartmentID, AVG(e.Salary) AS 'Salary'
FROM Employees AS e
GROUP BY e.DepartmentID) AS m

-- 12. Highest peaks in Bulgaria
SELECT mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation
FROM Mountains AS m
INNER JOIN Peaks AS p
ON m.Id = p.MountainId
INNER JOIN MountainsCountries AS mc
ON mc.MountainId = m.Id
WHERE p.Elevation > 2835 AND mc.CountryCode = 'BG'
ORDER BY p.Elevation DESC

-- 13. Count mountain ranges
SELECT c.CountryCode, COUNT(m.MountainRange)
FROM Countries AS c
JOIN MountainsCountries AS mc
ON c.CountryCode = mc.CountryCode
JOIN Mountains AS m
ON mc.MountainId = m.Id
WHERE c.CountryCode IN('BG', 'RU', 'US')
GROUP BY c.CountryCode

-- 14. Countries with rivers 
SELECT TOP 5 c.CountryName, r.RiverName
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr
ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers AS r
ON cr.RiverId = r.Id
JOIN Continents AS con
ON con.ContinentCode = c.ContinentCode
WHERE con.ContinentName = 'Africa'
ORDER BY c.CountryName

-- 15. Continents and currencies
SELECT c.Continentcode, cc.Currencycode, Count(cc.Countrycode) AS [CurrencyUsage]
FROM Continents c
JOIN Countries cc
ON c.Continentcode = cc.Continentcode
GROUP BY c.Continentcode, cc.Currencycode
HAVING Count(cc.Countrycode) = 
(
SELECT Max(xxx.currencyxx)
FROM (
		SELECT cx.Continentcode, ccx.Currencycode, Count(ccx.Countrycode) AS [CurrencyXX]
		FROM Continents cx
		JOIN Countries ccx
		ON cx.Continentcode = ccx.Continentcode
		WHERE c.Continentcode = cx.Continentcode
		GROUP BY cx.Continentcode, ccx.Currencycode
	 ) AS xxx
) AND Count(cc.Countrycode) > 1
ORDER  BY c.Continentcode  

-- 16. Countries without any mountains 
SELECT
( 
	SELECT COUNT(Countrycode) 
	FROM Countries
) -
(
	SELECT COUNT(con.Countrycode) 
	FROM 
		(
			SELECT mc.Countrycode
			FROM MountainsCountries AS mc
			GROUP BY mc.Countrycode
		) AS con
) AS 'Countrycode'

-- 17. Highest peak and longest river by country
SELECT TOP(5) c.CountryName, MAX(p.Elevation) AS 'HighestPeakElevation', MAX(r.Length) AS 'LongestRiverLength'
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc
ON c.Countrycode = mc.Countrycode
LEFT JOIN Peaks AS p
ON mc.MountainId = p.MountainId
LEFT JOIN CountriesRivers AS cr
ON c.Countrycode = cr.Countrycode
LEFT JOIN Rivers AS r
ON cr.RiverId = r.Id
GROUP BY c.CountryName
ORDER BY MAX(p.Elevation) DESC, MAX(r.Length) DESC, c.CountryName ASC

-- 18. Highest peak name and elevatuon by country
SELECT TOP(5) c.CountryName,
CASE 
WHEN p.PeakName IS NULL THEN '(no highest peak)' ELSE p.PeakName END AS 'HighestPeakName',
CASE 
WHEN p.Elevation IS NULL THEN 0 ELSE p.Elevation END AS 'HighestPeakElevation',
CASE 
WHEN m.MountainRange IS NULL THEN '(no mountain)' ELSE m.MountainRange END AS 'Mountain'

FROM Countries AS c
LEFT JOIN MountainsCountries AS mc
ON c.Countrycode = mc.Countrycode
LEFT JOIN Peaks AS p
ON mc.MountainId = p.MountainId
LEFT JOIN Mountains AS m
ON m.Id = mc.MountainId
ORDER BY c.CountryName ASC, p.PeakName ASC