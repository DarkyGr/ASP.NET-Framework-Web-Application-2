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

namespace APS.NET_Proyecto_GRM.Catalogos.Audios
{
    public partial class EditarAudio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Obtenemos el Id del QueryString
                if (Request.QueryString["Id"] == null)
                {
                    //Response.Redirect("ListarAudios.aspx");
                    Titulo.Text = "Agregar Formato de Audio";
                    Subtitulo.Text = "Registro de un nuevo Formato de Audio para DVD";
                }
                else    // Si existe el Id
                {
                    int audioId = int.Parse(Request.QueryString["Id"]);
                    AudioVO audio = AudiosBLL.GetAudioById(audioId);

                    Titulo.Text = "Editar Formato de Audio";
                    Subtitulo.Text = "Actualizando Formato de Audio con ID: " + audioId;

                    //this.Label1.Text = audioId.ToString();
                    if (audio.AudioId != 0)
                    {
                        // Asginamos
                        this.txtFormato.Text = audio.Formato;
                    }
                    else
                    {
                        // Redireccionar
                        Util.SweetBox("Ops...", "No se encontró el Audio", "warning", this.Page, this.GetType());
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
                    string formato = txtFormato.Text;

                    if (formato != "")
                    {                        
                        AudiosBLL.InsAudio(formato);
                        Util.SweetBox("Correcto", "El Audio ha sido Agregado con Éxito!", "success", this.Page, this.GetType());
                    }
                    else
                    {
                        Util.SweetBox("Advertencia", "El campo Formato de Audio no puede quedar vacío!", "warning", this.Page, this.GetType());
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
                    string formato = txtFormato.Text;

                    if (formato != "")
                    {
                        AudioVO audioVO = AudiosBLL.GetAudioById(int.Parse(Request.QueryString["Id"]));
                        AudiosBLL.UdpAudio(audioVO.AudioId, formato);
                        Util.SweetBox("Correcto", "El Audio ha sido Actualizado con Éxito!", "success", this.Page, this.GetType());
                    }
                    else
                    {
                        Util.SweetBox("Advertencia", "El campo Formato de Audio no puede quedar vacío!", "warning", this.Page, this.GetType());
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