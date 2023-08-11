-- DVD Libreria TRIGGERS
-- Autor: Guillermo Riaño Melchor

USE Dvd

-- ---------- BITACORAS ------------
-- Lenguajes
CREATE TABLE Bitacora_Lenguajes(
	BitacoraId int identity(1,1) primary key,
	LenguajeId int not null, 
	FechaRegistro datetime,
	Accion varchar(10)
)

-- Audios
CREATE TABLE Bitacora_Audios(
	BitacoraId int identity(1,1) primary key,
	AudioId int not null, 
	FechaRegistro datetime,
	Accion varchar(10)
)

-- Puntuaciones
CREATE TABLE Bitacora_Puntuaciones(
	BitacoraId int identity(1,1) primary key,
	PuntuacionId int not null, 
	FechaRegistro datetime,
	Accion varchar(10)
)

-- Generos
CREATE TABLE Bitacora_Generos(
	BitacoraId int identity(1,1) primary key,
	GeneroId int not null, 
	FechaRegistro datetime,
	Accion varchar(10)
)

-- Peliculas
CREATE TABLE Bitacora_Peliculas(
	BitacoraId int identity(1,1) primary key,
	PeliculaId int not null, 
	FechaRegistro datetime,
	Accion varchar(10)
)

-- Dvds
CREATE TABLE Bitacora_Dvds(
	BitacoraId int identity(1,1) primary key,
	DvdId int not null, 
	FechaRegistro datetime,
	Accion varchar(10)
)


-- ---------- TRIGGERS ------------
-- Lenguajes
CREATE TRIGGER tr_BitacoraLenguajes
ON Lenguajes -- Ligamos a la tabla
AFTER INSERT, UPDATE	-- Acciones Realizadas
AS
BEGIN
	DECLARE @LenguajeId int
	SET @LenguajeId = (SELECT LenguajeId FROM inserted);	-- inserted es una palabra reservada y es una tabla no visible (espejo) pero resulta ser la tabla que definimos en ON
	INSERT INTO Bitacora_Lenguajes(LenguajeId, FechaRegistro, Accion)
	VALUES (@LenguajeId, GETDATE(), CASE WHEN EXISTS(SELECT * FROM deleted) THEN 'UPDATE' ELSE 'INSERT' END);	-- deleted es una palabra reservada solo para cuando se hace un UPDATE o INSERTE (tabla espejo como el inserted)
END;

CREATE TRIGGER tr_BitacoraLenguajesEliminar
ON Lenguajes -- Ligamos a la tabla
FOR DELETE	-- Acciones Realizadas
AS
BEGIN
	DECLARE @LenguajeId int
	SET @LenguajeId = (SELECT LenguajeId FROM deleted);	-- inserted es una palabra reservada y es una tabla no visible (espejo) pero resulta ser la tabla que definimos en ON

	INSERT INTO Bitacora_Lenguajes(LenguajeId, FechaRegistro, Accion)
	VALUES (@LenguajeId, GETDATE(), 'DELETE');
END;

-- Audios
CREATE TRIGGER tr_BitacoraAudios
ON Audios -- Ligamos a la tabla
AFTER INSERT, UPDATE	-- Acciones Realizadas
AS
BEGIN
	DECLARE @AudioId int
	SET @AudioId = (SELECT AudioId FROM inserted);	-- inserted es una palabra reservada y es una tabla no visible (espejo) pero resulta ser la tabla que definimos en ON
	INSERT INTO Bitacora_Audios(AudioId, FechaRegistro, Accion)
	VALUES (@AudioId, GETDATE(), CASE WHEN EXISTS(SELECT * FROM deleted) THEN 'UPDATE' ELSE 'INSERT' END);	-- deleted es una palabra reservada solo para cuando se hace un UPDATE o INSERTE (tabla espejo como el inserted)
END;

CREATE TRIGGER tr_BitacoraAudiosEliminar
ON Audios -- Ligamos a la tabla
FOR DELETE	-- Acciones Realizadas
AS
BEGIN
	DECLARE @AudioId int
	SET @AudioId = (SELECT AudioId FROM deleted);	-- inserted es una palabra reservada y es una tabla no visible (espejo) pero resulta ser la tabla que definimos en ON

	INSERT INTO Bitacora_Audios(AudioId, FechaRegistro, Accion)
	VALUES (@AudioId, GETDATE(), 'DELETE');
END;

-- Puntuaciones
CREATE TRIGGER tr_BitacoraPuntuaciones
ON Puntuaciones -- Ligamos a la tabla
AFTER INSERT, UPDATE	-- Acciones Realizadas
AS
BEGIN
	DECLARE @PuntuacionId int
	SET @PuntuacionId = (SELECT PuntuacionId FROM inserted);	-- inserted es una palabra reservada y es una tabla no visible (espejo) pero resulta ser la tabla que definimos en ON
	INSERT INTO Bitacora_Puntuaciones(PuntuacionId, FechaRegistro, Accion)
	VALUES (@PuntuacionId, GETDATE(), CASE WHEN EXISTS(SELECT * FROM deleted) THEN 'UPDATE' ELSE 'INSERT' END);	-- deleted es una palabra reservada solo para cuando se hace un UPDATE o INSERTE (tabla espejo como el inserted)
END;

CREATE TRIGGER tr_BitacoraPuntuacionesEliminar
ON Puntuaciones -- Ligamos a la tabla
FOR DELETE	-- Acciones Realizadas
AS
BEGIN
	DECLARE @PuntuacionId int
	SET @PuntuacionId = (SELECT PuntuacionId FROM deleted);	-- inserted es una palabra reservada y es una tabla no visible (espejo) pero resulta ser la tabla que definimos en ON

	INSERT INTO Bitacora_Puntuaciones(PuntuacionId, FechaRegistro, Accion)
	VALUES (@PuntuacionId, GETDATE(), 'DELETE');
END;

-- Generos
CREATE TRIGGER tr_BitacoraGeneros
ON Generos -- Ligamos a la tabla
AFTER INSERT, UPDATE	-- Acciones Realizadas
AS
BEGIN
	DECLARE @GeneroId int
	SET @GeneroId = (SELECT GeneroId FROM inserted);	-- inserted es una palabra reservada y es una tabla no visible (espejo) pero resulta ser la tabla que definimos en ON
	INSERT INTO Bitacora_Generos(GeneroId, FechaRegistro, Accion)
	VALUES (@GeneroId, GETDATE(), CASE WHEN EXISTS(SELECT * FROM deleted) THEN 'UPDATE' ELSE 'INSERT' END);	-- deleted es una palabra reservada solo para cuando se hace un UPDATE o INSERTE (tabla espejo como el inserted)
END;

CREATE TRIGGER tr_BitacoraGenerosEliminar
ON Generos -- Ligamos a la tabla
FOR DELETE	-- Acciones Realizadas
AS
BEGIN
	DECLARE @GeneroId int
	SET @GeneroId = (SELECT GeneroId FROM deleted);	-- inserted es una palabra reservada y es una tabla no visible (espejo) pero resulta ser la tabla que definimos en ON

	INSERT INTO Bitacora_Generos(GeneroId, FechaRegistro, Accion)
	VALUES (@GeneroId, GETDATE(), 'DELETE');
END;

-- Peliculas
CREATE TRIGGER tr_BitacoraPeliculas
ON Peliculas -- Ligamos a la tabla
AFTER INSERT, UPDATE	-- Acciones Realizadas
AS
BEGIN
	DECLARE @PeliculaId int
	SET @PeliculaId = (SELECT PeliculaId FROM inserted);	-- inserted es una palabra reservada y es una tabla no visible (espejo) pero resulta ser la tabla que definimos en ON
	INSERT INTO Bitacora_Peliculas(PeliculaId, FechaRegistro, Accion)
	VALUES (@PeliculaId, GETDATE(), CASE WHEN EXISTS(SELECT * FROM deleted) THEN 'UPDATE' ELSE 'INSERT' END);	-- deleted es una palabra reservada solo para cuando se hace un UPDATE o INSERTE (tabla espejo como el inserted)
END;

CREATE TRIGGER tr_BitacoraPeliculasEliminar
ON Peliculas -- Ligamos a la tabla
FOR DELETE	-- Acciones Realizadas
AS
BEGIN
	DECLARE @PeliculaId int
	SET @PeliculaId = (SELECT PeliculaId FROM deleted);	-- inserted es una palabra reservada y es una tabla no visible (espejo) pero resulta ser la tabla que definimos en ON

	INSERT INTO Bitacora_Peliculas(PeliculaId, FechaRegistro, Accion)
	VALUES (@PeliculaId, GETDATE(), 'DELETE');
END;

-- Dvds
CREATE TRIGGER tr_BitacoraDvds
ON Dvds -- Ligamos a la tabla
AFTER INSERT, UPDATE	-- Acciones Realizadas
AS
BEGIN
	DECLARE @DvdId int
	SET @DvdId = (SELECT DvdId FROM inserted);	-- inserted es una palabra reservada y es una tabla no visible (espejo) pero resulta ser la tabla que definimos en ON
	INSERT INTO Bitacora_Dvds(DvdId, FechaRegistro, Accion)
	VALUES (@DvdId, GETDATE(), CASE WHEN EXISTS(SELECT * FROM deleted) THEN 'UPDATE' ELSE 'INSERT' END);	-- deleted es una palabra reservada solo para cuando se hace un UPDATE o INSERTE (tabla espejo como el inserted)
END;

CREATE TRIGGER tr_BitacoraDvdsEliminar
ON Dvds -- Ligamos a la tabla
FOR DELETE	-- Acciones Realizadas
AS
BEGIN
	DECLARE @DvdId int
	SET @DvdId = (SELECT DvdId FROM deleted);	-- inserted es una palabra reservada y es una tabla no visible (espejo) pero resulta ser la tabla que definimos en ON

	INSERT INTO Bitacora_Dvds(DvdId, FechaRegistro, Accion)
	VALUES (@DvdId, GETDATE(), 'DELETE');
END;