-- 04. Insert record in both tables
INSERT INTO Towns (Id, Name)
VALUES  (1,'Sofia'),
		(2,'Plovdiv'),
		(3,'Varna')

INSERT INTO Minions (Id, Name, Age, TownId)
VALUES (1, 'Kevin', 22, 1),
       (2, 'Bob', 15, 3),
	   (3, 'Steward', NULL, 2)

-- 05. Truncate table Minions
TRUNCATE TABLE Minions

-- 06. Drop all tables 
DROP TABLE Minions
DROP TABLE Towns

-- 07. Create table People and insert 5 records
CREATE TABLE People
(
	Id int IDENTITY(1,1) PRIMARY KEY,
	Name varchar(200) NOT NULL,
	Picture varbinary(max),
	Height float(2),
	Weight float(2),
	Gender varchar(1) NOT NULL CHECK(Gender in('f','m')),
	Birthdate date NOT NULL,
	Biography varchar(max)
)

INSERT INTO People(Name, Picture, Height, Weight, Gender, Birthdate, Biography) VALUES 
('Stancho', NULL, NULL, 100.00, 'm', '1977-05-12', NULL),
('Penka', NULL, 160, 60, 'f', '1990-06-16', 'Hello I am Penka from Bulgaria'),
('Gosho Nedqlkov', NULL, 190, 190, 'm', '1954-12-04', 'TO DO'),
('Mitka', NULL, 150, 100, 'f', '1989-10-23', NULL),
('Slavcho', NULL, 174.34, 78.94, 'm', '1974-08-14', NULL)

-- 08. Create table Users and insert 5 records
CREATE TABLE Users 
(
	Id int IDENTITY(1,1) PRIMARY KEY,
	Username varchar(30) UNIQUE NOT NULL,
	Password varchar(26) UNIQUE NOT NULL,
	ProfilePicture varbinary(900),
	LastLoginTime date,
	IsDeleted varchar(5) CHECK(IsDeleted in('true', 'false'))
)

INSERT INTO Users(Username, Password, ProfilePicture, LastLoginTime, IsDeleted)  VALUES 
('mir4o', 'tainoobichamazis', NULL, '2017-01-19', 'false'),
('slawka69', 'slav4etowe', NULL, '2016-11-23', 'false'),
('tod0r', '123456789', NULL, '2017-01-01', 'false'),
('catWoman', 'catcatcat', NULL, '2000-02-22', 'true'),
('lili', '496363', NULL, '2005-12-15', 'true')

-- 09. Change primary key
ALTER TABLE Users
DROP CONSTRAINT PK__Users

ALTER TABLE Users 
ADD CONSTRAINT PK__Users PRIMARY KEY (Id, Username)

-- 10. Add check constraint
ALTER TABLE Users
ADD CONSTRAINT CH_PasswordLength CHECK (LEN(Password) >= 5)

-- 11. Set default value of a field
ALTER TABLE Users 
ADD CONSTRAINT DF_LastLoginTime DEFAULT GETDATE() FOR LastLoginTime

-- 12. Set unique field
ALTER TABLE Users
DROP CONSTRAINT PK__Users;

ALTER TABLE Users
ADD CONSTRAINT PK__Users PRIMARY KEY (Id);

-- 13. Movies database
CREATE DATABASE Movies

CREATE TABLE Directors
(
	Id int IDENTITY PRIMARY KEY  NOT NULL,
	DirectorName varchar(50) NOT NULL,
	Notes varchar(max)
)

CREATE TABLE Genres
(
	Id int IDENTITY PRIMARY KEY NOT NULL,
	GenresName varchar(50) NOT NULL,
	Notes varchar(max) 
)

CREATE TABLE Categories
(
	Id int IDENTITY PRIMARY KEY NOT NULL,
	CategoryName varchar(50) NOT NULL,
	Notes varchar(max)
)

CREATE TABLE Movies
(
	Id int IDENTITY PRIMARY KEY  NOT NULL,
	Title varchar(50) NOT NULL,
	DirectorId int NOT NULL,
	CopyrightYear varchar(4) NOT NULL, 
	Length float NOT NULL,
	GenreId int NOT NULL,
	CategoryId int NOT NULL,
	Rating float,
	Notes varchar(max)
)

INSERT INTO Directors(DirectorName, Notes) VALUES 
('Peter Ivanov', NULL), 
('Gosho Nevenov', NULL), 
('Penka Yordanova', 'Director of movie'), 
('Iliya Iliyanov', NULL), 
('Tereza Simetlieva', NULL)

INSERT INTO Genres(GenresName, Notes) VALUES 
('Action', 'Action movie'),
('Comedy', NULL),
('Horror', NULL),
('Mystery', NULL),
('Romance', NULL)

INSERT INTO Categories(CategoryName, Notes) VALUES
('Adventure', NULL),
('Biographical', NULL),
('Drama', NULL),
('Fantasy', NULL),
('Romantic Comedy', NULL)

INSERT INTO Movies(Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes) VALUES
('Guns and roses', 1, '2014', 65.24, 1, 1, 5.00, NULL),
('Smile', 2, '1990', 90.12, 2, 2, 3.00, NULL),
('Into the woods', 3, '1999', 98.32, 3, 3, NULL, NULL),
('The clock of Minilesty street', 4, '2006', 104.54, 4, 4, 6.00, NULL),
('The golden wedding', 5, '2015', 100.90, 5, 5, 4.02, NULL)

-- 14. Car Rental database
CREATE DATABASE CarRental

CREATE TABLE Categories
(
	Id int IDENTITY PRIMARY KEY,
	Category varchar(50) NOT NULL,
	DailyRate float,
	WeeklyRate float,
	MonthlyRate float,
	WeekendRate float 
)

CREATE TABLE Cars
(
	Id int IDENTITY PRIMARY KEY,
	PlateNumber varchar(30) NOT NULL,
	Make varchar(30) NOT NULL,
	Model varchar(30) NOT NULL,
	CarYear varchar(4) NOT NULL,
	CategoryId int NOT NULL,
	Doors int NOT NULL,
	Picture varbinary(max),
	Condition varchar(20) NOT NULL,
	Available bit NOT NULL --check this
)

CREATE TABLE Employees
(
	Id int IDENTITY PRIMARY KEY,
	FirstName varchar(20) NOT NULL,
	LastName varchar(20) NOT NULL,
	Title varchar(30) NOT NULL,
	Notes varchar(max)
)

CREATE TABLE Customers
(
	Id int IDENTITY PRIMARY KEY,
	DriverLicenceNumber varchar(50) NOT NULL,
	FullName varchar(50) NOT NULL,
	Address varchar(100) NOT NULL,
	City varchar(30) NOT NULL,
	ZIPCode int NOT NULL,
	Notes varchar(max)
)

CREATE TABLE RentalOrders 
(
	Id int IDENTITY PRIMARY KEY,
	EmployeeId int NOT NULL,
	CustomerId int NOT NULL,
	CarId int NOT NULL,
	CarCondition varchar(20) NOT NULL,
	TankLevel float NOT NULL,
	KilometrageStart float NOT NULL,
	KilometrageEnd float NOT NULL,
	TotalKilometrage float NOT NULL,
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	TotalDays int NOT NULL,
	RateApplied float NOT NULL,
	TaxRate float NOT NULL,
	OrderStatus varchar(30) NOT NULL,
	Notes varchar(max)
)

INSERT INTO Categories(Category, DailyRate, WeeklyRate, MonthlyRate, WeekendRate) VALUES
('Category1', 12.22, 22.32, 46.35, 11.24),
('Category2', 43.42, 246.34, 254.64, 244.55),
('Category3', 33.33, 123.55, 244.33, 155.3)

INSERT INTO Cars(PlateNumber, Make, Model, CarYear, CategoryId, Doors, Picture, Condition, Available) VALUES
('12345', 'Make-example', 'Model-example', 1990, 1, 4, NULL, 'Brand new', 1),
('12345', 'Make-example', 'Model-example', 1967, 3, 2, NULL, 'Brand new', 0),
('12345', 'Make-example', 'Model-example', 2000, 2, 5, NULL, 'Brand new', 1)

INSERT INTO Employees(FirstName, LastName, Title, Notes) VALUES
('Georgi', 'Petrov', 'fitter', NULL),
('Georgi', 'Todorov', 'fitter', NULL),
('Jivko', 'Petrov', 'fitter', NULL)

INSERT INTO Customers(DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes) VALUES
('456677', 'Aleksander Stoychev Demirev', 'Some address', 'Kuystendil', 4344, NULL),
('ser45333', 'Mitko Mitrev Mitkev', 'Some address', 'Kuystendil', 4344, NULL),
('2348654', 'Dimitar Dimitrov Georgiev', 'Some address', 'Kuystendil', 4344, NULL)

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, CarCondition, TankLevel, KilometrageStart, 
KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes) VALUES
(1, 1, 1, 'car conditon-example', 50, 222222, 55555, 33333, '2009-01-01', '2009-01-02', 1, 11.11, 112.22, 'order status-example', NULL),
(1, 1, 1, 'car conditon-example', 50, 222222, 55555, 33333, '2009-01-01', '2009-01-02', 1, 11.11, 112.22, 'order status-example', NULL),
(1, 1, 1, 'car conditon-example', 50, 222222, 55555, 33333, '2009-01-01', '2009-01-02', 1, 11.11, 112.22, 'order status-example', NULL)

-- 15. Hotel database
CREATE DATABASE Hotel 

CREATE TABLE Employees
(
	Id int IDENTITY PRIMARY KEY,
	FirstName varchar(30) NOT NULL,
	LastName varchar(30) NOT NULL,
	Title varchar(30) NOT NULL,
	Notes varchar(max)
)

CREATE TABLE Customers
(
	AccountNumber int PRIMARY KEY,
	FirstName varchar(30) NOT NULL,
	LastName varchar(30) NOT NULL,
	PhoneNumber varchar(20) NOT NULL,
	EmergencyName varchar(30),
	EmergencyNumber int,
	Notes varchar(max)
)

CREATE TABLE RoomStatus
(
	RoomStatus varchar(20) NOT NULL,
	Notes varchar(max)
)

CREATE TABLE RoomTypes
(
	RoomType varchar(20) NOT NULL,
	Notes varchar(max)
)

CREATE TABLE BedTypes
(
	BedType varchar(20) NOT NULL,
	Notes varchar(max)
)

CREATE TABLE Rooms
(
	RoomNumber int PRIMARY KEY,
	RoomType varchar(20) NOT NULL,
	BedType varchar(20) NOT NULL,
	Rate float NOT NULL,
	RoomStatus varchar(20) NOT NULL,
	Notes varchar(max)
)

CREATE TABLE Payments 
(
	Id int IDENTITY PRIMARY KEY,
	EmployeeId int NOT NULL,
	PaymentDate DATE NOT NULL,
	AccountNumber int NOT NULL,
	FirstDateOccupied DATE NOT NULL,
	LastDateOccupied DATE NOT NULL,
	TotalDays int NOT NULL,
	AmountCharged float NOT NULL,
	TaxRate float NOT NULL,
	PaymentTotal float NOT NULL,
	Notes varchar(max)
)

CREATE TABLE Occupancies
(
	Id int IDENTITY PRIMARY KEY,
	EmployeeId int NOT NULL,
	DateOccupied DATE NOT NULL,
	AccountNumber int NOT NULL,
	RoomNumber int NOT NULL,
	RateApplied float NOT NULL,
	PhoneCharge bit NOT NULL,
	Notes varchar(max)
)

INSERT INTO Employees(FirstName, LastName, Title, Notes) VALUES
('Gena', 'Petrova', 'maid', NULL),
('Filip', 'Tihomirov', 'owner', NULL),
('Anastasia', 'Valentinova', 'cooker', NULL)

INSERT INTO Customers(AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes) VALUES
(6543, 'Lili', 'Petrova', '0835254335', 'Albena', NULL, NULL),
(12, 'Pesho', 'Georgiev', '0854245456', NULL, NULL, NULL),
(1, 'Mitra', 'Petkanova', '333333333', 'Mitra', '3333333', NULL)

INSERT INTO RoomStatus(RoomStatus, Notes) VALUES
('available', NULL),
('available', NULL),
('available', NULL)

INSERT INTO RoomTypes(RoomType, Notes) VALUES
('double', NULL),
('double', NULL),
('double', NULL)

INSERT INTO BedTypes(BedType, Notes) VALUES
('king size', NULL),
('king size', NULL),
('king size', NULL)

INSERT INTO Rooms(RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes) VALUES
(23, 'double', 'king size', 33.33, 'available', NULL),
(24, 'double', 'king size', 33.33, 'available', NULL),
(25, 'double', 'king size', 33.33, 'available', NULL)

INSERT INTO Payments(EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, PaymentTotal, Notes) VALUES
(1, '2016-12-23', 333, '2016-12-20', '2016-12-23', 3, 32.43, 33.44, 65.87, NULL),
(2, '2016-12-23', 333, '2016-12-20', '2016-12-23', 3, 32.43, 33.44, 65.87, NULL),
(3, '2016-12-23', 333, '2016-12-20', '2016-12-23', 3, 32.43, 33.44, 65.87, NULL)

INSERT INTO Occupancies(EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes) VALUES 
(1, '2016-12-09', 322, 23, 43.22, 1, NULL),
(3, '2016-12-09', 322, 24, 43.22, 1, NULL),
(2, '2016-12-09', 322, 22, 43.22, 1, NULL)

-- 16. Create SoftUni database
CREATE DATABASE SoftUni

CREATE TABLE Towns
(
	Id int IDENTITY(1,1) PRIMARY KEY,
	Name varchar(30) NOT NULL
)

CREATE TABLE Addresses
(
	Id int IDENTITY(1,1) PRIMARY KEY,
	AddressText varchar(50) NOT NULL,
	TownId int NOT NULL
)

CREATE TABLE Departments 
(
	Id int IDENTITY(1,1) PRIMARY KEY,
	Name varchar(30) NOT NULL
)

CREATE TABLE Employees
(
	Id int IDENTITY(1,1) PRIMARY KEY,
	FirstName varchar(20) NOT NULL,
	MiddleName varchar(20) NOT NULL,
	LastName varchar(20) NOT NULL,
	JobTitle varchar(30) NOT NULL,
	DepartmentId int NOT NULL,
	HireDate DATE NOT NULL,
	Salary float NOT NULL,
	AddressId int NOT NULL
)

ALTER TABLE Addresses
ADD CONSTRAINT FK_Addresses_Towns FOREIGN KEY (TownId)
REFERENCES Towns(Id)

ALTER TABLE Employees
ADD CONSTRAINT FK_Employees_Departments FOREIGN KEY (DepartmentId)
REFERENCES Departments(Id)

ALTER TABLE Employees
ADD CONSTRAINT FK_Employees_Addresses FOREIGN KEY (AddressId)
REFERENCES Addresses(Id)

-- 17. Backup database

-- 18. Basic Insert 

-- 19. Basic Select all fields

-- 20. Basic Select all fields and order them

-- 21. Basic select some fields 

-- 22. Increase employees salary

-- 23. Decrease tax rate 

-- 24. Delete all records