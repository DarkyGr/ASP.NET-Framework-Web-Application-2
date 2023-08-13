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

namespace APS.NET_Proyecto_GRM.Catalogos.Peliculas
{
    public partial class EditarPelicula : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Obtenemos el Id del QueryString
                if (Request.QueryString["Id"] == null)
                {
                    //Response.Redirect("ListarPeliculas.aspx");
                    Titulo.Text = "Agregar Película";
                    Subtitulo.Text = "Registro de una nueva Película";

                    CargarDDL();
                }
                else    // Si existe el Id
                {
                    int peliculaId = int.Parse(Request.QueryString["Id"]);
                    PeliculaVO pelicula = PeliculasBLL.GetPeliculaById(peliculaId);

                    Titulo.Text = "Editar Película";
                    Subtitulo.Text = "Actualizando la Película con ID: " + peliculaId;

                    //this.Label1.Text = peliculaId.ToString();

                    if (pelicula.PeliculaId != 0)
                    {
                        // Asginamos
                        CargarDDL();

                        this.txtNombre.Text = pelicula.Nombre;
                        this.txtDuracionHoras.Text = pelicula.DuracionHoras.ToString();
                        this.txtFechaLanzamiento.Text = pelicula.FechaLanzamiento.ToString();
                        this.txtImdb.Text = pelicula.Imdb;

                        ddlGeneroId.SelectedValue = pelicula.GeneroId.ToString();
                        
                        this.txtNombre.Enabled = false;
                        this.txtFechaLanzamiento.Enabled = false;
                        this.txtImdb.Enabled = false;
                    }
                    else
                    {
                        // Redireccionar
                        Util.SweetBox("Ops...", "No se encontró la Película", "warning", this.Page, this.GetType());
                        //Response.Redirect("ListaChoferes.aspx");
                    }
                }
            }
        }

        private void CargarDDL()
        {
            #region Genero
            ListItem ddlG = new ListItem("Seleccione un género", "0");
            ddlGeneroId.Items.Add(ddlG);
            foreach (GeneroVO genero in GenerosBLL.GetListGeneros())
            {
                ListItem i = new ListItem(genero.Nombre, genero.GeneroId.ToString());
                ddlGeneroId.Items.Add(i);
            }
            #endregion
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
            PeliculaVO pelicula = new PeliculaVO();

            if (int.Parse(ddlGeneroId.Text) != 0 && txtNombre.Text != "" && float.Parse(txtDuracionHoras.Text) != 0 && txtFechaLanzamiento.Text != "" && txtImdb.Text != "")
            {
                try
                {
                    // Agregar
                    pelicula.GeneroId = int.Parse(ddlGeneroId.SelectedValue);
                    pelicula.Nombre = txtNombre.Text;
                    pelicula.DuracionHoras = float.Parse(txtDuracionHoras.Text);
                    pelicula.Imdb = txtImdb.Text;
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
                    foreach (PeliculaVO peli in PeliculasBLL.GetListPeliculas())
                    {
                        if (peli.Nombre == pelicula.Nombre)
                        {
                            flag = true;
                        }
                    }

                    // Si no existe se agrega
                    if (!flag)
                    {
                        string resultado = Do_Peliculas(pelicula, true);
                        Util.SweetBox("Correcto", resultado, "success", this.Page, this.GetType());
                    }
                    else
                    {
                        Util.SweetBox("Error", "Ya existe una película con el mismo nombre.", "error", this.Page, this.GetType());
                    }
                }
                else
                {
                    // Estoy Actualizando
                    pelicula.PeliculaId = int.Parse(Request.QueryString["Id"]);
                    string resultado = Do_Peliculas(pelicula, false);
                    Util.SweetBox("Correcto", resultado, "success", this.Page, this.GetType());
                }
            }
            else
            {
                Util.SweetBox("Advertencia", "Ningún campo puede quedar vacío.", "warning", this.Page, this.GetType());
            }
        }

        private string Do_Peliculas(PeliculaVO pelicula, bool accion)
        {
            string respuesta;

            if (accion)
            {
                // Agregar
                try
                {
                    PeliculasBLL.InsPelicula(pelicula.GeneroId, pelicula.Nombre, pelicula.DuracionHoras, pelicula.FechaLanzamiento, pelicula.Imdb);
                    respuesta = "Película agregada con éxito";
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
                    PeliculasBLL.UdpPelicula(pelicula.PeliculaId, pelicula.GeneroId, pelicula.Nombre, pelicula.DuracionHoras, pelicula.FechaLanzamiento, pelicula.Imdb);
                    respuesta = "Película actualizada con éxito";
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