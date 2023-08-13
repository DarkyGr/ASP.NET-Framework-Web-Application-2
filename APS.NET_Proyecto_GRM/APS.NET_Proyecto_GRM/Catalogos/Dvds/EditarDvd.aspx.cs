using APS.NET_Proyecto_GRM.Utilidades;
using Capa_BLL;
using System;
using System.Collections.Generic;
using System.Drawing;
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

                    CargarDDL();
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
                        CargarDDL();

                        this.txtIsbn.Text = dvd.Isbn;
                        this.txtEdicion.Text = dvd.Edicion;
                        this.txtFormatoPantalla.Text = dvd.FormatoPantalla;
                        this.txtRegion.Text = dvd.Region;
                        this.txtFechaSalida.Text = dvd.FechaSalida.ToString();

                        this.imgPortadaVieja.ImageUrl = dvd.UrlFoto;
                        this.lblPortadaVieja.Text = dvd.UrlFoto;

                        ddlPeliculaId.SelectedValue = dvd.PeliculaId.ToString();
                        ddlLenguajeId.SelectedValue = dvd.LenguajeId.ToString();
                        ddlAudioId.SelectedValue = dvd.AudioId.ToString();

                        this.txtIsbn.Enabled = false;
                        this.txtFechaSalida.Enabled = false;
                        ddlPeliculaId.Enabled = false;
                        ddlLenguajeId.Enabled = false;
                        ddlAudioId.Enabled = false;
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

        private void CargarDDL()
        {
            #region Pelicula
            ListItem ddlP = new ListItem("Seleccione una película", "0");
            ddlPeliculaId.Items.Add(ddlP);
            foreach (PeliculaVO pelicula in PeliculasBLL.GetListPeliculas())
            {
                ListItem i = new ListItem(pelicula.Nombre, pelicula.PeliculaId.ToString());
                ddlPeliculaId.Items.Add(i);
            }
            #endregion

            #region Lenguaje
            ListItem ddlL = new ListItem("Seleccione un lenguaje", "0");
            ddlLenguajeId.Items.Add(ddlL);
            foreach (LenguajeVO lenguaje in LenguajesBLL.GetListLenguajes())
            {
                ListItem i = new ListItem(lenguaje.Nombre, lenguaje.LenguajeId.ToString());
                ddlLenguajeId.Items.Add(i);
            }
            #endregion

            #region Audio
            ListItem ddlA = new ListItem("Seleccione un Formato", "0");
            ddlAudioId.Items.Add(ddlA);
            foreach (AudioVO audio in AudiosBLL.GetListAudios())
            {
                ListItem i = new ListItem(audio.Formato, audio.AudioId.ToString());
                ddlAudioId.Items.Add(i);
            }
            #endregion
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
            DvdVO dvd = new DvdVO();

            if (int.Parse(ddlPeliculaId.Text) != 0 && int.Parse(ddlLenguajeId.Text) != 0 && int.Parse(ddlAudioId.Text) != 0 && txtIsbn.Text != "" && txtFechaSalida.Text != "")
            {
                try
                {
                    // Agregar
                    dvd.PeliculaId = int.Parse(ddlPeliculaId.SelectedValue);
                    dvd.LenguajeId = int.Parse(ddlLenguajeId.SelectedValue);
                    dvd.AudioId = int.Parse(ddlAudioId.SelectedValue);
                    dvd.Isbn = txtIsbn.Text;
                    dvd.Edicion = txtEdicion.Text;
                    dvd.FormatoPantalla = txtFormatoPantalla.Text;
                    dvd.Region = txtRegion.Text;
                    dvd.FechaSalida = DateTime.Parse(txtFechaSalida.Text);
                    dvd.UrlFoto = lblPortadaNueva.Text;
                }
                catch (Exception ex)
                {
                    Util.SweetBox("Error", ex.Message, "error", this.Page, this.GetType());
                }

                if (Request.QueryString["Id"] == null)
                {
                    // Estoy agregando

                    // Ver si existe otro isbn con el mismo 
                    bool flag = false;
                    foreach (DvdVO dvdd in DvdsBLL.GetListDvds())
                    {
                        if (dvdd.Isbn == dvd.Isbn)
                        {
                            flag = true;
                        }
                    }
                    // Si no existe se agrega
                    if (!flag)
                    {
                        string resultado = Do_Dvds(dvd, true);
                        Util.SweetBox("Correcto", resultado, "success", this.Page, this.GetType());
                    }
                    else
                    {
                        Util.SweetBox("Error", "Ya existe un DVD con el mismo Isbn.", "error", this.Page, this.GetType());
                    }
                }
                else
                {
                    // Estoy Actualizando
                    dvd.DvdId = int.Parse(Request.QueryString["Id"]);
                    string resultado = Do_Dvds(dvd, false);
                    Util.SweetBox("Correcto", resultado, "success", this.Page, this.GetType());
                }
            }
            else
            {
                Util.SweetBox("Advertencia", "Los campos Nombre de Película, Lenguaje, Formato de Audio, Isbn y Fecha de Lanzamiento no pueden estar vacíos.", "warning", this.Page, this.GetType());
            }
        }

        private string Do_Dvds(DvdVO dvd, bool accion)
        {
            string respuesta;

            if (accion)
            {
                // Agregar
                try
                {
                    DvdsBLL.InsDvd(dvd.PeliculaId, dvd.LenguajeId, dvd.AudioId, dvd.Isbn, dvd.Edicion, dvd.FormatoPantalla, dvd.Region, dvd.FechaSalida, dvd.UrlFoto);
                    respuesta = "DVD agregado con éxito";
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
                    DvdsBLL.UdpDvd(dvd.DvdId, dvd.PeliculaId, dvd.LenguajeId, dvd.AudioId, dvd.Isbn, dvd.Edicion, dvd.FormatoPantalla, dvd.Region, dvd.FechaSalida, dvd.UrlFoto);
                    respuesta = "DVD actualizado con éxito";
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