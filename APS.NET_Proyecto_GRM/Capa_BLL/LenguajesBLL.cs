using Capa_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace Capa_BLL
{
    public class LenguajesBLL
    {
        // Insertar
        public static void InsLenguaje(string nombre)
        {
            try
            {
                LenguajesDAL.InsLenguaje(nombre);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Listar
        public static List<LenguajeVO> GetListLenguajes()
        {
            return LenguajesDAL.GetListLenguajes();
        }

        // Listar por ID
        public static LenguajeVO GetLenguajeById(int lenguajeId)
        {
            return LenguajesDAL.GetLenguajeById(lenguajeId);
        }

        // Actualizar
        public static void UdpLenguaje(int lenguajeId, string nombre)
        {
            LenguajesDAL.UdpLenguaje(lenguajeId, nombre);
        }

        // Eliminar
        public static string DelLenguaje(int lenguajeId)
        {
            try
            {
                LenguajeVO lenguaje = LenguajesDAL.GetLenguajeById(lenguajeId);

                if (lenguaje != null)
                {
                    LenguajesDAL.DelLenguaje(lenguajeId);
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
