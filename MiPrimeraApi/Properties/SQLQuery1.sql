-- Crear la base de datos (si aún no existe)
CREATE DATABASE EmpleadosDB;
GO

-- Usar la base de datos
USE EmpleadosDB;
GO

-- Crear la tabla Empleados
CREATE TABLE Empleados (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Cargo NVARCHAR(100) NOT NULL,
    Salario DECIMAL(10, 2) NOT NULL
);
GO

-- Insertar datos de prueba
INSERT INTO Empleados (Nombre, Cargo, Salario) VALUES 
('Juan Pérez', 'Desarrollador', 2500.00),
('Laura Gómez', 'Diseñadora UX', 2300.00),
('Carlos Ruiz', 'Analista de datos', 2700.00);
GO
