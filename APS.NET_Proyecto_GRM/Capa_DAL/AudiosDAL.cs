using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace Capa_DAL
{
    public class AudiosDAL
    {
        // Insertar
        public static void InsAudio(string formato)
        {
            try
            {
                int result;

                result = MetodoDatos.ExecuteNonQuery("sp_InsertarAudio",
                    "@Formato", formato);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        // Listar
        public static List<AudioVO> GetListAudios()
        {
            List<AudioVO> listaAudios = new List<AudioVO>();

            try
            {
                DataSet dsAudios = MetodoDatos.ExecuteDataSet("sp_LeerAudios");

                foreach (DataRow dr in dsAudios.Tables[0].Rows)
                {
                    listaAudios.Add(new AudioVO(dr));
                }

                return listaAudios;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Listar por ID
        public static AudioVO GetAudioById(int audioId)
        {
            try
            {
                DataSet dsAudio = MetodoDatos.ExecuteDataSet("sp_LeerAudio", "@AudioId", audioId);

                if (dsAudio.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = dsAudio.Tables[0].Rows[0];
                    return new AudioVO(dr);
                }
                else
                {
                    return new AudioVO();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Actualizar
        public static void UdpAudio(int audioId, string formato)
        {
            try
            {
                MetodoDatos.ExecuteNonQuery("sp_ActualizarAudio",
                    "@AudioId", audioId,
                    "@Formato", formato);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Eliminar
        public static void DelAudio(int audioId)
        {
            try
            {
                MetodoDatos.ExecuteNonQuery("sp_EliminarAudio",
                    "@AudioId", audioId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
