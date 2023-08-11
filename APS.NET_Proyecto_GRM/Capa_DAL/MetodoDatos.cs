using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_DAL
{
    internal class MetodoDatos
    {
        // Metodo para regresar una tabla con la informacion de la consulta - llena data set
        public static DataSet ExecuteDataSet(string sp, params object[] parametros)
        {
            DataSet ds = new DataSet();

            // Get cadenaConexion de la clase Configuracion
            string cadenaConexion = Configuracion.CadenaConexion;

            // Creamos la conexion
            SqlConnection con = new SqlConnection(cadenaConexion);

            try
            {

                // Verificamos si la conexion no este abierta
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
                else
                {
                    SqlCommand cmd = new SqlCommand(sp, con);

                    // Especificamos el tipo de comando
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = sp;

                    // Validamos si existen y estaen completos los parametros
                    if (parametros != null && parametros.Length % 2 != 0)
                    {
                        throw new Exception("Los parametros deben estar en pares (Clave:Valor)");
                    }
                    else
                    {
                        // Asignamos los parametros al Command
                        for (int i = 0; i < parametros.Length; i = i + 2)
                        {
                            // {Clave, valor, Clave, valor, Clave, valor}
                            // {Matricula, 'acbd', Nombre, 'Godo', Apellido, 'Carlos'}
                            // [0, 1, 2, 3, 4, 5]
                            // Exec sp_x @Clave = 'valor'
                            cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1]);
                        }

                        //Abrimos la conexion
                        con.Open();
                        // Ejecutar command
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        // Llenamos nuestro dataset
                        adapter.Fill(ds);
                        // Cerramos conexion
                        con.Close();
                    }
                }
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        // Metodo que ejeucte un escalar - retorna el valor de lo que se realizo
        public static int ExecuteScalar(string sp, params object[] parametros)
        {
            int id = 0;

            // Get cadenaConexion de la clase Configuracion
            string cadenaConexion = Configuracion.CadenaConexion;

            // Creamos la conexion
            SqlConnection con = new SqlConnection(cadenaConexion);

            try
            {
                // Verificamos si la conexion no este abierta
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
                else
                {
                    SqlCommand cmd = new SqlCommand(sp, con);

                    // Especificamos el tipo de comando
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = sp;

                    for (int i = 0; i < parametros.Length; i = i + 2)
                    {
                        // Asignamos los parametros al Command
                        // {Clave, valor, Clave, valor, Clave, valor}
                        // {Matricula, 'acbd', Nombre, 'Godo', Apellido, 'Carlos'}
                        // [0, 1, 2, 3, 4, 5]
                        // Exec sp_x @Clave = 'valor'
                        cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1]);
                    }
                    //Abrimos la conexion
                    con.Open();
                    // Ejecutar command
                    id = int.Parse(cmd.ExecuteScalar().ToString());
                    // Cerramos conexion
                    con.Close();

                }

                return id;
            }
            catch (Exception ex)
            {
                return id;
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        // Metodo que no retorna un valor - no regresa nada
        public static int ExecuteNonQuery(string sp, params object[] parametros)
        {
            int idOrigenDestino = 0;

            // Get cadenaConexion de la clase Configuracion
            string cadenaConexion = Configuracion.CadenaConexion;

            // Creamos la conexion
            SqlConnection con = new SqlConnection(cadenaConexion);

            try
            {
                // Verificamos si la conexion no este abierta
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
                else
                {
                    SqlCommand cmd = new SqlCommand(sp, con);

                    // Especificamos el tipo de comando
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = sp;

                    for (int i = 0; i < parametros.Length; i = i + 2)
                    {
                        // Asignamos los parametros al Command
                        // {Clave, valor, Clave, valor, Clave, valor}
                        // {Matricula, 'acbd', Nombre, 'Godo', Apellido, 'Carlos'}
                        // [0, 1, 2, 3, 4, 5]
                        // Exec sp_x @Clave = 'valor'
                        cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1]);
                    }
                    //Abrimos la conexion
                    con.Open();
                    // Ejecutar command
                    cmd.ExecuteNonQuery();
                    idOrigenDestino = 1;
                    // Cerramos conexion
                    con.Close();

                }

                return idOrigenDestino;
            }
            catch (Exception ex)
            {
                return idOrigenDestino;
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
    }

}
