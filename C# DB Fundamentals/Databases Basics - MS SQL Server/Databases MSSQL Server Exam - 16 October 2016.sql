
-- SECTION 0: Database overview
-- SECTION 1: Data definition
CREATE DATABASE Airport

CREATE TABLE Towns 
(
	TownID int PRIMARY KEY,
	TownName varchar(30) NOT NULL
)

CREATE TABLE Airports 
(
	AirportID int PRIMARY KEY,
	AirportName varchar(50) NOT NULL,
	TownID int,
	CONSTRAINT FK_Airports_Towns 
	FOREIGN KEY (TownID) REFERENCES Towns(TownID)
)

CREATE TABLE Airlines
(
	AirlineID int PRIMARY KEY,
	AirlineName varchar(30) NOT NULL,
	Nationality varchar(30) NOT NULL,
	Rating int DEFAULT 0
)

CREATE TABLE Customers
(
	CustomerID int PRIMARY KEY,
	FirstName varchar(20) NOT NULL,
	LastName varchar(20) NOT NULL,
	DateOfBirth DATE NOT NULL,
	Gender char CHECK(Gender IN('F','M')),
	HomeTownID int NOT NULL,
	CONSTRAINT FK_Customers_Towns
	FOREIGN KEY (HomeTownID) REFERENCES Towns(TownID)
)

CREATE TABLE Flights 
(
	FlightID int PRIMARY KEY,
	DepartureTime DATETIME NOT NULL,
	ArrivalTime DATETIME NOT NULL,
	Status varchar(9) CHECK(Status IN('Departing', 'Delayed', 'Arrived', 'Cancelled')),
	OriginAirportID int NOT NULL,
	CONSTRAINT FK_Flights_Airports_OriginAirport
	FOREIGN KEY (OriginAirportID) REFERENCES Airports(AirportID),
	DestinationAirportID int NOT NULL,
	CONSTRAINT FK_Flights_Airports_DestinationAirport
	FOREIGN KEY (DestinationAirportID) REFERENCES Airports(AirportID),
	AirlineID int NOT NULL,
	CONSTRAINT FK_Flights_Airlines 
	FOREIGN KEY (AirlineID) REFERENCES Airlines(AirlineID)
)

CREATE TABLE Tickets 
(
	TicketID int PRIMARY KEY,
	Price decimal(8, 2) NOT NULL,
	Class varchar(6) CHECK (Class IN('First', 'Second', 'Third')),
	Seat varchar(6) NOT NULL,
	CustomerID int NOT NULL,
	CONSTRAINT FK_Tickets_Customers 
	FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
	FlightID int NOT NULL,
	CONSTRAINT FK_Tickets_Flights 
	FOREIGN KEY (FlightID) REFERENCES Flights(FlightID)
)

-- SECTION 2: Database manipulations
-- 01. Data insertion
INSERT INTO Towns(TownID, TownName)
VALUES
(1, 'Sofia'),
(2, 'Moscow'),
(3, 'Los Angeles'),
(4, 'Athene'),
(5, 'New York')

INSERT INTO Airports(AirportID, AirportName, TownID)
VALUES
(1, 'Sofia International Airport', 1),
(2, 'New York Airport', 5),
(3, 'Royals Airport', 1),
(4, 'Moscow Central Airport', 2)

INSERT INTO Airlines(AirlineID, AirlineName, Nationality, Rating)
VALUES
(1, 'Royal Airline', 'Bulgarian', 200),
(2, 'Russia Airlines', 'Russian', 150),
(3, 'USA Airlines', 'American', 100),
(4, 'Dubai Airlines', 'Arabian', 149),
(5, 'South African Airlines', 'African', 50),
(6, 'Sofia Air', 'Bulgarian', 199),
(7, 'Bad Airlines', 'Bad', 10)

INSERT INTO Customers(CustomerID, FirstName, LastName, DateOfBirth, Gender, HomeTownID)
VALUES
(1, 'Cassidy', 'Isacc', '19971020', 'F', 1),
(2, 'Jonathan', 'Half', '19830322', 'M', 2),
(3, 'Zack', 'Cody', '19890808', 'M', 4),
(4, 'Joseph', 'Priboi', '19500101', 'M', 5),
(5, 'Ivy', 'Indigo', '19931231', 'F', 1)

INSERT INTO Flights ([FlightID], [DepartureTime], [ArrivalTime], [Status], 
	[OriginAirportID], [DestinationAirportID], [AirlineID])
VALUES
	(1, '2016-10-13 06:00 AM', '2016-10-13 10:00 AM', 
	'Delayed', 1, 4, 1),
	(2, '2016-10-12 12:00 PM', '2016-10-12 12:01 PM', 
	'Departing', 1, 3, 2),
	(3, '2016-10-14 03:00 PM', '2016-10-20 04:00 AM', 
	'Delayed', 4, 2, 4),
	(4, '2016-10-12 01:24 PM', '2016-10-12 4:31 PM', 
	'Departing', 3, 1, 3),
	(5, '2016-10-12 08:11 AM', '2016-10-12 11:22 PM', 
	'Departing', 4, 1, 1),
	(6, '1995-06-21 12:30 PM', '1995-06-22 08:30 PM', 
	'Arrived', 2, 3, 5),
	(7, '2016-10-12 11:34 PM', '2016-10-13 03:00 AM', 
	'Departing', 2, 4, 2),
	(8, '2016-11-11 01:00 PM', '2016-11-12 10:00 PM', 
	'Delayed', 4, 3, 1),
	(9, '2015-10-01 12:00 PM', '2015-12-01 01:00 AM', 
	'Arrived', 1, 2, 1),
	(10, '2016-10-12 07:30 PM', '2016-10-13 12:30 PM', 
	'Departing', 2, 1, 7)

INSERT INTO Tickets ([TicketID], [Price], [Class], [Seat], [CustomerID], [FlightID])
VALUES
	(1, 3000.00, 'First', '233-A', 3, 8),
	(2, 1799.90, 'Second', '123-D', 1, 1),
	(3, 1200.50, 'Second', '12-Z', 2, 5),
	(4, 410.68, 'Third', '45-Q', 2, 8),
	(5, 560.00, 'Third', '201-R', 4, 6),
	(6, 2100.00, 'Second', '13-T', 1, 9),
	(7, 5500.00, 'First', '98-O', 2, 7)

-- 02. Update arrived flights 
UPDATE Flights
SET AirlineID = 1
WHERE Status = 'Arrived'

-- 03. Update tickets
UPDATE Tickets
SET Price += Price * 0.5
WHERE FlightID IN(
				SELECT FlightID
				FROM Flights
				WHERE AirlineID = (
								  SELECT AirlineID 
								  FROM Airlines 
								  WHERE Rating = (
												SELECT MAX(Rating)
												FROM Airlines
												)
								  )
			   ) 

-- 04. Table creation
CREATE TABLE CustomerReviews
(
	ReviewID int PRIMARY KEY,
	ReviewContent varchar(255) NOT NULL,
	ReviewGrade int CHECK(ReviewGrade BETWEEN 0 AND 10),
	AirlineID int,
	CONSTRAINT FK_CustomerReviews_Airlines
	FOREIGN KEY (AirlineID) REFERENCES Airlines(AirlineID),
	CustomerID int,
	CONSTRAINT FK_CustomerReviews_Customers 
	FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
)

CREATE TABLE CustomerBankAccounts
(
	AccountID int PRIMARY KEY,
	AccountNumber varchar(10) NOT NULL UNIQUE,
	Balance decimal(10, 2) NOT NULL,
	CustomerID int,
	CONSTRAINT FK_CustomerBankAccounts_Customers
	FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
)

-- 05. Fill the new tables with data 
INSERT INTO CustomerReviews ([ReviewID], [ReviewContent], [ReviewGrade], [AirlineID], [CustomerID])
VAlUES
	(1, 'Me is very happy. Me likey this airline. Me good.', 10, 1, 1),
	(2, 'Ja, Ja, Ja... Ja, Gut, Gut, Ja Gut! Sehr Gut!', 10, 1, 4),
	(3, 'Meh...', 5, 4, 3),
	(4, 'Well Ive seen better, but Ive certainly seen a lot worse...', 7, 3, 5)

INSERT INTO CustomerBankAccounts ([AccountID], [AccountNumber], [Balance], [CustomerID])
VALUES
	(1, '123456790', 2569.23, 1),
	(2, '18ABC23672', 14004568.23, 2),
	(3, 'F0RG0100N3', 19345.20, 5)

-- SECTION 3: Querying
-- 01. Extract all tickets
SELECT TicketID, Price, Class, Seat 
FROM Tickets 
ORDER BY TicketID

-- 02. Extract all customers 
SELECT CustomerID, FirstName + ' ' + LastName AS FullName, Gender
FROM Customers 
ORDER BY FullName, CustomerID

-- 03. Extract delayed flights 
SELECT FlightID, DepartureTime, ArrivalTime
FROM Flights 
WHERE Status = 'Delayed'
ORDER BY FlightID

-- 04. Extract top 5 most hightly rated airlines which have any flights
SELECT TOP(5) AirlineID, AirlineName, Nationality, Rating
FROM Airlines
WHERE AirlineID IN(SELECT AirlineID FROM Flights)
ORDER BY Rating DESC, AirlineID

-- 05. Extract all tickets with price below 5000 for first class
SELECT t.TicketID, a.AirportName AS Destination, c.FirstName + ' ' + c.LastName AS CustomerName 
FROM Tickets AS t
INNER JOIN Flights AS f
ON f.FlightID = t.FlightID
INNER JOIN Airports AS a
ON a.AirportID = f.DestinationAirportID
INNER JOIN Customers AS c
ON t.CustomerID = c.CustomerID
WHERE t.Price < 5000 and t.Class = 'First'

-- 06. Extract all customers which are departing from their home town
SELECT c.CustomerID, c.FirstName + ' ' + c.LastName AS FullName, tn.TownName AS HomeTown
FROM Customers AS c
INNER JOIN Tickets AS t
ON t.CustomerID = c.CustomerID
INNER JOIN Flights AS f
ON f.FlightID = t.FlightID
INNER JOIN Airports AS a
ON a.AirportID = f.OriginAirportID
INNER JOIN Towns AS tn
ON tn.TownID = a.TownID
WHERE a.TownID = c.HomeTownID AND f.Status = 'Departing'

-- 07. Extract all customers which will fly 
SELECT DISTINCT c.CustomerID, 
	c.FirstName + ' ' + c.LastName AS FullName,
    2016 - DATEPART(year, c.DateOfBirth) AS Age
FROM Customers AS c
INNER JOIN Tickets AS t 
ON t.CustomerID = c.CustomerID
INNER JOIN Flights AS f 
ON t.FlightID = f.FlightID
WHERE f.Status = 'Departing'
ORDER BY Age, c.CustomerID

-- 08. Extract top 3 customers which have delayed flights 
SELECT TOP(3) c.CustomerID,
	c.FirstName + ' ' + c.LastName AS FullName,
	t.Price AS TicketPrice, 
	a.AirportName AS Destination
FROM Customers AS c
INNER JOIN Tickets AS t
ON c.CustomerID = t.CustomerID
INNER JOIN Flights AS f
ON f.FlightID = t.FlightID
INNER JOIN Airports AS a
ON f.DestinationAirportID = a.AirportID
WHERE f.Status = 'Delayed'
ORDER BY t.Price DESC, CustomerID

-- 09. Extract last 5 flights which are departing
SELECT f.FlightID, f.DepartureTime, f.ArrivalTime, 
	(SELECT a.AirportName FROM Airports AS a WHERE a.AirportID = f.OriginAirportID) AS Origin,
	(SELECT a.AirportName FROM Airports AS a WHERE a.AirportID = f.DestinationAirportId) AS Destination
FROM (SELECT TOP(5) * FROM Flights AS f WHERE f.Status = 'Departing' ORDER BY f.DepartureTime DESC) AS f
ORDER BY f.DepartureTime, f.FlightID

-- 10. Extract all customers below 21 years which have already flew at least once
SELECT DISTINCT c.CustomerID, 
	c.FirstName + ' ' + c.LastName AS FullName, 
	2016 - DATEPART(year, c.DateOfBirth) AS Age
FROM Customers AS c
INNER JOIN Tickets AS t
ON t.CustomerID = c.CustomerID
INNER JOIN Flights AS f
ON f.FlightID = t.FlightID
WHERE f.Status = 'Arrived' AND 2016 - DATEPART(year, c.DateOfBirth) < 21
ORDER BY Age DESC, CustomerID

-- 11. Extract all aiports and the count of people departing from them
SELECT a.AirportID, a.AirportName, COUNT(t.CustomerID) AS Passenders
FROM Airports AS a
INNER JOIN Flights AS f 
ON a.AirportID = f.OriginAirportID
INNER JOIN Tickets AS t 
ON t.FlightID = f.FlightID
WHERE f.Status = 'Departing'
GROUP BY a.AirportID, a.AirportName
ORDER BY a.AirportID

-- SECTION 4: Programmability
-- 01. Review registering procedure 
CREATE PROCEDURE usp_SubmitReview(@customerID int, @reviewContent varchar(200), @reviewGrade float, @airlineName varchar(30))
AS
BEGIN	
		IF(@airlineName IN(SELECT a.AirlineName FROM Airlines AS a)) 
				BEGIN
				DECLARE @lastIndex int
				IF((SELECT COUNT(*) FROM CustomerReviews) = 0)
				SET @lastIndex = 1
		ELSE 
				SET @lastIndex = (SELECT MAX(ReviewID) FROM CustomerReviews) + 1
		
	   INSERT INTO CustomerReviews(ReviewID, ReviewContent, ReviewGrade, AirlineID, CustomerID)
	   VALUES 
		(@lastIndex, @reviewContent, @reviewGrade, (SELECT AirlineID FROM Airlines AS a WHERE a.AirlineName = @airlineName), @customerID)
END ELSE RAISERROR('Airline does not exist.', 16, 1)
END

-- 02. Ticket purchase procedure 
CREATE PROCEDURE usp_PurchaseTicket
				(@CustomerID int, @FlightID int, @TicketPrice decimal(8,2), @Class varchar(6), @Seat varchar(5))
AS
BEGIN
	BEGIN TRAN 
		DECLARE @CurrentBalance AS DECIMAL(10,2)
		SET @CurrentBalance = (SELECT cba.Balance FROM CustomerBankAccounts AS cba WHERE cba.CustomerID = @CustomerID)
		IF(@TicketPrice > @CurrentBalance)
			BEGIN
			RAISERROR('Insufficient bank account balance for ticket purchase.',16,2)
			ROLLBACK
		END
		ELSE
		BEGIN
			DECLARE @LastTicketID INT
			SET @LastTicketID = (SELECT TOP 1 t.TicketID FROM Tickets AS t ORDER BY t.TicketID DESC)
			INSERT INTO Tickets(TicketID, Price, Class, Seat, CustomerID, FlightID) VALUES
			(@LastTicketID + 1, @TicketPrice, @Class, @Seat, @CustomerID, @FlightID)

			UPDATE CustomerBankAccounts
			SET Balance -= @TicketPrice
			WHERE CustomerID = @CustomerID

		COMMIT TRAN PurchaseTicket
	    END
END

-- 05. Update trigger
CREATE TRIGGER tr_ArrivedFlights ON Flights FOR Update
AS
INSERT INTO ArrivedFlights(FlightID, ArrivalTime, Origin, Destination, Passengers)
SELECT i.FlightID, i.ArrivalTime, org.AirportName AS OriginAirport, de.AirportName AS DestinationAirport,
		(SELECT COUNT(*) 
		FROM Tickets
		 WHERE FlightID = i.FlightID) AS Passengers
FROM inserted AS i
INNER JOIN Airports AS org
ON org.AirportID = i.OriginAirportID
INNER JOIN Airports AS de
ON de.AirportID = i.DestinationAirportID
INNER JOIN deleted AS d 
ON d.FlightID = i.FlightID
WHERE i.Status = 'Arrived' AND d.Status != 'Arrived'