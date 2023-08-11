using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace Capa_DAL
{
    public class LenguajesDAL
    {
        // Insertar
        public static void InsLenguaje(string nombre)
        {
            try
            {
                int result;

                result = MetodoDatos.ExecuteNonQuery("sp_InsertarLenguaje",
                    "@Nombre", nombre);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        // Listar
        public static List<LenguajeVO> GetListLenguajes()
        {
            List<LenguajeVO> listaLenguajes = new List<LenguajeVO>();

            try
            {
                DataSet dsLenguajes = MetodoDatos.ExecuteDataSet("sp_LeerLenguajes");                

                foreach (DataRow dr in dsLenguajes.Tables[0].Rows)
                {
                    listaLenguajes.Add(new LenguajeVO(dr));
                }

                return listaLenguajes;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Listar por ID
        public static LenguajeVO GetLenguajeById(int lenguajeId)
        {
            try
            {
                DataSet dsLenguaje = MetodoDatos.ExecuteDataSet("sp_LeerLenguaje", "@LenguajeId", lenguajeId);

                if (dsLenguaje.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = dsLenguaje.Tables[0].Rows[0];
                    return new LenguajeVO(dr);
                }
                else
                {
                    return new LenguajeVO();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Actualizar
        public static void UdpLenguaje(int lenguajeId, string nombre)
        {
            try
            {
                MetodoDatos.ExecuteNonQuery("sp_ActualizarLenguaje",
                    "@LenguajeId", lenguajeId,
                    "@Nombre", nombre);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Eliminar
        public static void DelLenguaje(int lenguajeId)
        {
            try
            {
                MetodoDatos.ExecuteNonQuery("sp_EliminarLenguaje",
                    "@LenguajeId", lenguajeId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
