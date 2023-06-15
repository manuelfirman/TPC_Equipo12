GO
CREATE DATABASE E_COMMERCE12
GO
USE E_COMMERCE12
GO
CREATE TABLE Marcas (
    ID_Marca INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(20) NOT NULL, 
    Estado BIT NULL DEFAULT 1
)
GO
CREATE TABLE Categorias (
    ID_Categoria INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(20) NOT NULL, 
    Estado BIT NULL DEFAULT 1
)
GO
CREATE TABLE Productos (
    ID_Producto INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    ID_Categoria INT NOT NULL FOREIGN KEY REFERENCES Categorias(ID_Categoria),
    ID_Marca INT NOT NULL FOREIGN KEY REFERENCES Marcas(ID_Marca),
    Codigo VARCHAR(15) UNIQUE NOT NULL,
    Nombre VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(500) NOT NULL,
    Precio MONEY NOT NULL CHECK (Precio > 0),
    Stock INT NOT NULL CHECK (Stock > 0),
    Estado BIT NULL DEFAULT 1,
)
GO
CREATE TABLE TipoUsuario (
    ID_Tipo INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(20) NOT NULL
)
GO
CREATE TABLE Provincias (
    ID_Provincia INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(20) NOT NULL
)
GO
CREATE TABLE Domicilios (
    ID_Domicilio INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    ID_Provincia INT NOT NULL FOREIGN KEY REFERENCES Provincias(ID_Provincia),
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
CREATE TABLE Usuario (
    ID_Usuario INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    ID_TipoUsuario INT NOT NULL FOREIGN KEY REFERENCES TipoUsuario(ID_Tipo),
    ID_Domicilio INT NOT NULL FOREIGN KEY REFERENCES Domicilios(ID_Domicilio),
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
CREATE TABLE Imagenes(
    ID_Imagen INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    ID_Producto INT NOT NULL FOREIGN KEY REFERENCES Productos(ID_Producto),
    ImagenURL VARCHAR(1000) NOT NULL,
    Descripcion VARCHAR(50) NOT NULL,
    Estado BIT NULL DEFAULT 1,
)

-- STORED PROCEDURES --
GO
CREATE PROCEDURE SP_ListarTodosLosProductos
AS
BEGIN
    SELECT P.ID_Producto AS IDProducto, P.Nombre, P.Codigo, P.Descripcion, P.ID_Categoria AS IDCategoria, C.Nombre as Categoria, P.ID_Marca as IDMarca, M.Nombre as Marca, P.Precio, P.Estado
    FROM Productos P 
    INNER JOIN Marcas M ON P.ID_Marca = M.ID_Marca
    INNER JOIN Categorias C ON P.ID_Categoria = C.ID_Categoria
END

GO
CREATE PROCEDURE SP_ProductosAlAzar(
    @Cantidad int
)
AS
BEGIN
    SELECT TOP (@Cantidad) P.ID_Producto AS IDProducto, P.Nombre, P.Codigo, P.Descripcion, P.ID_Categoria AS IDCategoria, C.Nombre as Categoria, P.ID_Marca as IDMarca, M.Nombre as Marca, P.Precio, P.Estado
    FROM Productos P 
    INNER JOIN Marcas M ON P.ID_Marca = M.ID_Marca
    INNER JOIN Categorias C ON P.ID_Categoria = C.ID_Categoria
    ORDER BY NEWID()
END

GO
CREATE PROCEDURE SP_ImagenesAlAzar(
    @Cantidad int
)
AS
BEGIN
    SELECT TOP (@Cantidad) I.ID_Producto, I.ID_Imagen, I.ImagenURL, I.Descripcion, I.Estado
    FROM Imagenes I
    ORDER BY NEWID()
END

GO
CREATE TRIGGER TR_DeleteImagen ON Imagenes
INSTEAD OF DELETE
AS
BEGIN
    DECLARE @IDImagen INT
    SELECT @IDImagen = ID_Imagen FROM deleted
    UPDATE Imagenes SET Estado = 0 WHERE ID_Imagen = @IDImagen
END

GO
CREATE PROCEDURE SP_ProductosPorCategoria(
    @Categoria VARCHAR(20)
)
AS
BEGIN
    SELECT P.ID_Producto AS IDProducto, P.Nombre, P.Codigo, P.Descripcion, P.ID_Categoria AS IDCategoria, C.Nombre as Categoria, P.ID_Marca as IDMarca, M.Nombre as Marca, P.Precio, P.Estado
    FROM Productos P 
    INNER JOIN Marcas M ON P.ID_Marca = M.ID_Marca
    INNER JOIN Categorias C ON P.ID_Categoria = C.ID_Categoria
    WHERE C.Nombre = @Categoria
END

GO
CREATE PROCEDURE SP_ProductosPorMarca(
    @Marca VARCHAR(20)
)
AS
BEGIN
    SELECT P.ID_Producto AS IDProducto, P.Nombre, P.Codigo, P.Descripcion, P.ID_Categoria AS IDCategoria, C.Nombre as Categoria, P.ID_Marca as IDMarca, M.Nombre as Marca, P.Precio, P.Estado
    FROM Productos P 
    INNER JOIN Marcas M ON P.ID_Marca = M.ID_Marca
    INNER JOIN Categorias C ON P.ID_Categoria = C.ID_Categoria
    WHERE M.Nombre = @Marca
END

GO
CREATE PROCEDURE SP_ProductosPorCategoriaMarca(
    @Categoria VARCHAR(20),
    @Marca VARCHAR(20)
)
AS
BEGIN
    SELECT P.ID_Producto AS IDProducto, P.Nombre, P.Codigo, P.Descripcion, P.ID_Categoria AS IDCategoria, C.Nombre as Categoria, P.ID_Marca as IDMarca, M.Nombre as Marca, P.Precio, P.Estado
    FROM Productos P 
    INNER JOIN Marcas M ON P.ID_Marca = M.ID_Marca
    INNER JOIN Categorias C ON P.ID_Categoria = C.ID_Categoria
    WHERE M.Nombre = @Marca AND C.Nombre = @Categoria
END


GO
CREATE PROCEDURE SP_ImagenesRandomPorCategoria(
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
CREATE PROCEDURE SP_ImagenesRandomPorMarca(
    @Cantidad int,
    @Marca VARCHAR(20)
)
AS
BEGIN
    SELECT TOP (@Cantidad) I.ID_Producto, I.ID_Imagen, I.ImagenURL, I.Descripcion, I.Estado
    FROM Imagenes I
    INNER JOIN Productos P ON I.ID_Producto = P.ID_Producto
    INNER JOIN Marcas M ON P.ID_Marca = M.ID_Marca
    WHERE M.Nombre = 'Nike'
    ORDER BY NEWID()
END
GO
CREATE PROCEDURE SP_MarcasRandom(
    @Cantidad int
)
AS
BEGIN
    SELECT TOP (@Cantidad) M.ID_Marca, M.Nombre, M.Estado
    FROM Marcas M
    ORDER BY NEWID()
END
GO
CREATE PROCEDURE SP_CategoriasRandom(
    @Cantidad int
)
AS
BEGIN
    SELECT TOP (@Cantidad) C.ID_Categoria, C.Nombre, C.Estado
    FROM Categorias C
    ORDER BY NEWID()
END
GO
CREATE PROCEDURE SP_ListarCategorias
AS
BEGIN
    SELECT C.ID_Categoria, C.Nombre, C.Estado FROM Categorias AS C
END

GO

CREATE PROCEDURE SP_ListarMarcas 
AS
BEGIN
    SELECT M.Estado, M.Nombre, M.ID_Marca FROM Marcas AS M
END
