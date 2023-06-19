GO
CREATE DATABASE E_COMMERCE12
GO
USE E_COMMERCE12
GO
CREATE TABLE Marcas (
    ID_Marca BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(20) NOT NULL, 
    Estado BIT NULL DEFAULT 1
)
GO
CREATE TABLE Categorias (
    ID_Categoria BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(20) NOT NULL, 
    Estado BIT NULL DEFAULT 1
)
GO
CREATE TABLE Productos (
    ID_Producto BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    ID_Categoria BIGINT NOT NULL FOREIGN KEY REFERENCES Categorias(ID_Categoria),
    ID_Marca BIGINT NOT NULL FOREIGN KEY REFERENCES Marcas(ID_Marca),
    Codigo VARCHAR(15) UNIQUE NOT NULL,
    Nombre VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(500) NOT NULL,
    Precio MONEY NOT NULL CHECK (Precio > 0),
    Stock INT NOT NULL CHECK (Stock > 0),
    Estado BIT NULL DEFAULT 1,
)
GO
CREATE TABLE Facturas (
	ID_Factura BIGINT identity(1,1) PRIMARY KEY,
	Pago BIT DEFAULT 0 NOT NULL,
	Cancelada BIT DEFAULT 0 NOT NULL,
)
GO
CREATE TABLE Productos_x_Factura (
    ID_Factura BIGINT NOT NULL REFERENCES Facturas (ID_Factura),
    ID_Producto BIGINT NOT NULL FOREIGN KEY REFERENCES Productos (ID_Producto),
    Cantidad INT NOT NULL CHECK(Cantidad > 0)
)
GO
CREATE TABLE EstadoVenta(
	ID_Estado BIGINT PRIMARY KEY identity(1,1),
	Estado VARCHAR(100) NOT NULL,
)
GO
CREATE TABLE TipoUsuario (
    ID_Tipo BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(20) NOT NULL
)
GO
CREATE TABLE Provincias (
    ID_Provincia BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(20) NOT NULL
)
GO
CREATE TABLE Domicilios (
    ID_Domicilio BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    ID_Provincia BIGINT NOT NULL FOREIGN KEY REFERENCES Provincias(ID_Provincia),
    Localidad VARCHAR(20) NOT NULL,
    Calle VARCHAR(20) NOT NULL,
    Numero VARCHAR(6) NOT NULL,
    CodigoPostal VARCHAR(6) NOT NULL,
    Piso VARCHAR(6) NULL,
    Referencia VARCHAR(50) NULL,
    Alias VARCHAR(20) NULL,
    Estado BIT NULL DEFAULT 1,

)
GO
CREATE TABLE Usuarios (
    ID_Usuario BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    ID_TipoUsuario BIGINT NOT NULL FOREIGN KEY REFERENCES TipoUsuario(ID_Tipo),
    ID_Domicilio BIGINT NULL FOREIGN KEY REFERENCES Domicilios(ID_Domicilio),
    Dni VARCHAR(10) NOT NULL UNIQUE,
    Nombre VARCHAR(15) NOT NULL,
    Apellido VARCHAR(15) NOT NULL,
    Email VARCHAR(50) NOT NULL UNIQUE,
    Contrasena VARCHAR(20) NOT NULL, 
    Telefono VARCHAR(15) NOT NULL,
    FechaNacimiento DATE NOT NULL,
    Estado BIT NULL DEFAULT 1,
)
GO
CREATE TABLE Ventas (
    ID_Venta BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    ID_Factura BIGINT NOT NULL FOREIGN KEY REFERENCES Facturas (ID_Factura),
    ID_Usuario BIGINT NOT NULL FOREIGN KEY REFERENCES Usuarios (ID_Usuario),
    ID_Estado BIGINT NOT NULL FOREIGN KEY REFERENCES EstadoVenta (ID_Estado),
    Fecha DATETIME DEFAULT GETDATE()
)
GO
CREATE TABLE Imagenes (
    ID_Imagen BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    ID_Producto BIGINT NOT NULL FOREIGN KEY REFERENCES Productos(ID_Producto),
    ImagenURL VARCHAR(1000) NOT NULL,
    Descripcion VARCHAR(50) NOT NULL,
    Estado BIT NULL DEFAULT 1,
)
GO
CREATE TABLE Comentarios (
    ID_Comentario BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    ID_Producto BIGINT NOT NULL FOREIGN KEY REFERENCES Productos (ID_Producto),
    ID_Usuario BIGINT NOT NULL FOREIGN KEY REFERENCES Usuarios (ID_Usuario),
    Comentario VARCHAR(150) NOT NULL,
    Fecha DATETIME DEFAULT GETDATE(),
    Estado BIT NULL DEFAULT 1
)

----------------------------------------------------------------------------------
------------------------- ***** STORED PROCEDURES **** ---------------------------

---------------------------------
---------- USUARIOS ------------
GO
CREATE PROCEDURE SP_UsuarioPorID(
    @IDUsuario BIGINT
)
AS
BEGIN
    SELECT ID_Usuario, ID_TipoUsuario, TU.Nombre as TipoUsuario, Dni, U.Nombre, Apellido, Email, Telefono, FechaNacimiento, U.Estado,
    D.ID_Domicilio, D.ID_Provincia as ID_Provincia, P.Nombre as Provincia, D.Localidad, D.Calle, D.Numero, D.CodigoPostal, D.Piso, D.Referencia, D.Alias, D.Estado as EstadoDomicilio
    FROM Usuarios U
    INNER JOIN TipoUsuario TU ON U.ID_TipoUsuario = TU.ID_Tipo
    INNER JOIN Domicilios D ON U.ID_Domicilio = D.ID_Domicilio
    INNER JOIN Provincias P ON D.ID_Provincia = P.ID_Provincia
    WHERE ID_Usuario = @IDUsuario
END

---------------------------------
---------- PRODUCTOS ------------
GO
CREATE PROCEDURE SP_ListarTodosLosProductos -- TODOS LOS PRODUCTOS
AS
BEGIN
    SELECT P.ID_Producto AS IDProducto, P.Nombre, P.Codigo, P.Descripcion, P.ID_Categoria AS IDCategoria, C.Nombre as Categoria, P.ID_Marca as IDMarca, M.Nombre as Marca, P.Precio, P.Estado, P.Stock
    FROM Productos P 
    INNER JOIN Marcas M ON P.ID_Marca = M.ID_Marca
    INNER JOIN Categorias C ON P.ID_Categoria = C.ID_Categoria
END

GO
CREATE PROCEDURE SP_ProductosPorCategoria( -- PRODUCTOS POR CATEGORIA
    @Categoria VARCHAR(20)
)
AS
BEGIN
    SELECT P.ID_Producto AS IDProducto, P.Nombre, P.Codigo, P.Descripcion, P.ID_Categoria AS IDCategoria, C.Nombre as Categoria, P.ID_Marca as IDMarca, M.Nombre as Marca, P.Precio, P.Estado, P.Stock
    FROM Productos P 
    INNER JOIN Marcas M ON P.ID_Marca = M.ID_Marca
    INNER JOIN Categorias C ON P.ID_Categoria = C.ID_Categoria
    WHERE C.Nombre = @Categoria
END

GO
CREATE PROCEDURE SP_ProductosPorMarca( -- PRODUCTOS POR  MARCA
    @Marca VARCHAR(20)
)
AS
BEGIN
    SELECT P.ID_Producto AS IDProducto, P.Nombre, P.Codigo, P.Descripcion, P.ID_Categoria AS IDCategoria, C.Nombre as Categoria, P.ID_Marca as IDMarca, M.Nombre as Marca, P.Precio, P.Estado, P.Stock
    FROM Productos P 
    INNER JOIN Marcas M ON P.ID_Marca = M.ID_Marca
    INNER JOIN Categorias C ON P.ID_Categoria = C.ID_Categoria
    WHERE M.Nombre = @Marca
END

GO
CREATE PROCEDURE SP_ProductosPorCategoriaMarca( -- PRODUCTOS POR CATEGORIA Y MARCA
    @Categoria VARCHAR(20),
    @Marca VARCHAR(20)
)
AS
BEGIN
    SELECT P.ID_Producto AS IDProducto, P.Nombre, P.Codigo, P.Descripcion, P.ID_Categoria AS IDCategoria, C.Nombre as Categoria, P.ID_Marca as IDMarca, M.Nombre as Marca, P.Precio, P.Estado, P.Stock
    FROM Productos P 
    INNER JOIN Marcas M ON P.ID_Marca = M.ID_Marca
    INNER JOIN Categorias C ON P.ID_Categoria = C.ID_Categoria
    WHERE M.Nombre = @Marca AND C.Nombre = @Categoria
END

GO
CREATE PROCEDURE SP_ProductosAlAzar( -- PRODUCTOS AL AZAR
    @Cantidad int
)
AS
BEGIN
    SELECT TOP (@Cantidad) P.ID_Producto AS IDProducto, P.Nombre, P.Codigo, P.Descripcion, P.ID_Categoria AS IDCategoria, C.Nombre as Categoria, P.ID_Marca as IDMarca, M.Nombre as Marca, P.Precio, P.Estado, P.Stock
    FROM Productos P 
    INNER JOIN Marcas M ON P.ID_Marca = M.ID_Marca
    INNER JOIN Categorias C ON P.ID_Categoria = C.ID_Categoria
    ORDER BY NEWID()
END

GO
CREATE PROCEDURE SP_ProductoPorID( -- PRODUCTO POR ID
    @IDProducto int
)
AS
BEGIN
    SELECT P.ID_Producto AS IDProducto, P.Nombre, P.Codigo, P.Descripcion, P.ID_Categoria AS IDCategoria, C.Nombre as Categoria, P.ID_Marca as IDMarca, M.Nombre as Marca, P.Precio, P.Estado, P.Stock
    FROM Productos P 
    INNER JOIN Marcas M ON P.ID_Marca = M.ID_Marca
    INNER JOIN Categorias C ON P.ID_Categoria = C.ID_Categoria
    WHERE P.ID_Producto = @IDProducto
END

------------------------------
---------- IMAGENES ----------

GO
CREATE PROCEDURE SP_ImagenesAlAzar( -- IMAGENES AL AZAR
    @Cantidad int
)
AS
BEGIN
    SELECT TOP (@Cantidad) I.ID_Producto, I.ID_Imagen, I.ImagenURL, I.Descripcion, I.Estado
    FROM Imagenes I
    ORDER BY NEWID()
END

GO
CREATE PROCEDURE SP_ImagenesRandomPorCategoria( -- IMAGENES AL AZAR POR CATEGORIA
    @Cantidad INT,
    @Categoria VARCHAR(20)
)
AS
BEGIN
    SELECT TOP (@Cantidad) I.ID_Producto, I.ID_Imagen, I.ImagenURL, I.Descripcion, I.Estado
    FROM Imagenes I
    INNER JOIN Productos P ON I.ID_Producto = P.ID_Producto
    INNER JOIN Categorias C ON P.ID_Categoria = C.ID_Categoria
    WHERE C.Nombre = @Categoria
    ORDER BY NEWID()
END

GO
CREATE PROCEDURE SP_ImagenesRandomPorMarca( -- IMAGENES AL AZAR POR MARCA
    @Cantidad int,
    @Marca VARCHAR(20)
)
AS
BEGIN
    SELECT TOP (@Cantidad) I.ID_Producto, I.ID_Imagen, I.ImagenURL, I.Descripcion, I.Estado
    FROM Imagenes I
    INNER JOIN Productos P ON I.ID_Producto = P.ID_Producto
    INNER JOIN Marcas M ON P.ID_Marca = M.ID_Marca
    WHERE M.Nombre = @Marca
    ORDER BY NEWID()
END


----------------------------
---------- MARCAS ----------
GO
CREATE PROCEDURE SP_ListarMarcas -- TODAS LAS MARCAS
AS
BEGIN
    SELECT M.Estado, M.Nombre, M.ID_Marca FROM Marcas AS M
END

GO
CREATE PROCEDURE SP_MarcasRandom( -- MARCAS AL AZAR
    @Cantidad int
)
AS
BEGIN
    SELECT TOP (@Cantidad) M.ID_Marca, M.Nombre, M.Estado
    FROM Marcas M
    ORDER BY NEWID()
END


--------------------------------
---------- CATEGORIAS ----------
GO
CREATE PROCEDURE SP_ListarCategorias -- TODAS LAS CATEGORIAS
AS
BEGIN
    SELECT C.ID_Categoria, C.Nombre, C.Estado FROM Categorias AS C
END

GO
CREATE PROCEDURE SP_CategoriasRandom( -- CATEGORIAS AL AZAR
    @Cantidad int
)
AS
BEGIN
    SELECT TOP (@Cantidad) C.ID_Categoria, C.Nombre, C.Estado
    FROM Categorias C
    ORDER BY NEWID()
END


-------------------------------------------------------------------------
------------------------- ***** TRIGGERS **** ---------------------------

---------- IMAGENES TRIGGER ISTEAD OF DELETE ----------
GO
CREATE TRIGGER TR_DeleteImagen ON Imagenes
INSTEAD OF DELETE
AS
BEGIN
    DECLARE @IDImagen INT
    SELECT @IDImagen = ID_Imagen FROM deleted
    UPDATE Imagenes SET Estado = 0 WHERE ID_Imagen = @IDImagen
END