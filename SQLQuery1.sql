Create table Cars 
(
CarId int, CarName varchar(255), BrandId int, ColorId int, 
ModelYear int, DailyPrice int, Descriptions varchar(255)
);
INSERT INTO Cars (CarId, CarName, BrandId, ColorId, ModelYear, DailyPrice, Descriptions) VALUES 
(1, 'Toyota', 1, 1, 2022, 100, 'Toyota Camry 2022 Red'),
(2, 'Honda', 2, 2, 2021, 90, 'Honda Civic 2021 Blue'),
(3, 'Ford', 3, 3, 2020, 95, 'Ford Focus 2020 Black'),
(4, 'Porsche', 4, 4, 2020, 135, 'Porsche Panamera 2020 White'),
(5, 'Lamborghini', 5, 5, 2021, 125, 'Lamborghini Urus 2021 Yellow');

--UPDATE Cars Set CarName='Ferrari', BrandId=6, ModelYear=2021, DailyPrice=120, Descriptions='Ferrari SF90 2021 Red' Where Id=1; Güncelleme yapılacaksa bu şekilde yapılabilir
--Delete From Cars Where Id=1;
--Drop table cars;
--drop table brands;
--drop table colors;

Create table Brands
(
Id int, BrandName varchar(255)
);
INSERT INTO Brands (Id, BrandName) VALUES 
(1, 'Toyota'),
(2, 'Honda'),
(3, 'Ford'),
(4, 'Porsche'),
(5, 'Lamborghini');

create table Colors
(
Id int, ColorName varchar(255)
);
INSERT INTO Colors (Id, ColorName) VALUES 
(1, 'Red'),
(2, 'Blue'),
(3, 'Black'),
(4, 'White'),
(5, 'Yellow');

Create table Customers
(
UserId int, CompanyName varchar(255)
);
INSERT INTO Customers (UserId, CompanyName) VALUES
(1, 'Demiroğ LTD. ŞTİ.'),
(2, 'Erdin LTD. ŞTİ.');

Create table Rentals
(
RentalId int, CarId int, CustomerId int, RentDate DateTime
);
INSERT INTO Rentals (RentalId, CarId, CustomerId, RentDate) VALUES
(1, 1, 1,22-10-22);

Create table Users
(
Id int, FirstName varchar(255), LastName varchar(255), Email varchar(255), Password varchar(255)
);
INSERT INTO Users (Id, FirstName, LastName, Email, Password) VALUES
(1, 'Muhammed', 'Erdin', 'BLABLA@gmail.com', '12345');