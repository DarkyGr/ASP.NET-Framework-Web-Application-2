using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace APS.NET_Proyecto_GRM.Utilidades
{
    public class Util
    {
        public static void SweetBox(string ex, string sub, string type, Page pg, object obj)
        {
            string s = "<SCRIPT languaje='javascript'>swal('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "','" + sub.Replace("\r\n", "\\n").Replace("'", "") + "','" + type + "')</SCRIPT";
            Type csType = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(csType, s, s.ToString());
        }
    }
}