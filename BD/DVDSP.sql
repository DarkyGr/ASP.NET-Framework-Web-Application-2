-- DVD Libreria STORED PROCEDURE
-- Autor: Guillermo Riaño Melchor

USE Dvd

-- ------- SP ------------
-- Lenguajes

-- Insertar
CREATE PROC sp_InsertarLenguaje
	@Nombre varchar(100)
AS
BEGIN
	INSERT INTO Lenguajes (Nombre)
	VALUES (@Nombre)
END;

-- OBTENER POR ID
CREATE PROC sp_LeerLenguaje
	@LenguajeId int
AS
BEGIN
	SELECT * FROM Lenguajes WHERE LenguajeId = @LenguajeId
END;

-- OBTENER
CREATE PROC sp_LeerLenguajes
AS
BEGIN
	SELECT * FROM Lenguajes
END;

-- Actualizar
CREATE PROC sp_ActualizarLenguaje
	@LenguajeId int,
	@Nombre varchar(100)
AS
BEGIN
	UPDATE Lenguajes
	SET Nombre = @Nombre
	WHERE LenguajeId = @LenguajeId
END;

-- DELETE
CREATE PROC sp_EliminarLenguaje
	@LenguajeId int	
AS
BEGIN
	DELETE FROM Lenguajes
	WHERE LenguajeId = @LenguajeId
END;

-- ****** DATOS ******
EXEC sp_InsertarLenguaje @Nombre = 'Ingles'
EXEC sp_InsertarLenguaje @Nombre = 'Español'
EXEC sp_InsertarLenguaje @Nombre = 'Frances'
EXEC sp_InsertarLenguaje @Nombre = 'Portugues'
EXEC sp_InsertarLenguaje @Nombre = 'Japones'
EXEC sp_InsertarLenguaje @Nombre = 'Chino'
EXEC sp_InsertarLenguaje @Nombre = 'Ruso'

EXEC sp_LeerLenguaje @LenguajeId = 5
EXEC sp_LeerLenguajes

EXEC sp_ActualizarLenguaje @LenguajeId = 6, @Nombre = 'PRUEBA'

EXEC sp_EliminarLenguaje @LenguajeId = 7


----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------
-- Audios

-- Insertar
CREATE PROC sp_InsertarAudio
	@Formato varchar(20)
AS
BEGIN
	INSERT INTO Audios(Formato)
	VALUES (@Formato)
END;

-- OBTENER POR ID
CREATE PROC sp_LeerAudio
	@AudioId int
AS
BEGIN
	SELECT * FROM Audios WHERE AudioId = @AudioId
END;

-- OBTENER
CREATE PROC sp_LeerAudios
AS
BEGIN
	SELECT * FROM Audios
END;

-- Actualizar
CREATE PROC sp_ActualizarAudio
	@AudioId int,
	@Formato varchar(100)
AS
BEGIN
	UPDATE Audios
	SET Formato = @Formato
	WHERE AudioId = @AudioId
END;

-- DELETE
CREATE PROC sp_EliminarAudio
	@AudioId int	
AS
BEGIN
	DELETE FROM Audios
	WHERE AudioId = @AudioId
END;

-- ****** DATOS ******
EXEC sp_InsertarAudio @Formato = 'MP3'
EXEC sp_InsertarAudio @Formato = 'FLAC'
EXEC sp_InsertarAudio @Formato = 'ACC'
EXEC sp_InsertarAudio @Formato = 'TAC'
EXEC sp_InsertarAudio @Formato = 'WAV'
EXEC sp_InsertarAudio @Formato = 'CAT'
EXEC sp_InsertarAudio @Formato = 'SPA'

EXEC sp_LeerAudio @AudioId = 5
EXEC sp_LeerAudios

EXEC sp_ActualizarAudio @AudioId = 6, @Formato = 'PRUEBA'

EXEC sp_EliminarAudio @AudioId = 7


----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------
-- Generos

-- Insertar
CREATE PROC sp_InsertarGenero
	@Nombre varchar(50)
AS
BEGIN
	INSERT INTO Generos(Nombre)
	VALUES (@Nombre)
END;

-- OBTENER POR ID
CREATE PROC sp_LeerGenero
	@GeneroId int
AS
BEGIN
	SELECT * FROM Generos WHERE GeneroId = @GeneroId
END;

-- OBTENER
CREATE PROC sp_LeerGeneros
AS
BEGIN
	SELECT * FROM Generos
END;

-- Actualizar
CREATE PROC sp_ActualizarGenero
	@GeneroId int,
	@Nombre varchar(50)
AS
BEGIN
	UPDATE Generos
	SET Nombre = @Nombre
	WHERE GeneroId = @GeneroId
END;

-- DELETE
CREATE PROC sp_EliminarGenero
	@GeneroId int	
AS
BEGIN
	DELETE FROM Generos
	WHERE GeneroId = @GeneroId
END;

-- ****** DATOS ******
EXEC sp_InsertarGenero @Nombre = 'Ciencia Ficcion'
EXEC sp_InsertarGenero @Nombre = 'Novela'
EXEC sp_InsertarGenero @Nombre = 'Cuento'
EXEC sp_InsertarGenero @Nombre = 'Estilo'
EXEC sp_InsertarGenero @Nombre = 'Tiempo'
EXEC sp_InsertarGenero @Nombre = 'Arte'
EXEC sp_InsertarGenero @Nombre = 'Trama'

EXEC sp_LeerGenero @GeneroId = 5
EXEC sp_LeerGeneros

EXEC sp_ActualizarGenero @GeneroId = 6, @Nombre = 'PRUEBA'

EXEC sp_EliminarGenero @GeneroId = 7


----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------
-- Peliculas

-- Insertar
CREATE PROC sp_InsertarPelicula	
	@GeneroId int,
	@Nombre varchar(100),
	@DuracionHoras float,
	@FechaLanzamiento datetime,
	@Imdb varchar(10)
AS
BEGIN
	INSERT INTO Peliculas(GeneroId, Nombre, DuracionHoras, FechaLanzamiento, Imdb)
	VALUES (@GeneroId, @Nombre, @DuracionHoras, @FechaLanzamiento, @Imdb)
END;

-- OBTENER POR ID
CREATE PROC sp_LeerPelicula
	@PeliculaId int
AS
BEGIN
	SELECT * FROM Peliculas WHERE PeliculaId = @PeliculaId
END;

-- OBTENER
CREATE PROC sp_LeerPeliculas
AS
BEGIN
	SELECT * FROM Peliculas
END;

-- Actualizar
CREATE PROC sp_ActualizarPelicula
	@PeliculaId int,	
	@GeneroId int,
	@Nombre varchar(100),
	@DuracionHoras float,
	@FechaLanzamiento datetime,
	@Imdb varchar(10)
AS
BEGIN
	UPDATE Peliculas
	SET GeneroId = @GeneroId,
		Nombre = @Nombre,
		DuracionHoras = @DuracionHoras,
		FechaLanzamiento = @FechaLanzamiento,
		Imdb = @Imdb
	WHERE PeliculaId = @PeliculaId
END;

-- DELETE
CREATE PROC sp_EliminarPelicula
	@PeliculaId int	
AS
BEGIN
	DELETE FROM Peliculas
	WHERE PeliculaId = @PeliculaId
END;

-- ****** DATOS ******
EXEC sp_InsertarPelicula @GeneroId = 1, @Nombre = 'La casa', @DuracionHoras = 1.0, @FechaLanzamiento = '2000-01-01', @Imdb = 'xca2sa'
EXEC sp_InsertarPelicula @GeneroId = 2, @Nombre = 'Dea', @DuracionHoras = 2.0, @FechaLanzamiento = '2000-01-01', @Imdb = 'xca2sa'
EXEC sp_InsertarPelicula @GeneroId = 3, @Nombre = 'SIA', @DuracionHoras = 1.0, @FechaLanzamiento = '2000-01-01', @Imdb = 'xca2sa'
EXEC sp_InsertarPelicula @GeneroId = 4, @Nombre = 'OVNI', @DuracionHoras = 4.0, @FechaLanzamiento = '2000-01-01', @Imdb = 'xca2sa'
EXEC sp_InsertarPelicula @GeneroId = 5, @Nombre = 'Papel malo', @DuracionHoras = 1.1, @FechaLanzamiento = '2000-01-01', @Imdb = 'xca2sa'
EXEC sp_InsertarPelicula @GeneroId = 6, @Nombre = 'No tiene', @DuracionHoras = 1.0, @FechaLanzamiento = '2000-01-01', @Imdb = 'xca2sa'
EXEC sp_InsertarPelicula @GeneroId = 1, @Nombre = 'a', @DuracionHoras = 1.0, @FechaLanzamiento = '2000-01-01', @Imdb = 'xca2sa'

EXEC sp_LeerPelicula @PeliculaId = 5
EXEC sp_LeerPeliculas

EXEC sp_ActualizarPelicula @PeliculaId = 6, @GeneroId = 1, @Nombre = 'TEST', @DuracionHoras = 1.0, @FechaLanzamiento = '2022-01-01', @Imdb = 'TEST'

EXEC sp_EliminarPelicula @PeliculaId = 7



----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------
-- Puntuaciones

-- Insertar
CREATE PROC sp_InsertarPuntuacion
	@PeliculaId int,
	@Plataforma varchar(100),
	@Puntuacion float	
AS
BEGIN
	INSERT INTO Puntuaciones(PeliculaId, Plataforma, Puntuacion)
	VALUES (@PeliculaId, @Plataforma, @Puntuacion)
END;

-- OBTENER POR ID
CREATE PROC sp_LeerPuntuacion
	@PuntuacionId int
AS
BEGIN
	SELECT * FROM Puntuaciones WHERE PuntuacionId = @PuntuacionId
END;

-- OBTENER
CREATE PROC sp_LeerPuntuaciones
AS
BEGIN
	SELECT * FROM Puntuaciones
END;

-- Actualizar
CREATE PROC sp_ActualizarPuntuacion
	@PuntuacionId int,
	@PeliculaId int,
	@Plataforma varchar(100),
	@Puntuacion float
AS
BEGIN
	UPDATE Puntuaciones
	SET PeliculaId = @PeliculaId,
		Plataforma = @Plataforma,
		Puntuacion = @Puntuacion
	WHERE PuntuacionId = @PuntuacionId
END;

-- DELETE
CREATE PROC sp_EliminarPuntuacion
	@PuntuacionId int	
AS
BEGIN
	DELETE FROM Puntuaciones
	WHERE PuntuacionId = @PuntuacionId
END;

-- ****** DATOS ******
EXEC sp_InsertarPuntuacion @PeliculaId = 1, @Plataforma = 'Rotato Tomatos', @Puntuacion = 9.0
EXEC sp_InsertarPuntuacion @PeliculaId = 2, @Plataforma = 'Rotato Tomatos', @Puntuacion = 7.1
EXEC sp_InsertarPuntuacion @PeliculaId = 3, @Plataforma = 'Rotato Tomatos', @Puntuacion = 6.2
EXEC sp_InsertarPuntuacion @PeliculaId = 4, @Plataforma = 'Rotato Tomatos', @Puntuacion = 4.4
EXEC sp_InsertarPuntuacion @PeliculaId = 5, @Plataforma = 'Rotato Tomatos', @Puntuacion = 9.5
EXEC sp_InsertarPuntuacion @PeliculaId = 1, @Plataforma = 'Rotato Tomatos', @Puntuacion = 9.0
EXEC sp_InsertarPuntuacion @PeliculaId = 2, @Plataforma = 'Rotato Tomatos', @Puntuacion = 9.0

EXEC sp_LeerPuntuacion @PuntuacionId = 5
EXEC sp_LeerPuntuaciones

EXEC sp_ActualizarPuntuacion @PuntuacionId = 6, @PeliculaId = 2, @Plataforma = 'Rotato Tomatos', @Puntuacion = 9.0

EXEC sp_EliminarPuntuacion @PuntuacionId = 7


----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------
-- Dvds

-- Insertar
CREATE PROC sp_InsertarDvd
	@PeliculaId int,
	@LenguajeId int,
	@AudioId int,
	@Isbn varchar(16),
	@Edicion Varchar(32),
	@FormatoPantalla varchar(32),
	@Region varchar(16),
	@FechaSalida datetime,
	@UrlFoto varchar(250)
AS
BEGIN
	INSERT INTO Dvds(PeliculaId, LenguajeId, AudioId, Isbn, Edicion, FormatoPantalla, Region, FechaSalida, UrlFoto)
	VALUES (@PeliculaId, @LenguajeId, @AudioId, @Isbn, @Edicion, @FormatoPantalla, @Region, @FechaSalida, @UrlFoto)
END;

-- OBTENER POR ID
CREATE PROC sp_LeerDvd
	@DvdId int
AS
BEGIN
	SELECT * FROM Dvds WHERE DvdId = @DvdId
END;

-- OBTENER
CREATE PROC sp_LeerDvds
AS
BEGIN
	SELECT * FROM Dvds
END;

-- Actualizar
CREATE PROC sp_ActualizarDvd
	@DvdId int,
	@PeliculaId int,
	@LenguajeId int,
	@AudioId int,
	@Isbn varchar(16),
	@Edicion Varchar(32),
	@FormatoPantalla varchar(32),
	@Region varchar(16),
	@FechaSalida datetime,
	@UrlFoto varchar(250)
AS
BEGIN
	UPDATE Dvds
	SET PeliculaId = @PeliculaId,
		LenguajeId = @LenguajeId,
		AudioId = @AudioId,
		Isbn = @Isbn,
		Edicion = @Edicion,
		FormatoPantalla = @FormatoPantalla,
		Region = @Region,
		FechaSalida = @FechaSalida,
		UrlFoto = @UrlFoto
	WHERE DvdId = @DvdId
END;

-- DELETE
CREATE PROC sp_EliminarDvd
	@DvdId int	
AS
BEGIN
	DELETE FROM Dvds
	WHERE DvdId = @DvdId
END;

-- ****** DATOS ******
EXEC sp_InsertarDvd @PeliculaId = 1, @LenguajeId = 1, @AudioId = 1, @Isbn = 'sdj3', @Edicion = 'Primera', @FormatoPantalla = 'FHD', @Region = 'Mexico', @FechaSalida = '2000-01-01', @UrlFoto = 'https://bayharborbutcher.files.wordpress.com/2012/07/caratula-dexter-s03-by-chexo-sin-dvd.jpg'
EXEC sp_InsertarDvd @PeliculaId = 2, @LenguajeId = 2, @AudioId = 2, @Isbn = 'ds3', @Edicion = 'Primera', @FormatoPantalla = 'QHD', @Region = 'EU', @FechaSalida = '2000-01-01', @UrlFoto = 'https://i.pinimg.com/originals/b3/c6/6b/b3c66b281f3142ef54a24d144da9bff1.jpg'
EXEC sp_InsertarDvd @PeliculaId = 3, @LenguajeId = 3, @AudioId = 3, @Isbn = 'd1e', @Edicion = 'Segunda', @FormatoPantalla = 'FHD', @Region = 'Francia', @FechaSalida = '2000-01-01', @UrlFoto = 'https://i.etsystatic.com/28976030/r/il/70bc2c/4603971215/il_fullxfull.4603971215_4rvt.jpg'
EXEC sp_InsertarDvd @PeliculaId = 4, @LenguajeId = 4, @AudioId = 4, @Isbn = 'fed4', @Edicion = 'Segunda', @FormatoPantalla = 'FHD', @Region = 'Mexico', @FechaSalida = '2000-01-01', @UrlFoto = 'https://i.pinimg.com/originals/2f/1f/48/2f1f481228e0fb44beed200f90a44667.jpg'
EXEC sp_InsertarDvd @PeliculaId = 5, @LenguajeId = 5, @AudioId = 5, @Isbn = 'df2', @Edicion = 'Primera', @FormatoPantalla = 'QHD', @Region = 'China', @FechaSalida = '2000-01-01', @UrlFoto = 'https://mir-s3-cdn-cf.behance.net/project_modules/max_1200/9dd92732178665.56722b56d4bde.jpg'
EXEC sp_InsertarDvd @PeliculaId = 6, @LenguajeId = 6, @AudioId = 6, @Isbn = 'f42', @Edicion = 'Segunda', @FormatoPantalla = 'FHD', @Region = 'Mexico', @FechaSalida = '2000-01-01', @UrlFoto = 'asdsads'
EXEC sp_InsertarDvd @PeliculaId = 3, @LenguajeId = 3, @AudioId = 3, @Isbn = 'r23r', @Edicion = 'Primera', @FormatoPantalla = 'QHD', @Region = 'Mexico', @FechaSalida = '2000-01-01', @UrlFoto = 'sdasdasd'

EXEC sp_LeerDvd @DvdId = 5
EXEC sp_LeerDvds

EXEC sp_ActualizarDvd @DvdId = 6, @PeliculaId = 2, @LenguajeId = 2, @AudioId = 2, @Isbn = 'PRUEBA', @Edicion = 'PRUEBA', @FormatoPantalla = 'PRUEBA', @Region = 'PRUEBA', @FechaSalida = '2000-01-01', @UrlFoto = 'https://i.etsystatic.com/28976030/r/il/1ab8b6/4846281937/il_fullxfull.4846281937_7d0d.jpg'

EXEC sp_EliminarDvd @DvdId = 7