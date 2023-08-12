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
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        // Insertar
        [WebMethod]
        public int InsertarDvd(int peliculaId, int lenguajeId, int audioId, string isbn, string edicion, string formatoPantalla, string region, string fechaSalida, string urlFoto)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_InsertarDvd", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PeliculaId", peliculaId);
                        cmd.Parameters.AddWithValue("@LenguajeId", lenguajeId);
                        cmd.Parameters.AddWithValue("@AudioId", audioId);
                        cmd.Parameters.AddWithValue("@Isbn", isbn);
                        cmd.Parameters.AddWithValue("@Edicion", edicion);
                        cmd.Parameters.AddWithValue("@FormatoPantalla", formatoPantalla);
                        cmd.Parameters.AddWithValue("@Region", region);
                        DateTime fechaSalidaR = DateTime.Parse(fechaSalida);
                        cmd.Parameters.AddWithValue("@FechaSalida", fechaSalidaR);
                        cmd.Parameters.AddWithValue("@UrlFoto", urlFoto);

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
        public DataSet ConsultarDvds()
        {
            DataSet dataSet = new DataSet();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_LeerDvds", conn))
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
        public DataSet ConsultarDvdById(int dvdId)
        {
            DataSet dataSet = new DataSet();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_LeerDvd", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DvdId", dvdId);
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
        public int ActualizarDvd(int dvdId, int peliculaId, int lenguajeId, int audioId, string isbn, string edicion, string formatoPantalla, string region, DateTime fechaSalida, string urlFoto)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_ActualizarDvd", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DvdId", dvdId);
                        cmd.Parameters.AddWithValue("@PeliculaId", peliculaId);
                        cmd.Parameters.AddWithValue("@LenguajeId", lenguajeId);
                        cmd.Parameters.AddWithValue("@AudioId", audioId);
                        cmd.Parameters.AddWithValue("@Isbn", isbn);
                        cmd.Parameters.AddWithValue("@Edicion", edicion);
                        cmd.Parameters.AddWithValue("@FormatoPantalla", formatoPantalla);
                        cmd.Parameters.AddWithValue("@Region", region);
                        cmd.Parameters.AddWithValue("@FechaSalida", fechaSalida);
                        cmd.Parameters.AddWithValue("@UrlFoto", urlFoto);

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
        public int EliminarDvd(int dvdId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_EliminarDvd", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DvdId", dvdId);

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
    }
}
