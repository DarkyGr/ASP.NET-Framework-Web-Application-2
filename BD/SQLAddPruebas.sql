use Dvd

exec sp_LeerDvds

EXEC sp_InsertarDvd @PeliculaId = 3, @LenguajeId = 3, @AudioId = 3, @Isbn = 'r23r', @Edicion = 'Primera', @FormatoPantalla = 'QHD', @Region = 'Mexico', @FechaSalida = '2000-01-01', @UrlFoto = 'sdasdasd'
EXEC sp_InsertarDvd @PeliculaId = 3, @LenguajeId = 3, @AudioId = 3, @Isbn = 'r23r', @Edicion = 'Primera', @FormatoPantalla = 'QHD', @Region = 'Mexico', @FechaSalida = '2000-01-01', @UrlFoto = 'sdasdasd'


exec sp_LeerPeliculas

EXEC sp_InsertarPelicula @GeneroId = 1, @Nombre = 'a', @DuracionHoras = 1.0, @FechaLanzamiento = '2000-01-01', @Imdb = 'xca2sa'
EXEC sp_InsertarPelicula @GeneroId = 1, @Nombre = 'a', @DuracionHoras = 1.0, @FechaLanzamiento = '2000-01-01', @Imdb = 'xca2sa'
EXEC sp_InsertarPelicula @GeneroId = 1, @Nombre = 'a', @DuracionHoras = 1.0, @FechaLanzamiento = '2000-01-01', @Imdb = 'xca2sa'


EXEC sp_LeerGeneros

EXEC sp_InsertarGenero @Nombre = 'PRUEBA'
EXEC sp_InsertarGenero @Nombre = 'PRUEBA'
EXEC sp_InsertarGenero @Nombre = 'PRUEBA'


EXEC sp_LeerPuntuaciones

EXEC sp_InsertarPuntuacion @PeliculaId = 2, @Plataforma = 'PRUEBAAA', @Puntuacion = 9.0
EXEC sp_InsertarPuntuacion @PeliculaId = 2, @Plataforma = 'PRUEBAAA', @Puntuacion = 9.0


exec sp_LeerAudios

exec sp_InsertarAudio @Formato = 'PRUEBA'
exec sp_InsertarAudio @Formato = 'PRUEBA'


exec sp_LeerLenguajes

exec sp_InsertarLenguaje @Nombre = 'PRUEBA'
exec sp_InsertarLenguaje @Nombre = 'PRUEBA'

