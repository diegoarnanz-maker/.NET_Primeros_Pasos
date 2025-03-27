CREATE DATABASE TiendaDB;
GO

USE TiendaDB;
GO

-- Tabla Productos
CREATE TABLE Productos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
    Stock INT NOT NULL
);

-- Tabla Pedidos
CREATE TABLE Pedidos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Fecha DATETIME NOT NULL DEFAULT GETDATE(),
    Total DECIMAL(10,2) NOT NULL DEFAULT 0.00
);

-- Tabla intermedia: Lineas de Pedido
CREATE TABLE LineasPedido (
    Id INT PRIMARY KEY IDENTITY(1,1),
    IdPedido INT NOT NULL,
    IdProducto INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (IdPedido) REFERENCES Pedidos(Id),
    FOREIGN KEY (IdProducto) REFERENCES Productos(Id)
);

USE TiendaDB;
GO

-- 🔹 Productos
INSERT INTO Productos (Nombre, Precio, Stock) VALUES
('Teclado Mecánico', 49.99, 100),
('Ratón Inalámbrico', 25.50, 150),
('Monitor 24 pulgadas', 159.90, 50),
('Auriculares Gamer', 79.95, 80),
('Alfombrilla RGB', 19.99, 200);

-- 🔹 Pedidos (sin total calculado aún, lo haremos manualmente aquí para probar)
INSERT INTO Pedidos (Fecha, Total) VALUES
(GETDATE(), 124.48),
(GETDATE(), 49.99);

-- 🔹 Líneas de Pedido
-- Pedido 1: compra de varios productos
INSERT INTO LineasPedido (IdPedido, IdProducto, Cantidad, PrecioUnitario) VALUES
(1, 1, 2, 49.99),  -- 2 x Teclado
(1, 2, 1, 25.50);  -- 1 x Ratón

-- Pedido 2: un solo producto
INSERT INTO LineasPedido (IdPedido, IdProducto, Cantidad, PrecioUnitario) VALUES
(2, 1, 1, 49.99);  -- 1 x Teclado
