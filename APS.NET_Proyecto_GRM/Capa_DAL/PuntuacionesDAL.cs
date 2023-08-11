using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace Capa_DAL
{
    public class PuntuacionesDAL
    {

        // Insertar
        public static void InsPuntuacion(int peliculaId, string plataforma, float puntuacion)
        {
            try
            {
                int result;

                result = MetodoDatos.ExecuteNonQuery("sp_InsertarPuntuacion",
                    "@PeliculaId", peliculaId,
                    "@Plataforma", plataforma,
                    "@Puntuacion", puntuacion);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        // Listar
        public static List<PuntuacionVO> GetListPuntuaciones()
        {
            List<PuntuacionVO> listaPuntuaciones = new List<PuntuacionVO>();

            try
            {
                DataSet dsPuntuaciones = MetodoDatos.ExecuteDataSet("sp_LeerPuntuaciones");

                foreach (DataRow dr in dsPuntuaciones.Tables[0].Rows)
                {
                    listaPuntuaciones.Add(new PuntuacionVO(dr));
                }

                return listaPuntuaciones;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Listar por ID
        public static PuntuacionVO GetPuntuacionById(int puntuacionId)
        {
            try
            {
                DataSet dsPuntuacion = MetodoDatos.ExecuteDataSet("sp_LeerPuntuacion", "@PuntuacionId", puntuacionId);

                if (dsPuntuacion.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = dsPuntuacion.Tables[0].Rows[0];
                    return new PuntuacionVO(dr);
                }
                else
                {
                    return new PuntuacionVO();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Actualizar
        public static void UdpPuntuacion(int puntuacionId, int peliculaId, string plataforma, float puntuacion)
        {
            try
            {
                MetodoDatos.ExecuteNonQuery("sp_ActualizarPuntuacion",
                    "@PuntuacionId", puntuacionId,
                    "@PeliculaId", peliculaId,
                    "@Plataforma", plataforma,
                    "@Puntuacion", puntuacion);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Eliminar
        public static void DelPuntuacion(int puntuacionId)
        {
            try
            {
                MetodoDatos.ExecuteNonQuery("sp_EliminarPuntuacion",
                    "@PuntuacionId", puntuacionId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
