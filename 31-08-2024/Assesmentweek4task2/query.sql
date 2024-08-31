CREATE DATABASE Week4Assessment;
USE Week4Assessment;

CREATE TABLE Medication (
    HospitalID INT ,
    DoctorName NVARCHAR(100) NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    Dosage DOUBLE PRECISION
);

INSERT INTO Medication (HospitalID, DoctorName, Name, Dosage) VALUES 
(133,'Sanjay','Dolo',600.5),
(124,'Dijol','aerostol',550),
(123,'Sanjay','Paracetamol',650);

SELECT * FROM Medication;
