using Capa_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace Capa_BLL
{
    public class PuntuacionesBLL
    {
        // Insertar
        public static void InsPuntuacion(int peliculaId, string plataforma, float puntuacion)
        {
            try
            {
                PuntuacionesDAL.InsPuntuacion(peliculaId, plataforma, puntuacion);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Listar
        public static List<PuntuacionVO> GetListPuntuaciones()
        {
            return PuntuacionesDAL.GetListPuntuaciones();
        }

        // Listar por ID
        public static PuntuacionVO GetPuntuacionById(int puntuacionId)
        {
            return PuntuacionesDAL.GetPuntuacionById(puntuacionId);
        }

        // Actualizar
        public static void UdpPuntuacion(int puntuacionId, int peliculaId, string plataforma, float puntuacion)
        {
            PuntuacionesDAL.UdpPuntuacion(puntuacionId, peliculaId, plataforma, puntuacion);
        }

        // Eliminar
        public static string DelPuntuacion(int puntuacionId)
        {
            try
            {
                PuntuacionVO puntuacion = PuntuacionesDAL.GetPuntuacionById(puntuacionId);

                if (puntuacion != null)
                {
                    PuntuacionesDAL.DelPuntuacion(puntuacionId);
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
