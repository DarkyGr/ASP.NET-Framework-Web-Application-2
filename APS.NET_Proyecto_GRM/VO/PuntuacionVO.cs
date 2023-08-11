using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class PuntuacionVO
    {
        private int _PuntuacionId;
        private int _PeliculaId;
        private string _Plataforma;
        private float _Puntuacion;

        public int PuntuacionId { get => _PuntuacionId; set => _PuntuacionId = value; }
        public int PeliculaId { get => _PeliculaId; set => _PeliculaId = value; }
        public string Plataforma { get => _Plataforma; set => _Plataforma = value; }
        public float Puntuacion { get => _Puntuacion; set => _Puntuacion = value; }

        public PuntuacionVO() {
            PuntuacionId = 0;
            PeliculaId = 0;
            Plataforma = string.Empty;
            Puntuacion = 0;
        }

        public PuntuacionVO(DataRow dr) {
            PuntuacionId = int.Parse(dr["PuntuacionId"].ToString());
            PeliculaId = int.Parse(dr["PeliculaId"].ToString());
            Plataforma = dr["Plataforma"].ToString();
            Puntuacion = float.Parse(dr["Puntuacion"].ToString());
        }
    }
}
