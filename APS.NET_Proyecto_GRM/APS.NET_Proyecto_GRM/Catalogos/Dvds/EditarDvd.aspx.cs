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

namespace APS.NET_Proyecto_GRM.Catalogos.Dvds
{
    public partial class EditarDvd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Obtenemos el Id del QueryString
                if (Request.QueryString["Id"] == null)
                {
                    //Response.Redirect("ListarDvds.aspx");
                    Titulo.Text = "Agregar DVD";
                    Subtitulo.Text = "Registro de un nuevo DVD";
                    ListItem i;

                    // DDL Pelicula Id
                    foreach (PeliculaVO pelicula in PeliculasBLL.GetListPeliculas())
                    {                        
                        i = new ListItem(pelicula.Nombre, pelicula.PeliculaId.ToString());
                        ddlPeliculaId.Items.Add(i);
                    }
                    //ddlPeliculaId.SelectedItem.Text = "Seleccione uno de la lista";

                    // DDL Lenguaje Id
                    foreach (LenguajeVO lenguaje in LenguajesBLL.GetListLenguajes())
                    {                        
                        i = new ListItem(lenguaje.Nombre, lenguaje.LenguajeId.ToString());
                        ddlLenguajeId.Items.Add(i);
                    }

                    // DDL Audio Id
                    foreach (AudioVO audio in AudiosBLL.GetListAudios())
                    {                        
                        i = new ListItem(audio.Formato, audio.AudioId.ToString());
                        ddlAudioId.Items.Add(i);
                    }
                }
                else    // Si existe el Id
                {
                    int dvdId = int.Parse(Request.QueryString["Id"]);
                    DvdVO dvd = DvdsBLL.GetDvdById(dvdId);

                    Titulo.Text = "Editar DVD";
                    Subtitulo.Text = "Actualizando el DVD con ID: " + dvdId;

                    //this.Label1.Text = dvdId.ToString();

                    if (dvd.DvdId != 0)
                    {
                        // Asginamos
                        ListItem i;
                        this.txtIsbn.Text = dvd.Isbn;
                        this.txtEdicion.Text = dvd.Edicion;
                        this.txtFormatoPantalla.Text = dvd.FormatoPantalla;
                        this.txtRegion.Text = dvd.Region;
                        this.txtFechaSalida.Text = dvd.FechaSalida.ToString();

                        this.imgPortadaVieja.ImageUrl = dvd.UrlFoto;
                        this.lblPortadaVieja.Text = dvd.UrlFoto;

                        // DDL Pelicula Id
                        foreach (PeliculaVO pelicula in PeliculasBLL.GetListPeliculas())
                        {                            
                            i = new ListItem(pelicula.Nombre, pelicula.PeliculaId.ToString());
                            ddlPeliculaId.Items.Add(i);
                        }
                        ddlPeliculaId.SelectedValue = dvd.PeliculaId.ToString();

                        // DDL Lenguaje Id
                        foreach (LenguajeVO lenguaje in LenguajesBLL.GetListLenguajes())
                        {                            
                            i = new ListItem(lenguaje.Nombre, lenguaje.LenguajeId.ToString());
                            ddlLenguajeId.Items.Add(i);
                        }
                        ddlLenguajeId.SelectedValue = dvd.LenguajeId.ToString();

                        // DDL Audio Id
                        foreach (AudioVO audio in AudiosBLL.GetListAudios())
                        {                            
                            i = new ListItem(audio.Formato, audio.AudioId.ToString());
                            ddlAudioId.Items.Add(i);
                        }
                        ddlAudioId.SelectedValue = dvd.AudioId.ToString();
                    }
                    else
                    {
                        // Redireccionar
                        Util.SweetBox("Ops...", "No se encontró el DVD", "warning", this.Page, this.GetType());
                        //Response.Redirect("ListaChoferes.aspx");
                    }
                }
            }
        }

        protected void btnSubeImagen_Click(object sender, EventArgs e)
        {
            if (SubeImagen.Value != "")
            {
                // Recuperamos el nombre del archivo que subimos
                string fileName = Path.GetFileName(SubeImagen.PostedFile.FileName);
                // Vamos a validar la extencion del archivo
                string fileExt = Path.GetExtension(fileName).ToLower();

                if ((fileExt != ".jpg") && (fileExt != ".png"))
                {
                    Util.SweetBox("Error", "Seleccione un archivo valido ('.jpg/.png')", "error", this.Page, this.GetType());
                }
                else
                {
                    // Verificamos que exista el directorio en el server
                    string pathDir = Server.MapPath("~/Imagenes/Dvds/");

                    // Validar si existe
                    if (!Directory.Exists(pathDir))
                    {
                        Directory.CreateDirectory(pathDir); // Si no existe se crea
                    }

                    //  Guardamos la imagen en la carpeta correspondiente
                    SubeImagen.PostedFile.SaveAs(pathDir + fileName);
                    string urlFoto = "/Imagenes/Dvds/" + fileName;
                    lblPortadaNueva.Text = urlFoto;
                    imgPortadaNueva.ImageUrl = urlFoto;
                    btnGuardar.Visible = true;
                }
            }
            else
            {
                Util.SweetBox("Error", "Seleccione un archivo", "error", this.Page, this.GetType());
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["Id"] == null)
            {
                try
                {
                    int peliculaId = int.Parse(ddlPeliculaId.SelectedItem.Value);
                    int lenguajeId = int.Parse(ddlLenguajeId.SelectedItem.Value);
                    int audioId = int.Parse(ddlAudioId.SelectedItem.Value);
                    string isbn = txtIsbn.Text;
                    string edicion = txtEdicion.Text;
                    string formatoPantalla = txtFormatoPantalla.Text;
                    string region = txtRegion.Text;
                    string fechaSalida = txtFechaSalida.Text;
                    string urlFoto = lblPortadaNueva.Text;

                    if (peliculaId != 0 && lenguajeId != 0 && audioId != 0 && isbn != "" && fechaSalida != "")
                    {
                        DvdsBLL.InsDvd(peliculaId, lenguajeId, audioId, isbn, edicion, formatoPantalla, region, DateTime.Parse(fechaSalida), urlFoto);
                        Util.SweetBox("Correcto", "El DVD ha sido Agregado con Éxito!", "success", this.Page, this.GetType());
                    }
                    else
                    {
                        Util.SweetBox("Advertencia", "Los campos Nombre de Película, Lenguaje, Formato de Audio, Isbn y Fecha de Lanzamiento no pueden estar vacíos.", "warning", this.Page, this.GetType());
                    }
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
                    int peliculaId = int.Parse(ddlPeliculaId.SelectedItem.Value);
                    int lenguajeId = int.Parse(ddlLenguajeId.SelectedItem.Value);
                    int audioId = int.Parse(ddlAudioId.SelectedItem.Value);
                    string isbn = txtIsbn.Text;
                    string edicion = txtEdicion.Text;
                    string formatoPantalla = txtFormatoPantalla.Text;
                    string region = txtRegion.Text;
                    string fechaSalida = txtFechaSalida.Text;
                    string urlFoto = lblPortadaNueva.Text;

                    if (peliculaId != 0 && lenguajeId != 0 && audioId != 0 && isbn != "" && fechaSalida != "")
                    {
                        DvdVO dvdVO = DvdsBLL.GetDvdById(int.Parse(Request.QueryString["Id"]));
                        DvdsBLL.UdpDvd(dvdVO.DvdId, peliculaId, lenguajeId, audioId, isbn, edicion, formatoPantalla, region, DateTime.Parse(fechaSalida), urlFoto);
                        Util.SweetBox("Correcto", "El DVD ha sido Actualizado con Éxito!", "success", this.Page, this.GetType());
                    }
                    else
                    {
                        Util.SweetBox("Advertencia", "Los campos Nombre de Película, Lenguaje, Formato de Audio, Isbn y Fecha de Lanzamiento no pueden estar vacíos.", "warning", this.Page, this.GetType());
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