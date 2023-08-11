using Capa_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace Capa_BLL
{
    public class DvdsBLL
    {
        // Insertar
        public static void InsDvd(int peliculaId, int lenguajeId, int audioId, string isbn, string edicion, string formatoPantalla, string region, DateTime fechaSalida, string UrlFoto)
        {
            try
            {
                DvdsDAL.InsDvd(peliculaId, lenguajeId, audioId, isbn, edicion, formatoPantalla, region, fechaSalida, UrlFoto);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Listar
        public static List<DvdVO> GetListDvds()
        {
            return DvdsDAL.GetListDvds();
        }

        // Listar por ID
        public static DvdVO GetDvdById(int dvdId)
        {
            return DvdsDAL.GetDvdById(dvdId);
        }

        // Actualizar
        public static void UdpDvd(int dvdId, int peliculaId, int lenguajeId, int audioId, string isbn, string edicion, string formatoPantalla, string region, DateTime fechaSalida, string UrlFoto)
        {
            DvdsDAL.UdpDvd(dvdId, peliculaId, lenguajeId, audioId, isbn, edicion, formatoPantalla, region, fechaSalida, UrlFoto);
        }

        // Eliminar
        public static string DelDvd(int dvdId)
        {
            try
            {
                DvdVO dvd = DvdsDAL.GetDvdById(dvdId);

                if (dvd != null)
                {
                    DvdsDAL.DelDvd(dvdId);
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
