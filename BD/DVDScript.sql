-- DVD Libreria SCRIPT
-- Autor: Guillermo Ria�o Melchor

CREATE DATABASE Dvd
GO
USE Dvd

-- ---------- TABLAS ------------
CREATE TABLE Lenguajes(
	LenguajeId int identity(1,1) primary key,
	Nombre varchar(100) not null
)

CREATE TABLE Audios(
	AudioId int identity(1,1) primary key,
	Formato varchar(20) not null
)

CREATE TABLE Generos(
	GeneroId int identity(1,1) primary key,
	Nombre varchar(50) not null
)

CREATE TABLE Peliculas(
	PeliculaId int identity(1,1) primary key,	
	GeneroId int not null,
	Nombre varchar(100) not null,
	DuracionHoras float not null,
	FechaLanzamiento datetime not null,
	Imdb varchar(10) not null,	
	FOREIGN KEY (GeneroId) REFERENCES Generos(GeneroId)
)

CREATE TABLE Puntuaciones(
	PuntuacionId int identity(1,1) primary key,
	PeliculaId int not null,
	Plataforma varchar(100),
	Puntuacion float,
	FOREIGN KEY (PeliculaId) REFERENCES Peliculas(PeliculaId)
)

CREATE TABLE Dvds(
	DvdId int identity(1,1) primary key,
	PeliculaId int not null,
	LenguajeId int not null,
	AudioId int not null,
	Isbn varchar(16) not null,
	Edicion varchar(32),
	FormatoPantalla varchar(32),
	Region varchar(16),
	FechaSalida datetime,
	UrlFoto varchar(250),
	FOREIGN KEY (PeliculaId) REFERENCES Peliculas(PeliculaId),
	FOREIGN KEY (LenguajeId) REFERENCES Lenguajes(LenguajeId),
	FOREIGN KEY (AudioId) REFERENCES Audios(AudioId)
)