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
            LenguajeVO lenguaje = new LenguajeVO();

            if (txtNombre.Text != "")
            {
                try
                {
                    // Agregar
                    lenguaje.Nombre = txtNombre.Text;
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
                    foreach (LenguajeVO len in LenguajesBLL.GetListLenguajes())
                    {
                        if (len.Nombre == lenguaje.Nombre)
                        {
                            flag = true;
                        }
                    }

                    // Si no existe se agrega
                    if (!flag)
                    {
                        string resultado = Do_Lenguajes(lenguaje, true);
                        Util.SweetBox("Correcto", resultado, "success", this.Page, this.GetType());
                    }
                    else
                    {
                        Util.SweetBox("Error", "Ya existe un lenguaje con el mismo nombre.", "error", this.Page, this.GetType());
                    }
                }
                else
                {
                    // Estoy Actualizando
                    lenguaje.LenguajeId = int.Parse(Request.QueryString["Id"]);
                    string resultado = Do_Lenguajes(lenguaje, false);
                    Util.SweetBox("Correcto", resultado, "success", this.Page, this.GetType());
                }
            }
            else
            {
                Util.SweetBox("Advertencia", "Ningún campo puede quedar vacío.", "warning", this.Page, this.GetType());
            }

        }

        private string Do_Lenguajes(LenguajeVO lenguaje, bool accion)
        {
            string respuesta;

            if (accion)
            {
                // Agregar
                try
                {
                    LenguajesBLL.InsLenguaje(lenguaje.Nombre);
                    respuesta = "Lenguaje agregado con éxito";
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
                    LenguajesBLL.UdpLenguaje(lenguaje.LenguajeId, lenguaje.Nombre);
                    respuesta = "Lenguaje actualizado con éxito";
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