GO
CREATE DATABASE E_COMMERCE12
GO
USE E_COMMERCE12

CREATE TABLE Marcas (
    ID_Marca INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(20) NOT NULL, 
    Estado BIT NULL DEFAULT 1
)

CREATE TABLE Categorias (
    ID_Categoria INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(20) NOT NULL, 
    Estado BIT NULL DEFAULT 1
)

CREATE TABLE Productos (
    ID_Producto INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    ID_Categoria INT NOT NULL FOREIGN KEY REFERENCES Categorias(ID_Categoria),
    ID_Marca INT NOT NULL FOREIGN KEY REFERENCES Marcas(ID_Marca),
    Codigo VARCHAR(15) UNIQUE NOT NULL,
    Nombre VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(500) NOT NULL,
    Precio MONEY NOT NULL CHECK (Precio > 0),
    Estado BIT NULL DEFAULT 1,
)

CREATE TABLE TipoUsuario (
    ID_Tipo INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(20) NOT NULL
)

CREATE TABLE Provincias (
    ID_Provincia INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(20) NOT NULL
)

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


CREATE TABLE Imagenes(
    ID_Imagen INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    ID_Producto INT NOT NULL FOREIGN KEY REFERENCES Productos(ID_Producto),
    ImagenURL VARCHAR(1000) NOT NULL,
    Descripcion VARCHAR(50) NOT NULL,
    Estado BIT NULL DEFAULT 1,
)

