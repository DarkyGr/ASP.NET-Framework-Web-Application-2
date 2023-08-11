using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_DAL
{
    internal class Configuracion
    {

        static string cadenaConexion = @"Data Source = Localhost; Initial Catalog = Dvd; Integrated Security = True";

        public static string CadenaConexion { 

            get {
                return cadenaConexion;
            } 
        }
    }
}
