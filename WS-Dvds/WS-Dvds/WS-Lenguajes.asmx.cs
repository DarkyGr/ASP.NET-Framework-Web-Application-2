using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WS_Dvds
{
    /// <summary>
    /// Summary description for WS_Generos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WS_Generos : System.Web.Services.WebService
    {

        // Insertar
        [WebMethod]
        public int InsertarLenguaje(string nombre)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_InsertarLenguaje", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Nombre", nombre);                        

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        return 1;
                    }
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        // Consultar Lenguajes
        [WebMethod]
        public DataSet ConsultarLenguajes()
        {
            DataSet dataSet = new DataSet();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_LeerLenguajes", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();

                        adapter.Fill(ds);
                        conn.Close();
                        return ds;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }

            return dataSet;
        }

        // Listar por ID
        [WebMethod]
        public DataSet ConsultarLenguajeById(int lenguajeId)
        {
            DataSet dataSet = new DataSet();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_LeerLenguaje", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@LenguajeId", lenguajeId);
                        conn.Open();

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();

                        adapter.Fill(ds);
                        conn.Close();
                        return ds;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }

            return dataSet;
        }

        // Actualizar
        [WebMethod]
        public int ActualizarLenguaje(int lenguajeId, string nombre)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_ActualizarLenguaje", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@LenguajeId", lenguajeId);
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        return 1;
                    }
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        // Eliminar
        [WebMethod]
        public string EliminarLenguaje(int lenguajeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_EliminarLenguaje", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@LenguajeId", lenguajeId);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        return "Se elimino correctamente el lenguaje.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "NO se pudo eliminar el lenguaje porque se esta usando en uno o varios DVD.";
            }
        }
    }
}
