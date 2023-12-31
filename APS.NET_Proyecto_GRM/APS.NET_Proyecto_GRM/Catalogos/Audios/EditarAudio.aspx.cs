﻿using APS.NET_Proyecto_GRM.Utilidades;
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
            AudioVO audio = new AudioVO();

            if (txtFormato.Text != "")
            {
                try
                {
                    // Agregar
                    audio.Formato = txtFormato.Text;
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
                    foreach (AudioVO aud in AudiosBLL.GetListAudios())
                    {
                        if (aud.Formato == audio.Formato)
                        {
                            flag = true;
                        }
                    }

                    // Si no existe se agrega
                    if (!flag) { 
                        string resultado = Do_Audios(audio, true);
                        Util.SweetBox("Correcto", resultado, "success", this.Page, this.GetType());
                    }
                    else
                    {
                        Util.SweetBox("Error", "Ya existe un audio con el mismo nombre.", "error", this.Page, this.GetType());
                    }
                }
                else
                {
                    // Estoy Actualizando
                    audio.AudioId = int.Parse(Request.QueryString["Id"]);
                    string resultado = Do_Audios(audio, false);
                    Util.SweetBox("Correcto", resultado, "success", this.Page, this.GetType());
                }
            }
            else
            {
                Util.SweetBox("Advertencia", "Ningún campo puede quedar vacío.", "warning", this.Page, this.GetType());
            }
        }

        private string Do_Audios(AudioVO audio, bool accion)
        {
            string respuesta;

            if (accion)
            {
                // Agregar
                try
                {
                    AudiosBLL.InsAudio(audio.Formato);
                    respuesta = "Audio agregado con éxito";
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
                    AudiosBLL.UdpAudio(audio.AudioId, audio.Formato);
                    respuesta = "Aduio actualizado con éxito";
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