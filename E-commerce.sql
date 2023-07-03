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
CREATE TABLE Usuarios (
    ID_Usuario BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    ID_TipoUsuario BIGINT NOT NULL FOREIGN KEY REFERENCES TipoUsuario(ID_Tipo),
    Dni VARCHAR(10) NOT NULL UNIQUE,
    Nombre VARCHAR(15) NOT NULL,
    Apellido VARCHAR(15) NOT NULL,
    Email VARCHAR(50) NOT NULL UNIQUE,
    Contrasena VARCHAR(200) NOT NULL, 
    Telefono VARCHAR(15) NULL,
    FechaNacimiento DATE NULL,
    Estado BIT NULL DEFAULT 1,
)
GO
CREATE TABLE Domicilios (
    ID_Domicilio BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    ID_Usuario BIGINT NULL FOREIGN KEY REFERENCES Usuarios(ID_Usuario),
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
GO
CREATE TABLE Banners (
    ID_Banner BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Titulo VARCHAR(100) NOT NULL,
    Texto VARCHAR(200) NOT NULL,
    Referencia VARCHAR(50) NOT NULL,
    ImagenURL VARCHAR(1000) NOT NULL,
)

----------------------------------------------------------------------------------

--     DECLARE @Busqueda VARCHAR(10)
--     SELECT @Busqueda = 'remera'
--     SELECT P.ID_Producto AS IDProducto, P.Nombre, P.Codigo, P.Descripcion, P.ID_Categoria AS IDCategoria, C.Nombre as Categoria, P.ID_Marca as IDMarca, M.Nombre as Marca, P.Precio, P.Estado, P.Stock FROM Productos P INNER JOIN Marcas M ON P.ID_Marca = M.ID_Marca INNER JOIN Categorias C ON P.ID_Categoria = C.ID_Categoria WHERE P.Nombre LIKE @Busqueda + '%' OR M.Nombre LIKE @Busqueda + '%' OR C.Nombre LIKE @Busqueda + '%' OR P.Descripcion LIKE @Busqueda + '%'

--     select * from Productos where Estado = 0
-- UPDATE Productos SET Estado = 1
-- SELECT ID_Provincia, Nombre FROM Provincias

-- select * from Marcas

-- use E_COMMERCE12
-- SELECT ID_Usuario, ID_Domicilio, Localidad, Calle, Numero, CodigoPostal, Piso, Referencia, Alias, EstadoDomicilio, ID_Provincia, Provincia  FROM Domicilios D INNER JOIN Provincias P ON D.ID_Provincia = P.ID_Provincia WHERE ID_Usuario = 1