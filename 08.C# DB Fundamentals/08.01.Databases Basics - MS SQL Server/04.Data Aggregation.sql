-- 01. Records' count
SELECT COUNT(Id) AS Count 
FROM WizzardDeposits

-- 02. Longest magic wand
SELECT MAX(MagicWandSize) AS LogestMagicWand
FROM WizzardDeposits

-- 03. Longest magic wand per deposit groups
SELECT DepositGroup, MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits
GROUP BY DepositGroup

-- 04. Smallest deposit group per magic wand size
SELECT w.[DepositGroup]
FROM WizzardDeposits w
GROUP BY w.[DepositGroup]
HAVING AVG(w.MagicWandSize) = (
        SELECT MIN(WandSizeTable.AverageSizes) AS MinimalSize
        FROM (SELECT AVG(w.MagicWandSize) AS AverageSizes
                    FROM WizzardDeposits w
                    GROUP BY w.DepositGroup) AS WandSizeTable
)

-- 05. Deposits sum
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
GROUP BY DepositGroup

-- 06. Deposits sum for Ollivander family
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

-- 07. Deposits filter
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC

-- 08. Deposit charge
SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) AS MinDepositCharge
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup

-- 09. Age groups
SELECT w.AgeGroup, COUNT(*) AS 'WizardCount' 
FROM
(
SELECT 'AgeGroup'=
CASE
WHEN z.Age BETWEEN 0 AND 10 THEN '[0-10]'
WHEN z.Age BETWEEN 11 AND 20 THEN '[11-20]'
WHEN z.Age BETWEEN 21 AND 30 THEN '[21-30]'
WHEN z.Age BETWEEN 31 AND 40 THEN '[31-40]'
WHEN z.Age BETWEEN 41 AND 50 THEN '[41-50]'
WHEN z.Age BETWEEN 51 AND 60 THEN '[51-60]'
WHEN z.Age >= 61 THEN '[61+]'
END
FROM WizzardDeposits AS z
) AS w
GROUP BY w.AgeGroup

-- 10. First letter
SELECT LEFT(FirstName, 1) AS FirstLetter
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY LEFT(FirstName, 1)
ORDER BY FirstLetter

-- 11. Average interest
SELECT DepositGroup, IsDepositExpired, AVG(DepositInterest) AS 'AverageInterest'
FROM WizzardDeposits
WHERE DepositStartDate > '1985-01-01'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired

-- 12. Rich wizard, poor wizard
SELECT SUM(SumDiff.SumDifference)
FROM
    (SELECT h.DepositAmount -
        (SELECT DepositAmount
        FROM WizzardDeposits
        WHERE Id = h.Id + 1
        ) AS SumDifference
    FROM WizzardDeposits h) AS SumDiff

-- 13. Depatments total salaries
SELECT DepartmentId, SUM(Salary) AS TotalSalary
FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID

-- 14. Employees minimum salaries
SELECT DepartmentId, MIN(Salary) AS MinimumSalary
FROM Employees
WHERE DepartmentID IN(2, 5, 7) 
AND HireDate > '2000-01-01'
GROUP BY DepartmentID

-- 15. Employees average slaries
SELECT * INTO NewTable FROM Employees 
WHERE Salary > 30000

DELETE FROM NewTable
WHERE ManagerID = 42

UPDATE NewTable
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) AS AverageSalary FROM NewTable
GROUP BY DepartmentID

-- 16. Employees maximum salaries
SELECT DepartmentId, MAX(Salary) AS MaxSalary
FROM Employees
GROUP BY DepartmentId
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

-- 17. Employees count salaries
SELECT COUNT(Salary) AS Count 
FROM Employees
WHERE ManagerID IS NULL

-- 18. 3rd highest salary
SELECT 
sal.DepartmentId, sal.Salary
FROM 
(
SELECT
e.DepartmentId, e.Salary, DENSE_RANK()
OVER (
PARTITION BY
e.DepartmentID
ORDER BY
e.Salary DESC
) AS SalaryRank
FROM 
Employees AS e
) AS sal
WHERE
sal.SalaryRank = 3
GROUP BY
sal.DepartmentID, sal.Salary

-- 19. Salary challenge
SELECT TOP 10 FirstName, LastName, DepartmentID
FROM Employees AS e
LEFT JOIN(SELECT DepartmentID AS avgDept, AVG(Salary) AS avgSal 
	FROM Employees 
	GROUP BY DepartmentID) AS avgTab
	ON e.[DepartmentID] = avgTab.avgDept 
WHERE e.Salary > avgTab.avgSal
ORDER BY e.DepartmentID