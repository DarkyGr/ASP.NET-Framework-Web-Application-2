using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class DvdVO
    {
        private int _DvdId;
        private int _PeliculaId;
        private int _LenguajeId;
        private int _AudioId;
        private string _Isbn;
        private string _Edicion;
        private string _FormatoPantalla;
        private string _Region;
        private DateTime _FechaSalida;
        private string _UrlFoto;

        public int DvdId { get => _DvdId; set => _DvdId = value; }
        public int PeliculaId { get => _PeliculaId; set => _PeliculaId = value; }
        public int LenguajeId { get => _LenguajeId; set => _LenguajeId = value; }
        public int AudioId { get => _AudioId; set => _AudioId = value; }
        public string Isbn { get => _Isbn; set => _Isbn = value; }
        public string Edicion { get => _Edicion; set => _Edicion = value; }
        public string FormatoPantalla { get => _FormatoPantalla; set => _FormatoPantalla = value; }
        public string Region { get => _Region; set => _Region = value; }
        public DateTime FechaSalida { get => _FechaSalida; set => _FechaSalida = value; }
        public string UrlFoto { get => _UrlFoto; set => _UrlFoto = value; }

        public DvdVO()
        {
            DvdId = 0;
            PeliculaId = 0;
            LenguajeId = 0;
            AudioId = 0;
            Isbn = string.Empty;
            Edicion = string.Empty;
            FormatoPantalla = string.Empty;
            Region = string.Empty;            
            FechaSalida = DateTime.Parse("1990-01-01");
            UrlFoto = string.Empty;
        }

        public DvdVO(DataRow dr)
        {
            DvdId = int.Parse(dr["DvdId"].ToString());
            PeliculaId = int.Parse(dr["PeliculaId"].ToString());
            LenguajeId = int.Parse(dr["LenguajeId"].ToString());
            AudioId = int.Parse(dr["AudioId"].ToString());
            Isbn = dr["Isbn"].ToString();
            Edicion = dr["Edicion"].ToString();
            FormatoPantalla = dr["FormatoPantalla"].ToString();
            Region = dr["Region"].ToString();
            FechaSalida = DateTime.Parse(dr["FechaSalida"].ToString());
            UrlFoto = dr["UrlFoto"].ToString();
        }

    }
}
