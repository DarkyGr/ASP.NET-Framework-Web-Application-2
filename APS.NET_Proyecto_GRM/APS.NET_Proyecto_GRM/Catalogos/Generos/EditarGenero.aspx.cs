using APS.NET_Proyecto_GRM.Utilidades;
using Capa_BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace APS.NET_Proyecto_GRM.Catalogos.Generos
{
    public partial class EditarGenero : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Obtenemos el Id del QueryString
                if (Request.QueryString["Id"] == null)
                {
                    //Response.Redirect("ListarGeneros.aspx");
                    Titulo.Text = "Agregar Género";
                    Subtitulo.Text = "Registro de un nuevo Género para Pelíclas";
                }
                else    // Si existe el Id
                {
                    int generoId = int.Parse(Request.QueryString["Id"]);
                    GeneroVO genero = GenerosBLL.GetGeneroById(generoId);

                    Titulo.Text = "Editar Género";
                    Subtitulo.Text = "Actualizando Género con ID: " + generoId;

                    //this.Label1.Text = generoId.ToString();
                    if (genero.GeneroId != 0)
                    {
                        // Asginamos
                        this.txtNombre.Text = genero.Nombre;
                    }
                    else
                    {
                        // Redireccionar
                        Util.SweetBox("Ops...", "No se encontró el Género", "warning", this.Page, this.GetType());
                        //Response.Redirect("ListaChoferes.aspx");
                    }
                }
            }
        }

        //protected void btnSubeImagen_Click(object sender, EventArgs e)
        //{
        //    if (SubeImagen.Value != "")
        //    {
        //        // Recuperamos el nombre del archivo que subimos
        //        string fileName = Path.GetFileName(SubeImagen.PostedFile.FileName);
        //        // Vamos a validar la extencion del archivo
        //        string fileExt = Path.GetExtension(fileName).ToLower();

        //        if ((fileExt != ".jpg") && (fileExt != ".png"))
        //        {
        //            Util.SweetBox("Error", "Seleccione un archivo valido ('.jpg/.png')", "error", this.Page, this.GetType());
        //        }
        //        else
        //        {
        //            // Verificamos que exista el directorio en el server
        //            string pathDir = Server.MapPath("~/Imagenes/Dvds/");

        //            // Validar si existe
        //            if (!Directory.Exists(pathDir))
        //            {
        //                Directory.CreateDirectory(pathDir); // Si no existe se crea
        //            }

        //            //  Guardamos la imagen en la carpeta correspondiente
        //            SubeImagen.PostedFile.SaveAs(pathDir + fileName);
        //            string urlFoto = "/Imagenes/Dvds/" + fileName;
        //            lblImagenNueva.Text = urlFoto;
        //            imgPortadaNueva.ImageUrl = urlFoto;
        //            btnGuardar.Visible = true;
        //        }
        //    }
        //    else
        //    {
        //        Util.SweetBox("Error", "Seleccione un archivo", "error", this.Page, this.GetType());
        //    }
        //}

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            GeneroVO genero = new GeneroVO();

            if (txtNombre.Text != "")
            {
                try
                {
                    // Agregar
                    genero.Nombre = txtNombre.Text;
                }
                catch (Exception ex)
                {
                    Util.SweetBox("Error", ex.Message, "error", this.Page, this.GetType());
                }

                if (Request.QueryString["Id"] == null)
                {
                    // Estoy agregando

                    // Ver si existe otro lenguaje con el mismo 
                    bool flag = false;
                    foreach (GeneroVO gen in GenerosBLL.GetListGeneros())
                    {
                        if (gen.Nombre == genero.Nombre)
                        {
                            flag = true;
                        }
                    }

                    // Si no existe se agrega
                    if (!flag)
                    {
                        string resultado = Do_Generos(genero, true);
                        Util.SweetBox("Correcto", resultado, "success", this.Page, this.GetType());
                    }
                    else
                    {
                        Util.SweetBox("Error", "Ya existe un género con el mismo nombre.", "error", this.Page, this.GetType());
                    }
                }
                else
                {
                    // Estoy Actualizando
                    genero.GeneroId = int.Parse(Request.QueryString["Id"]);
                    string resultado = Do_Generos(genero, false);
                    Util.SweetBox("Correcto", resultado, "success", this.Page, this.GetType());
                }
            }
            else
            {
                Util.SweetBox("Advertencia", "Ningún campo puede quedar vacío.", "warning", this.Page, this.GetType());
            }

        }

        private string Do_Generos(GeneroVO genero, bool accion)
        {
            string respuesta;

            if (accion)
            {
                // Agregar
                try
                {
                    GenerosBLL.InsGenero(genero.Nombre);
                    respuesta = "Género agregado con éxito";
                }
                catch (Exception ex)
                {
                    respuesta = "Error: " + ex.Message;
                }
            }
            else
            {
                // Actualizar
                try
                {
                    GenerosBLL.UdpGenero(genero.GeneroId, genero.Nombre);
                    respuesta = "Género actualizado con éxito";
                }
                catch (Exception ex)
                {
                    respuesta = "Error: " + ex.Message;
                }
            }

            return respuesta;
        }

    }
}