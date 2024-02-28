CREATE TABLE Cars (
    CarId INT PRIMARY KEY,
    CarName VARCHAR(255),
    BrandId INT,
    ColorId INT,
    ModelYear INT,
    DailyPrice INT,
    Descriptions VARCHAR(255)
);

INSERT INTO Cars (CarId, CarName, BrandId, ColorId, ModelYear, DailyPrice, Descriptions) VALUES 
(1, 'Toyota Camry', 1, 1, 2022, 100, 'Toyota Camry 2022 Red'),
(2, 'Honda Civic', 2, 2, 2021, 90, 'Honda Civic 2021 Blue'),
(3, 'Ford Focus', 3, 3, 2020, 95, 'Ford Focus 2020 Black'),
(4, 'Porsche Panamera', 4, 4, 2020, 135, 'Porsche Panamera 2020 White'),
(5, 'Lamborghini Urus', 5, 5, 2021, 125, 'Lamborghini Urus 2021 Yellow');

CREATE TABLE Brands (
    Id INT PRIMARY KEY,
    BrandName VARCHAR(255)
);

INSERT INTO Brands (Id, BrandName) VALUES 
(1, 'Toyota'),
(2, 'Honda'),
(3, 'Ford'),
(4, 'Porsche'),
(5, 'Lamborghini');

CREATE TABLE Colors (
    Id INT PRIMARY KEY,
    ColorName VARCHAR(255)
);

INSERT INTO Colors (Id, ColorName) VALUES 
(1, 'Red'),
(2, 'Blue'),
(3, 'Black'),
(4, 'White'),
(5, 'Yellow');

CREATE TABLE Customers (
    Id INT PRIMARY KEY,
    CompanyName VARCHAR(255)
);

INSERT INTO Customers (Id, CompanyName) VALUES
(1, 'Erdin LTD. ŞTİ.'),
(2, 'Demiroğ LTD. ŞTİ.');

CREATE TABLE Rentals (
    RentalId INT PRIMARY KEY,
    CarId INT,
    CustomerId INT,
    RentDate DATETIME,
    ReturnDate DATETIME
);

INSERT INTO Rentals (RentalId, CarId, CustomerId, RentDate, ReturnDate) VALUES
(1, 1, 1, '2024-02-27'),
(2, 3, 2, '2024-02-27', NULL),
(3, 5, 2, '2024-02-27', NULL),
(4, 4, 1, '2024-02-15');

CREATE TABLE Users (
    Id INT PRIMARY KEY,
    FirstName VARCHAR(255),
    LastName VARCHAR(255),
    Email VARCHAR(255),
    PasswordHash VARCHAR(255)
);

INSERT INTO Users (Id, FirstName, LastName, Email, PasswordHash) VALUES
(1, 'Muhammed', 'Erdin', 'BLABLA@gmail.com', '12345'),
(2, 'Engin', 'Demiroğ', 'blabla@gmail.com', '12345');

drop table Users;
drop table Customers;
drop table Rentals;