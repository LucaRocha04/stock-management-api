-- Script para crear la base de datos del Sistema de Ventas
-- Ejecutar en MySQL Command Line o MySQL Workbench

-- 1. Crear la base de datos
CREATE DATABASE IF NOT EXISTS sistema_ventas 
CHARACTER SET utf8mb4 
COLLATE utf8mb4_unicode_ci;

-- 2. Usar la base de datos
USE sistema_ventas;

-- 3. Crear tabla Productos
CREATE TABLE IF NOT EXISTS Productos (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Codigo VARCHAR(20) NOT NULL UNIQUE,
    Nombre VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(500),
    Precio DECIMAL(10,2) NOT NULL,
    Stock INT NOT NULL DEFAULT 0,
    Categoria VARCHAR(50) NOT NULL,
    FechaCreacion DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    Activo BOOLEAN NOT NULL DEFAULT TRUE,
    INDEX idx_codigo (Codigo),
    INDEX idx_nombre (Nombre),
    INDEX idx_categoria (Categoria)
);

-- 4. Crear tabla Ventas
CREATE TABLE IF NOT EXISTS Ventas (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Fecha DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    Cliente VARCHAR(100) NOT NULL,
    DocumentoCliente VARCHAR(20),
    Subtotal DECIMAL(10,2) NOT NULL DEFAULT 0,
    Impuesto DECIMAL(10,2) NOT NULL DEFAULT 0,
    Total DECIMAL(10,2) NOT NULL DEFAULT 0,
    FormaPago VARCHAR(20) NOT NULL DEFAULT 'Efectivo',
    Observaciones VARCHAR(500),
    Activa BOOLEAN NOT NULL DEFAULT TRUE,
    INDEX idx_fecha (Fecha),
    INDEX idx_cliente (Cliente)
);

-- 5. Crear tabla DetallesVenta
CREATE TABLE IF NOT EXISTS DetallesVenta (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    VentaId INT NOT NULL,
    ProductoId INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10,2) NOT NULL,
    Descuento DECIMAL(5,2) NOT NULL DEFAULT 0,
    Subtotal DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (VentaId) REFERENCES Ventas(Id) ON DELETE CASCADE,
    FOREIGN KEY (ProductoId) REFERENCES Productos(Id) ON DELETE RESTRICT,
    INDEX idx_venta (VentaId),
    INDEX idx_producto (ProductoId)
);

-- 6. Insertar datos de prueba
INSERT INTO Productos (Codigo, Nombre, Descripcion, Precio, Stock, Categoria, FechaCreacion) VALUES
('PROD001', 'Laptop Dell Inspiron', 'Laptop Dell Inspiron 15, Intel i5, 8GB RAM, 256GB SSD', 850.00, 10, 'Computadoras', NOW() - INTERVAL 30 DAY),
('PROD002', 'Mouse Logitech', 'Mouse inalámbrico Logitech MX Master 3', 45.00, 25, 'Accesorios', NOW() - INTERVAL 25 DAY),
('PROD003', 'Teclado Mecánico', 'Teclado mecánico retroiluminado RGB', 75.00, 15, 'Accesorios', NOW() - INTERVAL 20 DAY),
('PROD004', 'Monitor Samsung 24"', 'Monitor Samsung 24 pulgadas Full HD', 180.00, 8, 'Monitores', NOW() - INTERVAL 15 DAY),
('PROD005', 'Impresora HP LaserJet', 'Impresora láser HP LaserJet Pro', 220.00, 5, 'Impresoras', NOW() - INTERVAL 10 DAY);

-- Verificar que todo se creó correctamente
SELECT 'Base de datos creada exitosamente' as Resultado;
SELECT COUNT(*) as ProductosInsertados FROM Productos;

-- Mostrar estructura de las tablas
SHOW TABLES;