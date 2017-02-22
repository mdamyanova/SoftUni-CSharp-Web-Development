-- 01. Initial setup
CREATE DATABASE MinionsDB

USE MinionsDB

CREATE TABLE Towns
(
     Id int PRIMARY KEY,
     TownName varchar(50),
     Country varchar(50)
)

CREATE TABLE Minions
(
     Id int PRIMARY KEY,
     Name varchar(50),
     Age int,
     TownId int,
	 CONSTRAINT FK_Minions_Towns
	 FOREIGN KEY (TownId) REFERENCES Towns(Id) 
)


CREATE TABLE Villains 
(
     Id int PRIMARY KEY,
     Name varchar(50),
     EvilnessFactor varchar(10) CHECK(EvilnessFactor IN('good', 'bad', 'evil', 'super evil'))   
)
  
CREATE TABLE Minions_Villains
(
      MinionId int,
      VillainId int,
      CONSTRAINT PK_Minions_Villains
      PRIMARY KEY(MinionId, VillainId),
      CONSTRAINT FK_Minions_Villains_Minions 
      FOREIGN KEY (MinionId) REFERENCES Minions(Id),
      CONSTRAINT FK_Minions_Villains_Villains
      FOREIGN KEY (VillainId) REFERENCES Villains(Id)
)

INSERT INTO Towns(Id, TownName, Country) VALUES 
(1, 'Sofia', 'Bulgaria'),
(2, 'Varna', 'Bulgaria'),
(3, 'Pleven', 'Bulgaria'),
(4, 'Koprivchica', 'Bulgaria'),
(5, 'Burgas', 'Bulgaria')

INSERT INTO Minions(Id, Name, Age, TownId) VALUES 
(1, 'Sasho', 33, 1),
(2, 'Penka', 21, 2),
(3, 'Todor', 18, 3),
(4, 'Siika', 88, 4),
(5, 'Nedyalko', 90, 5)


INSERT INTO Villains(Id, Name, EvilnessFactor) VALUES 
(1, 'Radko', 'good'),
(2, 'Petur', 'evil'),
(3, 'Kichka', 'super evil'),
(4, 'Petra', 'bad'),
(5, 'Ludmil', 'evil')

INSERT INTO Minions_Villains(MinionId, VillainId) VALUES 
(1, 1),
(1, 3),
(1, 4),
(2, 2),
(3, 5),
(4, 5),
(5, 2),
(5, 3)