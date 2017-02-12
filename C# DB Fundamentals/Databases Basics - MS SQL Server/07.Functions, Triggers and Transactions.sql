-- 01. Employees with salary above 35000
CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS 
BEGIN
	SELECT FirstName AS [First name], LastName AS [Last name]
	FROM Employees
	WHERE Salary > 35000
END

EXEC usp_GetEmployeesSalaryAbove35000

-- 02. Employees with salary above number
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber(@number money)
AS
BEGIN
	SELECT FirstName AS [First Name], LastName AS [Last Name]
	FROM Employees
	WHERE Salary >= @number
END

EXEC usp_GetEmployeesSalaryAboveNumber 48100

-- 03. Town names starting with
CREATE PROCEDURE usp_GetTownsStartingWith(@string varchar(50))
AS 
BEGIN
	SELECT Name
	FROM Towns
	WHERE Name LIKE @string + '%'
END

EXEC usp_GetTownsStartingWith 'b'

-- 04. Employees from town
CREATE PROCEDURE usp_GetEmployeesFromTown(@townName varchar(50))
AS
BEGIN
	SELECT FirstName AS [First Name], LastName AS [Last Name]
	FROM Employees AS e
	INNER JOIN Addresses AS a
	ON e.AddressID = a.AddressID
	INNER JOIN Towns AS t
	ON a.TownID = t.TownID
	WHERE t.Name = @townName
END

EXEC usp_GetEmployeesFromTown

-- 05. Salary level function
CREATE FUNCTION ufn_GetSalaryLevel(@salary money)
RETURNS varchar(7)
AS 
BEGIN
	DECLARE @salaryLevel varchar(7);
	IF(@salary < 30000)
		SET @salaryLevel = 'Low';
	ELSE IF(@salary >= 30000 AND @salary <= 50000)
		SET @salaryLevel = 'Average';
	ELSE 
		SET @salaryLevel = 'High';
	RETURN @salaryLevel;
END

SELECT e.Salary, dbo.ufn_GetSalaryLevel(e.salary) AS [Salary Level]
FROM Employees AS e;

-- 06. Employees by salary level
CREATE PROCEDURE usp_EmployeesBySalaryLevel(@levelSalary varchar(7))
AS 
BEGIN
	SELECT FirstName AS [First Name], LastName AS [Last Name]
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @levelSalary
END

EXEC usp_EmployeesBySalaryLevel 'High'

-- 07. Define function
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(50), @word VARCHAR(50))
RETURNS BIT
AS
BEGIN
	DECLARE @index INT = 1
	DECLARE @lenght INT = LEN(@word);
	DECLARE @letter CHAR(1)
	WHILE (@index <= @lenght)
	BEGIN
	SET @letter = SUBSTRING(@word, @index, 1)
	IF(CHARINDEX(@letter, @setOfLetters) > 0)
	SET @index = @index + 1
	ELSE
	RETURN 0
	END
	RETURN 1	
END

-- 08. Delete employees and departments
BEGIN TRANSACTION

ALTER TABLE EmployeesProjects
DROP CONSTRAINT FK_EmployeesProjects_Employees
ALTER TABLE Departments
DROP CONSTRAINT FK_Departments_Employees
ALTER TABLE Employees
DROP CONSTRAINT FK_Employees_Employees
DELETE FROM Employees
WHERE DepartmentID IN (7,8)
DELETE FROM Departments
WHERE DepartmentID IN (7,8)

ROLLBACK

-- 09. Employees with three projects
CREATE PROCEDURE usp_AssignProject(@emloyeeId INT, @projectID INT)
AS
BEGIN
	BEGIN TRANSACTION
		INSERT INTO EmployeesProjects
			(EmployeeID, ProjectID)
		VALUES
			(@emloyeeId, @projectID)
		IF (SELECT COUNT(EmployeeID) FROM EmployeesProjects
			WHERE EmployeeID = @emloyeeId) > 3
		BEGIN
			RAISERROR('The employee has too many projects!', 16, 1)
			ROLLBACK
		END
	COMMIT
END

-- 10. Find full name
CREATE PROCEDURE usp_GetHoldersFullName
AS 
BEGIN
	SELECT FirstName + ' ' + LastName AS [Full Name]
	FROM AccountHolders
END

EXEC usp_GetHoldersFullName

-- 11. People with balance higher than
CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan(@money money)
AS
BEGIN
	SELECT FirstName AS [First Name], LastName AS [Last Name]
	FROM AccountHolders AS ah
	INNER JOIN Accounts AS a
	ON ah.Id = a.AccountHolderId
	GROUP BY ah.FirstName, ah.LastName
	HAVING SUM(a.Balance) > @money
END

EXEC usp_GetHoldersWithBalanceHigherThan 15000

-- 12. Future value function
CREATE FUNCTION ufn_CalculateFutureValue(@sum money, @yearlyInterestRate float, @numberOfYears int)
RETURNS money
AS 
BEGIN
	DECLARE @result money;
	SET @result = @sum * (POWER(1 + @yearlyInterestRate, @numberOfYears));
	RETURN @result;
END

EXEC ufn_CalculateFutureValue 1000.00, 0.1, 5

-- 13. Calculating interest 
CREATE PROCEDURE usp_CalculateFutureValueForAccount (@accountID int, @interestRate float)
AS
BEGIN
 
    DECLARE @newBalance money
 
    SELECT TOP(1) ah.Id AS 'Account Id', ah.FirstName, ah.LastName, ac.Balance,
    CASE
    WHEN @newBalance IS NULL THEN dbo.ufn_CalculateFutureValue(Balance, 0.1, 5) END AS 'Balance in 5 years'
    FROM AccountHolders AS ah
    INNER JOIN Accounts AS ac
    ON ac.AccountHolderId = ah.Id
    WHERE @accountID = ac.AccountHolderId
 
END

-- 14. Deposit money
CREATE PROCEDURE usp_DepositMoney (@accountId INT, @moneyAmount MONEY)
AS
BEGIN
	BEGIN TRANSACTION
	DECLARE @maxId INT= 0
	UPDATE Accounts 
	SET Balance = Balance + @moneyAmount
	WHERE Accounts.Id = @AccountId
	COMMIT 
END 

EXEC usp_DepositMoney 1, 10000

-- 15. Withdraw money
CREATE PROCEDURE usp_WithdrawMoney(@account INT, @moneyAmount MONEY)
AS
BEGIN
  BEGIN TRANSACTION

UPDATE Accounts SET Balance = Balance - @moneyAmount
WHERE Id = @account
IF @@ROWCOUNT <> 1
  BEGIN
   ROLLBACK;
   RAISERROR('Invalid account!', 16, 1)
   RETURN
  END

COMMIT

END

-- 16. Money transfer
CREATE PROCEDURE usp_TransferMoney(@senderId INT, @receiverId INT, @amount MONEY)
AS
BEGIN
	BEGIN TRANSACTION
	UPDATE Accounts
	SET Balance = Balance - @amount
	WHERE Accounts.Id = @senderId
	UPDATE Accounts
	SET Balance = Balance + @amount
	WHERE Accounts.Id = @receiverId
	IF (SELECT Balance FROM Accounts WHERE Accounts.Id = @senderId) < 0
		ROLLBACK
	ELSE COMMIT 
END

-- 17. Create table logs
CREATE TABLE Logs
(
	LogID int PRIMARY KEY,
	AccountID int NOT NULL,
	OldSum money NOT NULL,
	NewSum money NOT NULL,
	CONSTRAINT FK_Logs_Accounts FOREIGN KEY (AccountID) REFERENCES Accounts(Id)
)

CREATE TRIGGER T_Accounts_After_Update 
ON Accounts 
AFTER UPDATE
AS 
BEGIN
	INSERT INTO Logs(AccountId, OldSum, NewSum)
	SELECT i.Id, d.Balance, i.Balance 
	FROM Inserted AS i
	JOIN Deleted AS d 
	ON d.Id = i.Id
END

-- 18. Create table emails
CREATE TABLE NotificationEmails 
(
	Id int PRIMARY KEY,
	Recipient varchar(50) NOT NULL,
	Subject varchar(50) NOT NULL,
	Body varchar(100)
)

CREATE TRIGGER tr_LogToEmail ON Logs AFTER INSERT
AS
BEGIN
	INSERT INTO NotificationEmails
		(Recipient, Subject, Body)
	SELECT AccountId,
		'Balance change for account: ' 
		+ CONVERT(varchar(10), AccountId),
		'On ' + CONVERT(varchar(30), GETDATE()) + ' your balance was changed from '
		+ CONVERT(varchar(30), OldSum) + ' to ' 
		+ CONVERT(varchar(30), NewSum) 
	  FROM Logs
END

-- 19. Scalar function: cash in user games odd rows 
CREATE FUNCTION ufn_CashInUsersGames(@gameName varchar(50))
RETURNS @output TABLE(SumCash money)
AS 
BEGIN 
	INSERT INTO @output
	SELECT SUM(sc.Cash) AS SumCash 
	FROM (
		 SELECT Cash, ROW_NUMBER() OVER(ORDER BY Cash DESC) 
		 AS RowNumber 
	     FROM UsersGames AS ug
		 RIGHT JOIN Games g 
		 ON ug.GameId = g.Id
		 WHERE g.Name = @gameName
		 ) AS sc
   WHERE RowNumber % 2 <> 0
   RETURN
END

-- 20. Trigger 
CREATE TRIGGER tr_Items ON UserGameItems
AFTER INSERT AS
BEGIN 
	BEGIN TRAN 
	DECLARE @itemMinLevel INT = 
				(
				SELECT i.MinLevel 
				FROM Items AS i 
				JOIN UserGameItems AS ugi 
				ON ugi.ItemId = i.Id 
				WHERE i.Id = ugi.ItemId 
				)
	DECLARE @userLevel INT = 
			   (
			   SELECT ug.Level 
			   FROM UsersGames AS ug 
			   JOIN UserGameItems AS ugi 
			   ON ugi.UserGameId = ug.GameId 
			   WHERE ugi.UserGameId = ug.GameId
			   )
	IF(@itemMinLevel > @userLevel)
		BEGIN ROLLBACK END
	ELSE 
		BEGIN COMMIT END
END

-- 21. Massive shopping 
BEGIN TRANSACTION
	DECLARE @sum1 MONEY = 
						(
						SELECT SUM(i.Price)
			            FROM Items i
						WHERE MinLevel BETWEEN 11 AND 12
						)

	IF (SELECT Cash FROM UsersGames WHERE Id = 110) < @sum1
		ROLLBACK
	ELSE 
		BEGIN
		UPDATE UsersGames
		SET Cash = Cash - @sum1
		WHERE Id = 110

	INSERT INTO UserGameItems (UserGameId, ItemId)
	SELECT 110, Id 
	FROM Items 
	WHERE MinLevel BETWEEN 11 AND 12
	COMMIT
END

BEGIN TRANSACTION
	DECLARE @sum2 MONEY =
					    (
						SELECT SUM(i.Price)
					    FROM Items i
						WHERE MinLevel BETWEEN 19 AND 21
						)

	IF (SELECT Cash FROM UsersGames WHERE Id = 110) < @sum2
		ROLLBACK
	ELSE	
		BEGIN

	UPDATE UsersGames
	SET Cash = Cash - @sum2
	WHERE Id = 110

	INSERT INTO UserGameItems (UserGameId, ItemId)
	SELECT 110, Id 
	FROM Items 
	WHERE MinLevel BETWEEN 19 AND 21
	COMMIT
END

SELECT i.Name AS 'Item Name' 
FROM UserGameItems ugi
JOIN Items i
ON ugi.ItemId = i.Id
WHERE ugi.UserGameId = 110

-- 22. Number of users for email provider 
SELECT SUBSTRING(Email, CHARINDEX('@', Email, 1) + 1, LEN(Email)) AS [Email Provider],
		COUNT(*) AS [Number Of Users]
FROM Users AS u
GROUP BY  SUBSTRING(Email, CHARINDEX('@', Email, 1) + 1, LEN(Email))
ORDER BY [Number Of Users] DESC, [Email Provider]

-- 23. All users in games 
SELECT g.Name AS Game, gt.Name AS [Game Type], u.Username, ug.Level, ug.Cash, c.Name AS Character
FROM UsersGames AS ug
INNER JOIN Users AS u
ON ug.UserId = u.Id
INNER JOIN Characters AS c
ON ug.CharacterId = c.Id
INNER JOIN Games AS g
ON ug.GameId = g.Id
INNER JOIN GameTypes AS gt
ON g.GameTypeId = gt.Id
ORDER BY ug.Level DESC, u.Username, g.Name

-- 24. Users in games with their items
SELECT u.Username, g.Name AS Game, COUNT(*) AS 'Items Count', SUM(i.Price) AS 'Items Price'
FROM Users AS u
INNER JOIN UsersGames AS ug 
ON u.Id = ug.UserId
INNER JOIN UserGameItems AS ugi
ON ugi.UserGameId = ug.Id
INNER JOIN Games AS g
ON g.Id = ug.GameId
INNER JOIN Items AS i 
ON i.Id = ugi.ItemId
GROUP BY u.Username, g.Name
HAVING COUNT(*) >= 10
ORDER BY COUNT(*) DESC, SUM(i.Price) DESC, u.Username

-- 25. User in games with their statistics
SELECT Username, g.Name Game, MAX(c.Name) Character,
SUM(its.Strength) + MAX(chs.Strength) + MAX(gts.Strength) [Strength],
SUM(its.Defence) + MAX(chs.Defence) + MAX(gts.Defence) [Defence],
SUM(its.Speed) + MAX(chs.Speed) + MAX(gts.Speed) [Speed],
SUM(its.Mind) + MAX(chs.Mind) + MAX(gts.Mind) [Mind],
SUM(its.Luck) + MAX(chs.Luck) + MAX(gts.Luck) [Luck]
 FROM Users u
 LEFT JOIN UsersGames ug ON ug.UserId =u.Id
 LEFT JOIN Games g ON g.Id = ug.GameId
 LEFT JOIN GameTypes gt ON g.GameTypeId = gt.Id
 LEFT JOIN UserGameItems ugi ON ugi.UserGameId = ug.Id
 LEFT JOIN Items i ON i.Id = ugi.ItemId
 LEFT JOIN Characters c ON c.Id = ug.CharacterId
 LEFT JOIN [Statistics] chs ON chs.Id = c.StatisticId
 LEFT JOIN [Statistics] gts ON gts.Id = gt.BonusStatsId
 LEFT JOIN [Statistics] its ON its.Id = i.StatisticId
 GROUP BY Username, g.Name
 ORDER BY Strength DESC, Defence DESC, Speed DESC, Mind DESC, Luck DESC

 -- 26. All items with greater than average statistics 
SELECT i.Name, Price, MinLevel, Strength, Defence, Speed, Luck, Mind
FROM [Statistics] AS s
INNER JOIN Items AS i
ON i.StatisticId = s.Id
WHERE Mind > (SELECT AVG(s.Mind) FROM [Statistics] AS s) AND 
	  Luck > (SELECT AVG(s.Luck) FROM [Statistics] AS s) AND 
	  Speed > (SELECT AVG(s.Speed) FROM [Statistics] AS s)
ORDER BY i.Name

-- 27. Display all iyems with infromation about forbidden game type 
SELECT i.Name, i.Price, i.MinLevel, gt.Name AS [Forbidden Game Type]
FROM Items AS i
LEFT JOIN GameTypeForbiddenItems AS gtf
ON gtf.ItemId = i.Id
LEFT JOIN GameTypes AS gt
ON gtf.GameTypeId = gt.Id
ORDER BY gt.Name DESC, i.Name

-- 28. Buy items for user in game
DECLARE @alexId INT = 
					(
					SELECT Id 
					FROM Users 
					WHERE Username = 'Alex'
					)
DECLARE @gameId INT = 
					(
					SELECT Id
					 FROM Games WHERE 
					 Name = 'Edinburgh'
					)
DECLARE @userGameID INT = 
					(
					SELECT Id 
					FROM UsersGames 
					WHERE UserId = @alexId 
					AND GameId = @gameId
					)
DECLARE @itemSUM MONEY = 
					(
					SELECT SUM(p.Price) 
					FROM 
						(
						SELECT i.Id, i.Price 
						FROM Items AS i
						WHERE i.Name IN ('Blackguard', 'Bottomless Potion of Amplification', 
						'Eye of Etlich (Diablo III)', 'Gem of Efficacious Toxin', 
						'Golden Gorget of Leoric', 'Hellfire Amulet'
						)
					) AS p)

INSERT INTO UserGameItems 
SELECT p.ItemId, p.UserGameId 
FROM 
	(
	SELECT i.Id As ItemId, ug.Id AS UserGameId 
	FROM Items AS i
	CROSS JOIN UsersGames AS ug
	WHERE ug.Id = @userGameID
	AND i.Name IN ('Blackguard', 'Bottomless Potion of Amplification', 
     'Eye of Etlich (Diablo III)', 'Gem of Efficacious Toxin', 
	'Golden Gorget of Leoric', 'Hellfire Amulet')) AS p

UPDATE UsersGames
SET Cash -= @itemSUM
WHERE Id = @userGameID

SELECT u.Username, g.Name, ug.Cash, i.Name AS 'Item Name' 
FROM Users AS u
INNER JOIN UsersGames AS ug 
ON ug.UserId = u.Id
LEFT JOIN Games AS g 
ON g.Id = ug.GameId
LEFT JOIN UserGameItems AS ugi 
ON ugi.UserGameId = ug.Id
LEFT JOIN Items AS i 
ON i.Id = ugi.ItemId
WHERE g.Id = 221
ORDER BY i.Name

-- 29. Peaks and mountains 
SELECT p.PeakName, m.MountainRange, p.Elevation
FROM Mountains AS m
INNER JOIN Peaks AS p
ON p.MountainId = m.Id
ORDER BY p.Elevation DESC

-- 30. Peaks with their mountain, country and continent
SELECT p.PeakName, m.MountainRange, c.CountryName, cont.ContinentName
FROM Mountains AS m
RIGHT JOIN Peaks AS p
ON m.Id = p.MountainId
INNER JOIN MountainsCountries AS mc
ON mc.MountainId = m.Id
INNER JOIN Countries AS c
ON mc.CountryCode = c.CountryCode
INNER JOIN Continents AS cont
ON cont.ContinentCode = c.ContinentCode
ORDER BY p.PeakName, c.CountryName

-- 31. Rivers by country
SELECT co.CountryName, con.ContinentName,
CASE
	WHEN COUNT(r.Id) IS NULL THEN 0
	ELSE COUNT(r.Id)
END
AS RiversCount, 
CASE
	WHEN SUM(r.Length) IS NULL THEN 0
	ELSE SUM(r.Length)
END
AS TotalLength
FROM Countries AS co
LEFT JOIN CountriesRivers AS cr 
ON cr.CountryCode = co.CountryCode
LEFT JOIN Rivers AS r 
ON r.Id = cr.RiverId
LEFT JOIN Continents AS con 
ON con.ContinentCode = co.ContinentCode
GROUP BY co.CountryName, con.ContinentName
ORDER BY RiversCount DESC, TotalLength DESC, co.CountryName ASC

-- 32. Count of countries by currency
SELECT cu.CurrencyCode, 
	   cu.Description AS Currency, 
	   COUNT(co.CountryName) AS NumberOfCountries 
FROM Currencies AS cu 
LEFT JOIN Countries AS co 
ON co.CurrencyCode = cu.CurrencyCode
GROUP BY cu.CurrencyCode, cu.Description
ORDER BY COUNT(co.CountryName) DESC, cu.Description ASC

-- 33. Population and area by continent 
SELECT c.ContinentName, 
	   SUM(cou.AreaInSqKm) AS CountriesArea, 
	   SUM(CAST(cou.Population AS BIGINT)) AS CountriesPopulation
FROM Continents AS c
INNER JOIN Countries AS cou
ON cou.ContinentCode = c.ContinentCode
GROUP BY c.ContinentName
ORDER BY SUM(CAST(cou.Population AS BIGINT)) DESC

-- 34. Monsteries by country 
CREATE TABLE Monasteries
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(50),
    CountryCode CHAR(2),
    CONSTRAINT FK_Monasteries_Countries FOREIGN KEY (CountryCode)
    REFERENCES Countries(CountryCode)
)
 
INSERT INTO Monasteries(Name, CountryCode) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'),
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sümela Monastery', 'TR')
 
UPDATE Countries
SET IsDeleted = 1
    WHERE CountryCode IN 
						(
						SELECT c.CountryCode 
						FROM Countries c
						INNER JOIN CountriesRivers cr 
						ON cr.CountryCode = c.CountryCode
						INNER JOIN Rivers r 
						ON r.Id = cr.RiverId
                        GROUP BY c.CountryCode
                        HAVING COUNT(r.Id) > 3 
						)
 
SELECT m.Name, c.CountryName
FROM Monasteries AS m
INNER JOIN Countries c 
ON c.CountryCode = m.CountryCode
WHERE c.IsDeleted = 0
ORDER BY m.Name

-- 35. Monasteries by continents and countries
UPDATE Countries
SET CountryName = 'Burma'
WHERE CountryName = 'Myanmar'

INSERT INTO Monasteries (Name, CountryCode) VALUES
('Hanga Abbey', (SELECT CountryCode FROM Countries WHERE CountryName = 'Tanzania')),
('Myin-Tin-Daik', (SELECT CountryCode FROM Countries WHERE CountryName = 'Myanmar'))

SELECT
	co.ContinentName,
	c.CountryName,
	MonasteriesCount
FROM
	(
	SELECT
	c.CountryCode,
	COUNT(m.Id) AS MonasteriesCount
	FROM Continents co
	JOIN Countries c 
	ON c.ContinentCode = co.ContinentCode
	LEFT JOIN Monasteries m 
	ON m.CountryCode = c.CountryCode
	WHERE c.IsDeleted = 0
	GROUP BY c.CountryCode
	) AS MonasteriesByCountries
JOIN Countries c 
ON c.CountryCode = MonasteriesByCountries.CountryCode
JOIN Continents co 
ON co.ContinentCode = c.ContinentCode
ORDER BY MonasteriesCount DESC, c.CountryName