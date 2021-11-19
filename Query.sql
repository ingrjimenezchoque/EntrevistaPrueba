

CREATE DATABASE Prueba
GO
USE Prueba
GO

CREATE TABLE Employe(
	Id					INT PRIMARY KEY, 
	[Name]				VARCHAR(50),
	Document_number		VARCHAR(10), 
	Salary				NUMERIC(18,2),
	Age					INT,
	[Profile]			VARCHAR(30),
	Adicional1			VARCHAR(100),
	Adicional2			VARCHAR(100)
)
GO

INSERT INTO Employe VALUES(1,'RICARDO JIMENEZ','46757125',1500,30,'DEVELOPER','','')
INSERT INTO Employe VALUES(2,'BRISEIDA JIMENEZ','12345678',500,30,'DEVELOPER','','')
INSERT INTO Employe VALUES(3,'OLGA CHOQUE','23456789',800,30,'DEVELOPER','','')
INSERT INTO Employe VALUES(4,'JUAN PEREZ','345678932',900,30,'DEVELOPER','','')
INSERT INTO Employe VALUES(5,'ROBERTO MARTINEZ','98765432',5000,30,'DEVELOPER','','')
INSERT INTO Employe VALUES(6,'STEFANNY ZEVALLOS','85265473',2400,30,'DEVELOPER','','')
INSERT INTO Employe VALUES(7,'VICTOR CHOQUE','98732146',3000,30,'DEVELOPER','','')
INSERT INTO Employe VALUES(8,'ELIZABETH JIMENEZ','15975388',1500,30,'DEVELOPER','','')
INSERT INTO Employe VALUES(9,'JUAN MEJIA','00228844',1500,30,'DEVELOPER','','')
INSERT INTO Employe VALUES(10,'JUN PABLO SORIN','22777798',1500,30,'DEVELOPER','','')
Go

SELECT * FROM Employe