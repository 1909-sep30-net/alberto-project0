
INSERT INTO dbo.Customers VALUES ('Alex', 'Rodriguez');
INSERT INTO dbo.Customers VALUES ('Timmy', 'Loss');
INSERT INTO dbo.Customers VALUES ('Joe', 'Brauc');

Select * From Customers;
INSERT INTO dbo.Locations VALUES ('Starbucks');
INSERT INTO dbo.Locations VALUES ('Chick-Fil-A');
INSERT INTO dbo.Locations VALUES ('BurgerIM');

SELECT * FROM Locations;

INSERT INTO [Products] VALUES ('Caramel Frappachino', 'Venti', 6.50);
INSERT INTO dbo.Products VALUES ('White Mocha Hot', 'Grande', 5.20);
INSERT INTO dbo.Products VALUES ('Pumpkin Spice Machiatto', 'Venti', 6.50);
GO
INSERT INTO dbo.Products VALUES ('Chicken Sandwich', 'Meal', 8.75);
INSERT INTO dbo.Products VALUES ('Grilled Nuggets', 'Meal', 5.20);
INSERT INTO dbo.Products VALUES ('Spicy Chicken Sandwhich', 'single', 5.50);
GO
INSERT INTO dbo.Products VALUES ('Mini Trio', 'Meal', 8.75);
INSERT INTO dbo.Products VALUES ('Angus Beef', 'Single', 6.99);
INSERT INTO dbo.Products VALUES ('Wings', 'Wednesday Special', 0.75);
GO
Select * FROM Products;

INSERT INTO Inventory  VALUES (1,1,20);
INSERT INTO Inventory  VALUES (1,2,20);
INSERT INTO Inventory  VALUES (1,3,20);
GO
INSERT INTO Inventory  VALUES (2,4,20);
INSERT INTO Inventory  VALUES (2,5,20);
INSERT INTO Inventory  VALUES (2,6,20);
GO
INSERT INTO Inventory  VALUES (3,7,20);
INSERT INTO Inventory  VALUES (3,8,20);
INSERT INTO Inventory  VALUES (3,9,20);

Select * FROM Inventory;

INSERT INTO [Orders] VALUES (1,1,'20191013 10:34:09 AM',10.43);

SELECT * FROM [Orders];

INSERT INTO Order_Details(order_id,product_id,quantity) VALUES (1,1,5);



SELECT * FROM Inventory;

Select * From Customers;
SELECT * FROM Products;
SELECT * FROM Locations;