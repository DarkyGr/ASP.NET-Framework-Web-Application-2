using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace Capa_DAL
{
    public class GenerosDAL
    {
        // Insertar
        public static void InsGenero(string nombre)
        {
            try
            {
                int result;

                result = MetodoDatos.ExecuteNonQuery("sp_InsertarGenero",
                    "@Nombre", nombre);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        // Listar
        public static List<GeneroVO> GetListGeneros()
        {
            List<GeneroVO> listaGeneros = new List<GeneroVO>();

            try
            {
                DataSet dsGeneros = MetodoDatos.ExecuteDataSet("sp_LeerGeneros");

                foreach (DataRow dr in dsGeneros.Tables[0].Rows)
                {
                    listaGeneros.Add(new GeneroVO(dr));
                }

                return listaGeneros;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Listar por ID
        public static GeneroVO GetGeneroById(int generoId)
        {
            try
            {
                DataSet dsGenero = MetodoDatos.ExecuteDataSet("sp_LeerGenero", "@GeneroId", generoId);

                if (dsGenero.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = dsGenero.Tables[0].Rows[0];
                    return new GeneroVO(dr);
                }
                else
                {
                    return new GeneroVO();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Actualizar
        public static void UdpGenero(int generoId, string nombre)
        {
            try
            {
                MetodoDatos.ExecuteNonQuery("sp_ActualizarGenero",
                    "@GeneroId", generoId,
                    "@Nombre", nombre);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Eliminar
        public static void DelGenero(int generoId)
        {
            try
            {
                MetodoDatos.ExecuteNonQuery("sp_EliminarGenero",
                    "@GeneroId", generoId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
