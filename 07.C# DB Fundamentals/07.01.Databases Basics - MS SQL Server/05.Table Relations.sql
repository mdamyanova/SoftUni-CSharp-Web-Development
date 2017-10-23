-- 01. One-to-one relationship
CREATE DATABASE Test

CREATE TABLE Persons 
(
	PersonID int PRIMARY KEY,
	FirstName varchar(50) NOT NULL,
	Salary float NOT NULL,
	PassportID int NOT NULL
)

CREATE TABLE Passports
(
	PassportID int PRIMARY KEY,
	PassportNumber varchar(50) NOT NULL
)

INSERT INTO Passports(PassportID, PassportNumber) VALUES
(101, 'N34FG21B'),
(102, 'K65LO4R7'),
(103, 'ZE657QP2')

INSERT INTO Persons(PersonID, FirstName, Salary, PassportID) VALUES 
(1, 'Roberto', 43300.00, 102),
(2, 'Tom', 56100.00, 103),
(3, 'Yana', 60200.00, 101)

ALTER TABLE Persons
ADD CONSTRAINT FK_Persons_Passwords
FOREIGN KEY (PassportID)
REFERENCES Passports(PassportID)

-- 02. One-to-many relationship
CREATE TABLE Models
(
	ModelID int PRIMARY KEY,
	Name varchar(50) NOT NULL,
	ManufacturerID int NOT NULL
)

CREATE TABLE Manufacturers
(
	ManufacturerID int PRIMARY KEY,
	Name varchar(50) NOT NULL,
	EstablishedOn DATE NOT NULL
)

INSERT INTO Models(ModelID, Name, ManufacturerID) VALUES
(101, 'X1', 1),
(102, 'i6', 1),
(103, 'Model S', 2),
(104, 'Model X', 2),
(105, 'Model 3', 2),
(106, 'Nova', 3)

INSERT INTO Manufacturers(ManufacturerID, Name, EstablishedOn) VALUES
(1, 'BMW', '07/03/1916'),
(2, 'Tesla', '01/01/2003'),
(3, 'Lada', '01/05/1966')

ALTER TABLE Models
ADD CONSTRAINT FK_Models_Manufacturers
FOREIGN KEY (ManufacturerID)
REFERENCES Manufacturers(ManufacturerID)

-- 03. Many-to-many relationship
CREATE TABLE Students 
(
	StudentID int PRIMARY KEY,
	Name varchar(50) NOT NULL
)

CREATE TABLE Exams
(
	ExamID int PRIMARY KEY,
	Name varchar(50) NOT NULL
)

CREATE TABLE StudentsExams
(
	StudentID int,
	ExamID int,
	CONSTRAINT PK_StudentsExams
	PRIMARY KEY(StudentID, ExamID),

	CONSTRAINT FK_StudentsExams_Students
	FOREIGN KEY (StudentID)
	REFERENCES Students(StudentID),

	CONSTRAINT FK_StudentsExams_Exams
	FOREIGN KEY (ExamID)
	REFERENCES Exams(ExamID)
)

INSERT INTO Students(StudentID, Name) VALUES
(1, 'Mila'),
(2, 'Toni'),
(3, 'Ron')

INSERT INTO Exams(ExamID, Name) VALUES
(101, 'SpringMVC'),
(102, 'Neo4j'),
(103, 'Oracle 11g')

INSERT INTO StudentsExams(StudentID, ExamID) VALUES
(1, 101),
(1, 102),
(2, 101),
(3, 103),
(2, 102),
(2, 103)

-- 04. Self-referencing
CREATE TABLE Teachers
(
	TeacherID int PRIMARY KEY,
	Name varchar(50) NOT NULL,
	ManagerID int 
)

INSERT INTO Teachers VALUES
(101, 'John', NULL),
(102, 'Maya', 106),
(103, 'Silvia', 106),
(104, 'Ted', 105),
(105, 'Mark', 101),
(106, 'Greta', 101)

ALTER TABLE Teachers
ADD CONSTRAINT FK_Teacher_Manager
FOREIGN KEY (ManagerID)
REFERENCES Teachers(TeacherID)

-- 05. Online store database
CREATE DATABASE OnlineStore
CREATE TABLE Orders 
(
	OrderID int PRIMARY KEY,
	CustomerID int NOT NULL
)

CREATE TABLE Customers
(
	CustomerID int PRIMARY KEY,
	Name varchar(50) NOT NULL,
	Birthday DATE NOT NULL,
	CityID int NOT NULL
)

CREATE TABLE Cities 
(
	CityID int PRIMARY KEY,
	Name varchar(50) NOT NULL
)

ALTER TABLE Customers
ADD CONSTRAINT FK_Customer_City
FOREIGN KEY (CityID)
REFERENCES Cities(CityID)

ALTER TABLE Orders
ADD CONSTRAINT FK_Order_Customer
FOREIGN KEY (CustomerID)
REFERENCES Customers(CustomerID)

CREATE TABLE Items
(
	ItemID int PRIMARY KEY,
	Name varchar(50) NOT NULL,
	ItemTypeID int NOT NULL
)

CREATE TABLE ItemTypes
(
	ItemTypeID int PRIMARY KEY,
	Name varchar(50) NOT NULL
)

CREATE TABLE OrderItems
(
	OrderID int NOT NULL,
	ItemID int NOT NULL
)

ALTER TABLE Items
ADD CONSTRAINT FK_Item_ItemType
FOREIGN KEY (ItemTypeID)
REFERENCES ItemTypes(ItemTypeID)

ALTER TABLE OrderItems
ADD CONSTRAINT PK_OrderItems
PRIMARY KEY (OrderID, ItemID)

ALTER TABLE OrderItems 
ADD CONSTRAINT FK_OrderItem_Order
FOREIGN KEY (OrderID)
REFERENCES Orders(OrderId)

ALTER TABLE OrderItems
ADD CONSTRAINT FK_OrderItem_Item
FOREIGN KEY (ItemID)
REFERENCES Items(ItemID)

-- 06. University database 
CREATE DATABASE University
CREATE TABLE Majors
(	
	MajorID int PRIMARY KEY,
	Name varchar(50) NOT NULL
)

CREATE TABLE Subjects 
(
	SubjectID int PRIMARY KEY,
	SubjectName varchar(50) NOT NULL
)

CREATE TABLE Students
(
	StudentID int PRIMARY KEY,
	StudentNumber varchar(20) NOT NULL,
	StudentName varchar(50) NOT NULL,
	MajorID int NOT NULL,	

	CONSTRAINT FK_Students_Majors
	FOREIGN KEY (MajorID) REFERENCES Majors(MajorID)
)

CREATE TABLE Agenda
(
	StudentID int NOT NULL,
	SubjectID int NOT NULL,
	
	CONSTRAINT PK_Students_Subjects
	PRIMARY KEY (StudentID, SubjectID),

	CONSTRAINT FK_Student_Students
	FOREIGN KEY (StudentID) REFERENCES Students(StudentID),

	CONSTRAINT FK_Subject_Subjects 
	FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
)

CREATE TABLE Payments 
(
	PaymentID int PRIMARY KEY,
	PaymentDate DATE NOT NULL,
	PaymentAmount float NOT NULL,
	StudentID int NOT NULL,

	CONSTRAINT FK_Payments_Students
	FOREIGN KEY (StudentID) REFERENCES Students(StudentID)
)

-- 09. Peaks in Rila
SELECT 
	(SELECT MountainRange FROM Mountains WHERE MountainRange = 'Rila') AS MountainRange, 
PeakName, 
Elevation
FROM Peaks
WHERE MountainId = 17
ORDER BY Elevation DESC