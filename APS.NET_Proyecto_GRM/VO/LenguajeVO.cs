using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class LenguajeVO
    {
        private int _LenguajeId;
        private string _Nombre;

        public int LenguajeId { get => _LenguajeId; set => _LenguajeId = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }

        public LenguajeVO() { 
            LenguajeId = 0;
            Nombre = string.Empty;
        }

        public LenguajeVO(DataRow dr)
        {
            LenguajeId = int.Parse(dr["LenguajeId"].ToString());
            Nombre = dr["Nombre"].ToString();
        }
    }
}
