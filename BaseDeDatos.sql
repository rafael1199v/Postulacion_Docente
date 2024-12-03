CREATE DATABASE PostulacionDocente;
USE PostulacionDocente;

CREATE TABLE Usuario (
    UsuarioId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(60) NOT NULL,
    CI VARCHAR(20) NOT NULL UNIQUE,
    FechaNacimiento DATE,
    NumeroTelefono VARCHAR(20) NOT NULL UNIQUE,
    Correo VARCHAR(50) NOT NULL UNIQUE,
    Contrasenha VARCHAR(50) NOT NULL
);

CREATE TABLE Docente (
    DocenteId INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    Especialidad VARCHAR(40) NOT NULL,
    Experiencia INT,
    DescripcionPersonal VARCHAR(300),
    Grado VARCHAR(40),
    UsuarioId INT NOT NULL --FOREIGN KEY REFERENCES Usuario(UsuarioId)
);

CREATE TABLE Carrera(
    CarreraId INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    NombreCarrera VARCHAR(50) NOT NULL,
    Sigla VARCHAR(10) NOT NULL UNIQUE
);

CREATE TABLE Materia(
    MateriaId INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    NombreMateria VARCHAR(50) NOT NULL,
    Sigla VARCHAR(10) NOT NULL UNIQUE
);

CREATE TABLE MateriaCarrera(
    MateriaCarreraId INT PRIMARY KEY NOT NULL IDENTITY(1, 1),
    MateriadId INT NOT NULL, --FOREIGN KEY REFERENCES Materia(MateriaId),
    CarreraId INT NOT NULL --FOREIGN KEY REFERENCES Carrera(CaerreraId)
);

CREATE TABLE JefeCarrera(
    JefeCarreraId INT PRIMARY KEY NOT NULL IDENTITY(1, 1),
    UsuarioId INT NOT NULL, --FOREIGN KEY REFERENCES Usuario(UsuarioId)
    CarreraId INT NOT NULL, --FOREIGN KEY REFERENCES Carrera(CarreraId)
);

CREATE TABLE Postulacion(
    PostulacionId INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    Estado INT NOT NULL, -- FOREIGN KEY REFERENCES Estado(EstadoId)
    DocenteId INT NOT NULL -- FOREIGN KEY REFERENCES Docente(DocenteId)
);

CREATE TABLE PostulacionVacante(
    PostulacionVacanteId INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    VacanteId INT NOT NULL, -- FOREIGN KEY REFERENCES Vacante(VacanteId)
    PostulacionId INT NOT NULL -- FOREIGN KEY REFERENCES Postulacion(PostulacionId)
);

CREATE TABLE Vacante(
    VacanteId INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    NombreVacante VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(300),
    FechaInicio DATE NOT NULL,
    FechaFin DATE NOT NULL,
    MateriaId INT NOT NULL --FOREIGN KEY REFERENCES Materia(MateriaId)
);


CREATE TABLE Estado(
    EstadoId INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    Mensaje VARCHAR(300) NOT NULL
);


DROP TABLE Estado;
DROP TABLE Vacante;
DROP TABLE PostulacionVacante;
DROP TABLE Postulacion;
DROP TABLE JefeCarrera;
DROP TABLE MateriaCarrera;
DROP TABLE Materia;
DROP TABLE Carrera;
DROP TABLE Docente;
DROP TABLE Usuario;