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
            if (Request.QueryString["Id"] == null)
            {
                try
                {
                    string nombre = txtNombre.Text;

                    if (nombre != "")
                    {                        
                        GenerosBLL.InsGenero(nombre);
                        Util.SweetBox("Correcto", "El Género ha sido Agregado con Éxito!", "success", this.Page, this.GetType());
                    }
                    else
                    {
                        Util.SweetBox("Advertencia", "El campo Nombre del Género no puede quedar vacío!", "warning", this.Page, this.GetType());
                    }

                    //Response.Redirect("ListaChoferes.aspx");
                }
                catch (Exception ex)
                {
                    Util.SweetBox("Error", ex.Message, "error", this.Page, this.GetType());
                }
            }
            else
            {
                try
                {
                    string nombre = txtNombre.Text;

                    if (nombre != "")
                    {
                        GeneroVO generoVO = GenerosBLL.GetGeneroById(int.Parse(Request.QueryString["Id"]));
                        GenerosBLL.UdpGenero(generoVO.GeneroId, nombre);
                        Util.SweetBox("Correcto", "El Género ha sido Actualizado con Éxito!", "success", this.Page, this.GetType());
                    }
                    else
                    {
                        Util.SweetBox("Advertencia", "El campo Nombre del Género no puede quedar vacío!", "warning", this.Page, this.GetType());
                    }

                    //Response.Redirect("ListaChoferes.aspx");
                }
                catch (Exception ex)
                {
                    Util.SweetBox("Error", ex.Message, "error", this.Page, this.GetType());
                }
            }
            
        }
    }
}