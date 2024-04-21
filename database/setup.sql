CREATE DATABASE BaseTeste;

USE BaseTeste;

CREATE TABLE Products (
    id INT PRIMARY KEY,
    name NVARCHAR(100),
    price DECIMAL(10, 2),
    image_url NVARCHAR(255)
);
GO
