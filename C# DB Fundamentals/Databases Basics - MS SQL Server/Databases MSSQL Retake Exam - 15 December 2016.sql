-- SECTION 1: DDL
-- 01. Database design
CREATE DATABASE TheNerdHerd

CREATE TABLE Locations 
(
	Id int PRIMARY KEY IDENTITY,
	Latitude float,
	Longitude float
)

CREATE TABLE Credentials 
(
	Id int PRIMARY KEY IDENTITY,
	Email varchar(30),
	Password varchar(20)
)

CREATE TABLE Users
(
	Id int PRIMARY KEY IDENTITY,
	Nickname varchar(25),
	Gender char,
	Age int,
	LocationId int,
	CredentialId int UNIQUE,
	CONSTRAINT FK_Users_Locations 
	FOREIGN KEY (LocationId) REFERENCES Locations(Id),
	CONSTRAINT FK_Users_Credentials 
	FOREIGN KEY (CredentialId) REFERENCES Credentials(Id)
)

CREATE TABLE Chats 
(
	Id int PRIMARY KEY IDENTITY,
	Title varchar(32),
	StartDate DATE,
	IsActive bit
)

CREATE TABLE Messages
(
	Id int PRIMARY KEY IDENTITY,
	Content varchar(max),
	SentOn DATE, 
	ChatId int,
	UserId int,
	CONSTRAINT FK_Messages_Chats 
	FOREIGN KEY (ChatId) REFERENCES Chats(Id),
	CONSTRAINT FK_Messages_Users 
	FOREIGN KEY (UserId) REFERENCES Users(Id)
)

CREATE TABLE UsersChats 
(
	UserId int,
	ChatId int,
	CONSTRAINT PK_Users_Chats
	PRIMARY KEY(ChatId, UserId),
	CONSTRAINT FK_UsersChats_Users
	FOREIGN KEY (UserId) REFERENCES Users(Id),
	CONSTRAINT FK_UsersChats_Chats
	FOREIGN KEY (ChatId) REFERENCES Chats(Id)
)

-- SECTION 2: Database design
-- 02. Insert
INSERT Messages (Content, SentOn, ChatId, UserId)
SELECT
CONCAT(us.Age, '-', us.Gender, '-', l.Latitude, '-', l.Longitude),
CONVERT(DATE, GETDATE()),
[ChatId] = CASE
			WHEN us.Gender = 'F' THEN CEILING(SQRT((us.Age * 2)))
			WHEN us.Gender = 'M' THEN CEILING(POWER((us.Age / 18), 3))
			END,
us.Id
FROM Users AS us
INNER JOIN Locations AS l
ON l.Id = us.LocationId
WHERE us.Id >= 10 AND us.Id <= 20

-- 03. Update 
UPDATE Chats
SET StartDate = m.SentOn
FROM Chats as c
INNER JOIN Messages AS m
ON c.Id = m.ChatId
WHERE  m.SentOn < c.StartDate

-- 04. Delete 
DELETE FROM Locations
WHERE Id NOT IN(SELECT DISTINCT u.LocationId 
				FROM Users AS u 
				WHERE LocationId IS NOT NULL) 

-- 05. Age range 
SELECT NickName, Gender, Age 
FROM Users 
WHERE Age >= 22 AND Age <= 37

-- 06. Messages
SELECT Content, SentOn 
FROM Messages AS m
WHERE m.Content LIKE '%just%' AND SentOn > '2014-05-12'
ORDER BY Id DESC

-- 07. Chats
SELECT Title, IsActive 
FROM Chats AS c
WHERE (IsActive = 0 AND (LEN(c.Title) < 5) 
OR SUBSTRING(c.Title, 3, 2) = 'tl')
ORDER BY Title DESC

-- 08. Chat messages 
SELECT c.Id, c.Title, m.Id 
FROM Messages AS m 
INNER JOIN Chats AS c
ON m.ChatId = c.Id
WHERE m.SentOn < '2012-03-26' AND RIGHT(c.Title, 1) = 'x'
ORDER BY c.Id, m.Id

-- 09. Message count 
SELECT TOP(5) c.Id, COUNT(*) AS TotalMessages
FROM Chats AS c
RIGHT JOIN Messages AS m
ON c.Id = m.ChatId
WHERE m.Id < 90
GROUP BY c.Id
ORDER BY TotalMessages DESC, c.Id

-- 10. Credentials
SELECT u.Nickname, c.Email, c.Password 
FROM Credentials AS c
INNER JOIN Users AS u
ON c.Id = u.CredentialId
WHERE c.Email LIKE '%co.uk'
ORDER BY c.Email

-- 11. Locations 
SELECT u.Id, u.Nickname, u.Age
FROM Users AS u
WHERE u.LocationId IS NULL

-- 12. Left users 
SELECT m.Id, m.ChatId, m.UserId
FROM Messages AS m
WHERE (m.UserId NOT IN (
					   SELECT uc.UserId
                       FROM UsersChats AS uc
                       INNER JOIN Messages AS m
                       ON uc.ChatId = m.ChatId
                       WHERE uc.UserId = m.UserId AND m.ChatId = 17 ) OR m.UserId is null) 
					   AND m.ChatId = 17
ORDER BY m.Id DESC

-- 13. Users in Bulgaria 
SELECT u.Nickname, c.Title, l.Latitude, l.Longitude
FROM Users AS u
INNER JOIN Locations AS l
ON l.Id = u.LocationId
INNER JOIN UsersChats AS uc
ON uc.UserId = u.Id
INNER JOIN Chats AS c
ON uc.ChatId = c.Id
WHERE (l.Latitude BETWEEN 41.14 AND CAST(44.13 AS NUMERIC))
AND (l.Longitude BETWEEN 22.21 AND CAST(28.36 AS NUMERIC))
ORDER BY c.Title

-- 14. Last chat 
SELECT TOP (1) WITH TIES c.Title, m.Content
FROM Chats AS c
LEFT JOIN Messages AS m
ON m.ChatId = c.Id
ORDER BY c.StartDate DESC

-- 15. Radians 
CREATE FUNCTION udf_GetRadians(@degrees float)
RETURNS float 
AS 
BEGIN
	RETURN (@degrees * PI()) / 180
END

-- 16. Change password 
CREATE PROCEDURE udp_ChangePassword(@email varchar(MAX), @newPassword varchar(MAX))
AS
BEGIN
	BEGIN TRANSACTION
	
	UPDATE Credentials
	SET Password = @newPassword
	WHERE Email = @email

	IF(@@ROWCOUNT <> 1)
	BEGIN
		ROLLBACK
		RAISERROR('The email does''t exist!', 16, 1) 
	END
	ELSE 
	BEGIN
		COMMIT 
	END
END


exec udp_ChangePassword 'abarnes0@sogou.com','new_pass'

-- 17. Send message 
CREATE PROCEDURE udp_SendMessage(@userId INT, @chatId INT, @content VARCHAR(250))
AS
BEGIN
    BEGIN TRAN
    
	INSERT INTO Messages(UserId, ChatId, Content, SentOn)
    VALUES(@userId, @chatId, @content, CONVERT(VARCHAR(10), GETDATE(), 110))
   
    IF(@userId NOT IN (SELECT UserId FROM UsersChats WHERE ChatId = @chatId))
    BEGIN
    ROLLBACK
        RAISERROR('There is no chat with that user!', 16, 1)       
    END
   
    ELSE
    BEGIN
        COMMIT
    END
END

-- 18. Log messages

-- create table Messages Logs from Messages 
SELECT * INTO MessageLogs FROM Messages
TRUNCATE TABLE MessageLogs
SELECT * FROM MessageLogs
GO
CREATE TRIGGER t_Messages_After_Delete ON Messages AFTER DELETE
AS 
	INSERT INTO MessageLogs
	SELECT * FROM deleted

-- SECTION 5: Bonus
-- 19. Delete users
CREATE TRIGGER t_Users_InsteadOf_Delete ON Users INSTEAD OF DELETE
AS
	UPDATE Users
	SET CredentialId = NULL
	WHERE Id IN(SELECT Id FROM deleted)

	DELETE FROM Credentials
	WHERE Id IN(SELECT CredentialId FROM deleted)

	DELETE FROM UsersChats 
	WHERE UserId IN(SELECT Id FROM deleted)

	UPDATE Messages 
	SET UserId = NULL
	WHERE UserId IN(SELECT Id FROM deleted)

	DELETE FROM Users 
	WHERE Id IN(SELECT Id FROM deleted)