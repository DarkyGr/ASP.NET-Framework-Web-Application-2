using Capa_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace Capa_BLL
{
    public class AudiosBLL
    {
        // Insertar
        public static void InsAudio(string formato)
        {
            try
            {
                AudiosDAL.InsAudio(formato);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Listar
        public static List<AudioVO> GetListAudios()
        {
            return AudiosDAL.GetListAudios();
        }

        // Listar por ID
        public static AudioVO GetAudioById(int audioId)
        {
            return AudiosDAL.GetAudioById(audioId);
        }

        // Actualizar
        public static void UdpAudio(int audioId, string formato)
        {
            AudiosDAL.UdpAudio(audioId, formato);
        }

        // Eliminar
        public static string DelAudio(int audioId)
        {
            try
            {
                AudioVO audio = AudiosDAL.GetAudioById(audioId);

                if (audio != null)
                {
                    AudiosDAL.DelAudio(audioId);
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
