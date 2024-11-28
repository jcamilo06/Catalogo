CREATE DATABASE db_catalogo
GO

USE db_catalogo
GO

CREATE TABLE [Tipos_producto]
(
	[Id] INT NOT NULL IDENTITY (1, 1),
	[Nombre] NVARCHAR(50) NOT NULL UNIQUE,
	CONSTRAINT [PK_Tipos_producto] PRIMARY KEY CLUSTERED ([Id])
)
GO

INSERT INTO [Tipos_producto] ([Nombre])
VALUES
	('Zapatos'),
	('Comida'),
	('Higiene');

SELECT * FROM [Tipos_producto]

CREATE TABLE [Fabricantes]
(
	[Id] INT NOT NULL IDENTITY (1, 1),
	[Nombre] NVARCHAR(50) NOT NULL UNIQUE,
	[Contacto] NVARCHAR(15) NOT NULL UNIQUE,
	CONSTRAINT [PK_Fabricantes] PRIMARY KEY CLUSTERED ([Id])
)
GO

INSERT INTO [Fabricantes] ([Nombre], [Contacto])
VALUES
	('Nike', '312 345 6789'),
	('Nestle', '308 556 1111'),
	('Dove', '313 131 3113');

SELECT * FROM [Fabricantes]

CREATE TABLE [Productos]
(
	[Id] INT NOT NULL IDENTITY (1, 1),
	[Codigo_producto] NVARCHAR(20) NOT NULL UNIQUE,
	[Nombre_producto] NVARCHAR(50) NOT NULL UNIQUE,
	[Descripcion] NVARCHAR(250) NOT NULL UNIQUE,
	[Precio] FLOAT NOT NULL,
	[Stock] INT NOT NULL,
	[Tipo_producto] INT NOT NULL,
	[Fabricante] INT,
	CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_Tipos_producto] FOREIGN KEY ([Tipo_producto]) REFERENCES [Tipos_producto] ([Id]) ON DELETE No Action ON UPDATE No Action,
	CONSTRAINT [FK_Fabricante] FOREIGN KEY ([Fabricante]) REFERENCES [Fabricantes] ([Id]) ON DELETE No Action ON UPDATE No Action
)
GO

INSERT INTO [Productos] ([Codigo_producto], [Nombre_producto], [Descripcion], [Precio], [Stock], [Tipo_producto], [Fabricante])
VALUES
	('001', 'Chocolisto', 'Bebida refrescante', 8000, 30, 2, 2),
	('002', 'Jabon', 'Elimina el 99% de las bacterias', 3000, 100, 3, 3),
	('003', 'Air Force One', 'Edicion limitada', 600000, 50, 1, 1);

SELECT * FROM [Productos]

CREATE TABLE [Imagenes]
(
	[Id] INT NOT NULL IDENTITY (1, 1),
	[Nombre] NVARCHAR(50),
	[Url] NVARCHAR(MAX),
	CONSTRAINT [PK_Imagenes] PRIMARY KEY CLUSTERED ([Id])
)
GO

INSERT INTO [Imagenes] ([Nombre], [Url])
VALUES
	('Imagen1', NULL),
	('Imagen2', NULL),
	('Imagen3', NULL),
	('Imagen4', NULL);

SELECT * FROM [Imagenes]

CREATE TABLE [Promociones]
(
	[Id] INT NOT NULL IDENTITY (1, 1),
	[Nombre] NVARCHAR(50) NOT NULL,
	[Descuento] FLOAT NOT NULL,
	[Inicio] SMALLDATETIME NOT NULL,
	[Final] SMALLDATETIME NOT NULL,
	CONSTRAINT [PK_Promociones] PRIMARY KEY CLUSTERED ([Id])
)
GO

INSERT INTO [Promociones] ([Nombre], [Descuento], [Inicio], [Final])
VALUES
	('Promocion Diciembre', 0.5, '2024-12-01', '2025-01-07'),
	('Promocion Halloween', 0.4, '2023-10-15', '2023-11-01'),
	('Promocion Amor y Amistad', 0.05, '2026-09-20', '2026-09-22'),
	('Promocion Primavera', 0.35, '2022-02-01 12:30:00', '2022-02-28 23:59:59');

SELECT * FROM [Promociones]

CREATE TABLE [Paginas]
(
	[Id] INT NOT NULL IDENTITY (1, 1),
	[Titulo] NVARCHAR(50) NOT NULL,
	[Fecha] DATETIME2 NOT NULL,
	[Costo] FLOAT,
	[Ciudad] NVARCHAR(250) NOT NULL,
	[Producto] INT NOT NULL,
	[Imagen] INT,
	[Promocion] INT,
	CONSTRAINT [PK_Paginas] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_Producto] FOREIGN KEY ([Producto]) REFERENCES [Productos] ([Id]) ON DELETE No Action ON UPDATE No Action,
	CONSTRAINT [FK_Imagen] FOREIGN KEY ([Imagen]) REFERENCES [Imagenes] ([Id]) ON DELETE No Action ON UPDATE No Action,
	CONSTRAINT [FK_Promocion] FOREIGN KEY ([Promocion]) REFERENCES [Promociones] ([Id]) ON DELETE No Action ON UPDATE No Action
)
GO

INSERT INTO [Paginas] ([Titulo], [Fecha], [Costo], [Ciudad], [Producto], [Imagen], [Promocion])
VALUES
	('Super Chocolisto', '2024-12-20 9:00:15', 4000, 'Madrid', 1, 1, 1),
	('Nuevos Zapatos', '2024-12-10 6:45:00', 300000, 'Bogota', 3, 2, 1),
	('Mega Chocolisto', '2023-10-15 00:00:00', 4800, 'California', 1, 3, 2),
	('Jabon para Piel', '2026-09-21 18:30:30', 2850, 'Medellin', 2, 4, 3);

SELECT * FROM [Paginas]

CREATE TABLE [Auditorias]
(
	[Id] INT NOT NULL IDENTITY (1, 1),
	[Tabla] NVARCHAR(50) NOT NULL,
	[Referencia] INT NOT NULL,
	[Accion] NVARCHAR(50) NOT NULL
)
GO

SELECT * FROM [Auditorias]

CREATE TABLE [Usuarios]
(
	[Id] INT NOT NULL IDENTITY (1, 1),
	[Email] NVARCHAR(50) NOT NULL,
	[Contraseña] NVARCHAR(50) NOT NULL
)
GO

INSERT INTO [Usuarios] ([Email], [Contraseña])
VALUES
	('manu@correo.com', 000),
	('juan@correo.com', 123),
	('andres@correo.com', 810);

SELECT * FROM [Usuarios]