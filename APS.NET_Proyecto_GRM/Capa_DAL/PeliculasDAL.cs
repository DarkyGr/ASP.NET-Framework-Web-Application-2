using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace Capa_DAL
{
    public class PeliculasDAL
    {
        // Insertar
        public static void InsPelicula(int generoId, string nombre, float duracionHoras, DateTime fechaLanzamiento, string imdb)
        {
            try
            {
                int result;

                result = MetodoDatos.ExecuteNonQuery("sp_InsertarPelicula",
                    "@GeneroId", generoId,
                    "@Nombre", nombre,
                    "@DuracionHoras", duracionHoras,
                    "@FechaLanzamiento", fechaLanzamiento,
                    "@Imdb", imdb);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        // Listar
        public static List<PeliculaVO> GetListPeliculas()
        {
            List<PeliculaVO> listaPeliculas = new List<PeliculaVO>();

            try
            {
                DataSet dsPeliculas = MetodoDatos.ExecuteDataSet("sp_LeerPeliculas");

                foreach (DataRow dr in dsPeliculas.Tables[0].Rows)
                {
                    listaPeliculas.Add(new PeliculaVO(dr));
                }

                return listaPeliculas;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Listar por ID
        public static PeliculaVO GetPeliculaById(int peliculaId)
        {
            try
            {
                DataSet dsPelicula = MetodoDatos.ExecuteDataSet("sp_LeerPelicula", "@PeliculaId", peliculaId);

                if (dsPelicula.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = dsPelicula.Tables[0].Rows[0];
                    return new PeliculaVO(dr);
                }
                else
                {
                    return new PeliculaVO();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Actualizar
        public static void UdpPelicula(int peliculaId, int generoId, string nombre, float duracionHoras, DateTime fechaLanzamiento, string imdb)
        {
            try
            {
                MetodoDatos.ExecuteNonQuery("sp_ActualizarPelicula",
                    "@PeliculaId", peliculaId,                    
                    "@GeneroId", generoId,
                    "@Nombre", nombre,
                    "@DuracionHoras", duracionHoras,
                    "@FechaLanzamiento", fechaLanzamiento,
                    "@Imdb", imdb);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Eliminar
        public static void DelPelicula(int peliculaId)
        {
            try
            {
                MetodoDatos.ExecuteNonQuery("sp_EliminarPelicula",
                    "@PeliculaId", peliculaId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
