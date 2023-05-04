using System.Collections.Generic;
using System.Xml.Linq;

//CREATE TABLE Categories (
//    Id INT PRIMARY KEY IDENTITY(1,1),
//    Name NVARCHAR(50) NOT NULL
//);

//CREATE TABLE Products (
//    Id INT PRIMARY KEY IDENTITY(1,1),
//    Name NVARCHAR(50) NOT NULL,
//    Price DECIMAL(18,2) NOT NULL,
//    CategoryId INT NOT NULL,
//    FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
//);


//CREATE TABLE Orders (
//	ID INT PRIMARY KEY IDENTITY(1,1),
//    Date DATETIME NOT NULL,
//    TotalPrice DECIMAL(18, 2) NOT NULL
//);
//CREATE TABLE OrderDetails(
//	id INT PRIMARY KEY IDENTITY(1,1),
//    OrderId INT,
//    ProductId INT NOT NULL
//	FOREIGN KEY (ProductId) REFERENCES Products(Id),
//	Quantity INT
//);



//INSERT INTO Categories (Name) VALUES('Beverages');
//INSERT INTO Categories (Name) VALUES('Food and Accessories');

//INSERT INTO Products (Name, Price, CategoryId) VALUES('Coffee', 25.00, 1);
//INSERT INTO Products (Name, Price, CategoryId) VALUES('Tea', 15.50, 1);
//INSERT INTO Products (Name, Price, CategoryId) VALUES('Milk', 10.00, 1);
//INSERT INTO Products (Name, Price, CategoryId) VALUES('Sugar', 1.00, 2);
//INSERT INTO Products (Name, Price, CategoryId) VALUES('Butter', 4.00, 2);
//INSERT INTO Products (Name, Price, CategoryId) VALUES('Jam', 4.00, 2);



//drop table Categories;
//drop table Products;
//drop table Orders;
//drop table OrderDetails;