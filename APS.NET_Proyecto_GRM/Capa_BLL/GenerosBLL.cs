using Capa_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace Capa_BLL
{
    public class GenerosBLL
    {
        // Insertar
        public static void InsGenero(string nombre)
        {
            try
            {
                GenerosDAL.InsGenero(nombre);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Listar
        public static List<GeneroVO> GetListGeneros()
        {
            return GenerosDAL.GetListGeneros();
        }

        // Listar por ID
        public static GeneroVO GetGeneroById(int generoId)
        {
            return GenerosDAL.GetGeneroById(generoId);
        }

        // Actualizar
        public static void UdpGenero(int generoId, string nombre)
        {
            GenerosDAL.UdpGenero(generoId, nombre);
        }

        // Eliminar
        public static string DelGenero(int generoId)
        {
            try
            {
                GeneroVO genero = GenerosDAL.GetGeneroById(generoId);

                if (genero != null)
                {
                    GenerosDAL.DelGenero(generoId);
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
