using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class AudioVO
    {
        private int _AudioId;
        private string _Formato;

        public int AudioId { get => _AudioId; set => _AudioId = value; }
        public string Formato { get => _Formato; set => _Formato = value; }

        public AudioVO() {
            AudioId = 0;
            Formato = string.Empty;
        }

        public AudioVO(DataRow dr)
        {
            AudioId = int.Parse(dr["AudioId"].ToString());
            Formato = dr["Formato"].ToString();
        }
    }
}
