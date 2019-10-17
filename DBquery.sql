CREATE TABLE [Customer] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [full_name] nvarchar(255)
)
GO

CREATE TABLE [Location] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [name] nvarchar(255),
  [product_id] int
)
GO

CREATE TABLE [Product] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [name] nvarchar(255),
  [description] nvarchar(255),
  [price] decimal,
  [quantity] int
)
GO

CREATE TABLE [Order_Details] (
  [order_id] int,
  [product_id] int,
  [quantity] int
)
GO

CREATE TABLE [Orders] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [location_id] int,
  [customer_id] int,
  [created_at] nvarchar(255),
  [total] decimal,
  [quantity] int
)
GO

CREATE TABLE [Inventory] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [location_id] int,
  [product_id] int,
  [quantity] int
)
GO

ALTER TABLE [Product] ADD FOREIGN KEY ([id]) REFERENCES [Location] ([product_id])
GO

ALTER TABLE [Order_Details] ADD FOREIGN KEY ([order_id]) REFERENCES [Orders] ([id])
GO

ALTER TABLE [Order_Details] ADD FOREIGN KEY ([product_id]) REFERENCES [Product] ([id])
GO

ALTER TABLE [Orders] ADD FOREIGN KEY ([location_id]) REFERENCES [Location] ([id])
GO

ALTER TABLE [Orders] ADD FOREIGN KEY ([customer_id]) REFERENCES [Customer] ([id])
GO

ALTER TABLE [Inventory] ADD FOREIGN KEY ([location_id]) REFERENCES [Location] ([id])
GO

ALTER TABLE [Inventory] ADD FOREIGN KEY ([product_id]) REFERENCES [Product] ([id])
GO
