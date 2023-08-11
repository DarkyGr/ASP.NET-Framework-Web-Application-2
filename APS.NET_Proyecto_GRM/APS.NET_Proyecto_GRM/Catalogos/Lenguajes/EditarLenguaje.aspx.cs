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

namespace APS.NET_Proyecto_GRM.Catalogos.Lenguajes
{
    public partial class EditarLenguaje : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Obtenemos el Id del QueryString
                if (Request.QueryString["Id"] == null)
                {
                    //Response.Redirect("ListarLenguajes.aspx");
                    Titulo.Text = "Agregar Lenguaje";
                    Subtitulo.Text = "Registro de un nuevo Lenguaje para DVD";
                }
                else    // Si existe el Id
                {
                    int lenguajeId = int.Parse(Request.QueryString["Id"]);
                    LenguajeVO lenguaje = LenguajesBLL.GetLenguajeById(lenguajeId);

                    Titulo.Text = "Editar Lenguaje";
                    Subtitulo.Text = "Actualizando Lenguaje con ID: " + lenguajeId;
                    //this.Label1.Text = lenguajeId.ToString();

                    if (lenguaje.LenguajeId != 0)
                    {
                        // Asginamos                        
                        this.txtNombre.Text = lenguaje.Nombre;                        
                    }
                    else
                    {
                        // Redireccionar
                        Util.SweetBox("Ops...", "No se encontró el Lenguaje", "warning", this.Page, this.GetType());
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
                        LenguajesBLL.InsLenguaje(nombre);
                        Util.SweetBox("Correcto", "El Lenguaje ha sido Agregado con Éxito!", "success", this.Page, this.GetType());
                    }
                    else
                    {
                        Util.SweetBox("Advertencia", "El campo Nombre del Lenguaje no puede quedar vacío!", "warning", this.Page, this.GetType());
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
                        LenguajeVO lenguajeVO = LenguajesBLL.GetLenguajeById(int.Parse(Request.QueryString["Id"]));
                        LenguajesBLL.UdpLenguaje(lenguajeVO.LenguajeId, nombre);
                        Util.SweetBox("Correcto", "El Lenguaje ha sido Actualizado con Éxito!", "success", this.Page, this.GetType());
                    }
                    else
                    {
                        Util.SweetBox("Advertencia", "El campo Nombre del Lenguaje no puede quedar vacío!", "warning", this.Page, this.GetType());
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