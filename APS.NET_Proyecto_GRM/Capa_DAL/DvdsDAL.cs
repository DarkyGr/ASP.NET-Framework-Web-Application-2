using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace Capa_DAL
{
    public class DvdsDAL
    {
        // Insertar
        public static void InsDvd(int peliculaId, int lenguajeId, int audioId, string isbn, string edicion, string formatoPantalla, string region, DateTime fechaSalida, string UrlFoto)
        {
            try
            {
                int result;

                result = MetodoDatos.ExecuteNonQuery("sp_InsertarDvd",
                    "@PeliculaId", peliculaId,
                    "@LenguajeId", lenguajeId,
                    "@AudioId", audioId,
                    "@Isbn", isbn,
                    "@Edicion", edicion,
                    "@FormatoPantalla", formatoPantalla,
                    "@Region", region,
                    "@FechaSalida", fechaSalida,
                    "@UrlFoto", UrlFoto);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        // Listar
        public static List<DvdVO> GetListDvds()
        {
            List<DvdVO> listaDvds = new List<DvdVO>();

            try
            {
                DataSet dsDvds = MetodoDatos.ExecuteDataSet("sp_LeerDvds");

                foreach (DataRow dr in dsDvds.Tables[0].Rows)
                {
                    listaDvds.Add(new DvdVO(dr));
                }

                return listaDvds;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Listar por ID
        public static DvdVO GetDvdById(int dvdId)
        {
            try
            {
                DataSet dsDvd = MetodoDatos.ExecuteDataSet("sp_LeerDvd", "@DvdId", dvdId);

                if (dsDvd.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = dsDvd.Tables[0].Rows[0];
                    return new DvdVO(dr);
                }
                else
                {
                    return new DvdVO();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Actualizar
        public static void UdpDvd(int dvdId, int peliculaId, int lenguajeId, int audioId, string isbn, string edicion, string formatoPantalla, string region, DateTime fechaSalida, string UrlFoto)
        {
            try
            {
                MetodoDatos.ExecuteNonQuery("sp_ActualizarDvd",
                    "@DvdId", dvdId,
                    "@PeliculaId", peliculaId,
                    "@LenguajeId", lenguajeId,
                    "@AudioId", audioId,
                    "@Isbn", isbn,
                    "@Edicion", edicion,
                    "@FormatoPantalla", formatoPantalla,
                    "@Region", region,
                    "@FechaSalida", fechaSalida,
                    "@UrlFoto", UrlFoto);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Eliminar
        public static void DelDvd(int dvdId)
        {
            try
            {
                MetodoDatos.ExecuteNonQuery("sp_EliminarDvd",
                    "@DvdId", dvdId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
