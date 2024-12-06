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
    Sigla VARCHAR(10) NOT NULL UNIQUE,
	JefeCarreraId INT
);

CREATE TABLE Materia(
    MateriaId INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    NombreMateria VARCHAR(50) NOT NULL,
    Sigla VARCHAR(10) NOT NULL UNIQUE
);

CREATE TABLE MateriaCarrera(
    MateriaId INT NOT NULL, --FOREIGN KEY REFERENCES Materia(MateriaId),
    CarreraId INT NOT NULL --FOREIGN KEY REFERENCES Carrera(CaerreraId)
);

CREATE TABLE JefeCarrera(
    JefeCarreraId INT PRIMARY KEY NOT NULL IDENTITY(1, 1),
    UsuarioId INT NOT NULL, --FOREIGN KEY REFERENCES Usuario(UsuarioId)
);

CREATE TABLE Postulacion(
    PostulacionId INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    EstadoId INT NOT NULL, -- FOREIGN KEY REFERENCES Estado(EstadoId)
    DocenteId INT NOT NULL -- FOREIGN KEY REFERENCES Docente(DocenteId)
);

CREATE TABLE PostulacionVacante(
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


ALTER TABLE Docente
ADD CONSTRAINT FK_Usuario_Docente 
FOREIGN KEY (UsuarioId) REFERENCES Usuario(UsuarioId);

ALTER TABLE MateriaCarrera
ADD CONSTRAINT FK_Materia_MateriaCarrera
FOREIGN KEY (MateriaId) REFERENCES Materia(MateriaId);

ALTER TABLE MateriaCarrera
ADD CONSTRAINT FK_Carrera_MateriaCarrera
FOREIGN KEY (CarreraId) REFERENCES Carrera(CarreraId);

ALTER TABLE MateriaCarrera
ADD CONSTRAINT PK_MateriaCarrera 
PRIMARY KEY (MateriaId, CarreraId);

ALTER TABLE JefeCarrera
ADD CONSTRAINT FK_Usuario_JefeCarrera
FOREIGN KEY (UsuarioId) REFERENCES Usuario(UsuarioId);

ALTER TABLE Carrera
ADD CONSTRAINT FK_JefeCarrera_Carrera
FOREIGN KEY (JefeCarreraId) REFERENCES JefeCarrera(JefeCarreraId);

ALTER TABLE Postulacion
ADD CONSTRAINT FK_Estado_Postulacion
FOREIGN KEY (EstadoId) REFERENCES Estado(EstadoId);

ALTER TABLE Postulacion
ADD CONSTRAINT FK_Docente_Postulacion
FOREIGN KEY (DocenteId) REFERENCES Docente(DocenteId);

ALTER TABLE PostulacionVacante
ADD CONSTRAINT FK_Vacante_PostulacionVacante
FOREIGN KEY (VacanteId) REFERENCES Vacante(VacanteId);

ALTER TABLE PostulacionVacante
ADD CONSTRAINT FK_Postulacion_PostulacionVacante
FOREIGN KEY (PostulacionId) REFERENCES Postulacion(PostulacionId);

ALTER TABLE PostulacionVacante
ADD CONSTRAINT  PK_PostulacionVacante
PRIMARY KEY (VacanteId, PostulacionId);

ALTER TABLE Vacante
ADD CONSTRAINT FK_Materia_Vacante
FOREIGN KEY (MateriaId) REFERENCES Materia(MateriaId);


DROP TABLE PostulacionVacante;
DROP TABLE Postulacion;
DROP TABLE Vacante;
DROP TABLE Estado;
DROP TABLE JefeCarrera;
DROP TABLE MateriaCarrera;
DROP TABLE Carrera;
DROP TABLE Materia;
DROP TABLE Docente;
DROP TABLE Usuario;