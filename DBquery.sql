CREATE TABLE [Customers] (
  [id] int PRIMARY KEY IDENTITY(1, 1) NOT NULL,
  [firstName] nvarchar(255) NOT NULL,
  [lastName] nvarchar(255) NOT NULL,
)
GO

CREATE TABLE [Locations] (
  [id] int PRIMARY KEY IDENTITY(1, 1) NOT NULL,
  [name] nvarchar(255) NOT NULL,
)
GO

CREATE TABLE [Products] (
  [id] int PRIMARY KEY IDENTITY(1, 1) NOT NULL,
  [name] nvarchar(255) NOT NULL,
  [description] nvarchar(255) NOT NULL,
  [price] Money NOT NULL,
)
GO

CREATE TABLE [Order_Details] (
  [orderDetail_id] int PRIMARY KEY IDENTITY(1,1) NOT NULL,
  [order_id] int FOREIGN KEY REFERENCES [Orders](id) NOT NULL,
  [product_id] int FOREIGN KEY REFERENCES [Products](id) NOT NULL,
  [quantity] int NOT NULL
)
GO

CREATE TABLE [Orders] (
  [id] int PRIMARY KEY IDENTITY(1, 1) NOT NULL,
  [location_id] int FOREIGN KEY REFERENCES [Locations](id) NOT NULL,
  [customer_id] int FOREIGN KEY REFERENCES [Customers](id) NOT NULL,
  [created_at] datetime2 NOT NULL,
  [total] money NOT NULL,
)
GO

CREATE TABLE [Inventory] (
  [id] int PRIMARY KEY IDENTITY(1, 1) NOT NULL,
  [location_id] int FOREIGN KEY REFERENCES [Locations](id) NOT NULL,
  [product_id] int FOREIGN KEY REFERENCES [Products](id) NOT NULL,
  [quantity] int NOT NULL,
)
GO


