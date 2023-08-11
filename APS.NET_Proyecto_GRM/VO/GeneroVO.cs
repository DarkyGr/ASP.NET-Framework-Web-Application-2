using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class GeneroVO
    {
        private int _GeneroId;
        private string _Nombre;

        public int GeneroId { get => _GeneroId; set => _GeneroId = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }

        public GeneroVO()
        {
            GeneroId = 0;
            Nombre = string.Empty;
        }

        public GeneroVO(DataRow dr)
        {
            GeneroId = int.Parse(dr["GeneroId"].ToString());
            Nombre = dr["Nombre"].ToString();
        }
    }
}
