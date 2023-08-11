using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class PeliculaVO
    {
        private int _PeliculaId;        
        private int _GeneroId;
        private string _Nombre;
        private float _DuracionHoras;
        private DateTime _FechaLanzamiento;
        private string _Imdb;

        public int PeliculaId { get => _PeliculaId; set => _PeliculaId = value; }        
        public int GeneroId { get => _GeneroId; set => _GeneroId = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public float DuracionHoras { get => _DuracionHoras; set => _DuracionHoras = value; }
        public DateTime FechaLanzamiento { get => _FechaLanzamiento; set => _FechaLanzamiento = value; }
        public string Imdb { get => _Imdb; set => _Imdb = value; }

        public PeliculaVO(){
            PeliculaId = 0;
            GeneroId = 0;
            Nombre = string.Empty;
            DuracionHoras = 0;
            FechaLanzamiento = DateTime.Parse("1990-01-01");
            Imdb = string.Empty;            
        }

        public PeliculaVO(DataRow dr)
        {
            PeliculaId = int.Parse(dr["PeliculaId"].ToString());
            GeneroId = int.Parse(dr["GeneroId"].ToString());
            Nombre = dr["Nombre"].ToString();
            DuracionHoras = float.Parse(dr["DuracionHoras"].ToString());
            FechaLanzamiento = DateTime.Parse(dr["FechaLanzamiento"].ToString());
            Imdb = dr["Imdb"].ToString();
        }
    }
}
