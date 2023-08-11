using Capa_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace Capa_BLL
{
    public class PeliculasBLL
    {
        // Insertar
        public static void InsPelicula(int generoId, string nombre, float duracionHoras, DateTime fechaLanzamiento, string imdb)
        {
            try
            {
                PeliculasDAL.InsPelicula(generoId, nombre, duracionHoras, fechaLanzamiento, imdb);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Listar
        public static List<PeliculaVO> GetListPeliculas()
        {
            return PeliculasDAL.GetListPeliculas();
        }

        // Listar por ID
        public static PeliculaVO GetPeliculaById(int peliculaId)
        {
            return PeliculasDAL.GetPeliculaById(peliculaId);
        }

        // Actualizar
        public static void UdpPelicula(int peliculaId, int generoId, string nombre, float duracionHoras, DateTime fechaLanzamiento, string imdb)
        {
            PeliculasDAL.UdpPelicula(peliculaId, generoId, nombre, duracionHoras, fechaLanzamiento, imdb);
        }

        // Eliminar
        public static string DelPelicula(int peliculaId)
        {
            try
            {
                PeliculaVO pelicula = PeliculasDAL.GetPeliculaById(peliculaId);

                if (pelicula != null)
                {
                    PeliculasDAL.DelPelicula(peliculaId);
                    return "1";
                }

                return "0";
            }
            catch (Exception ex)
            {
                throw;
            }
        }   
    }
}
