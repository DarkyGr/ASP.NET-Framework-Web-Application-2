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
                    ListItem i;

                    // DDL Genero Id
                    foreach (GeneroVO genero in GenerosBLL.GetListGeneros())
                    {
                        i = new ListItem(genero.Nombre, genero.GeneroId.ToString());
                        ddlGeneroId.Items.Add(i);
                    }
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
                        ListItem i;

                        // DDL Genero Id
                        foreach (GeneroVO genero in GenerosBLL.GetListGeneros())
                        {
                            i = new ListItem(genero.Nombre, genero.GeneroId.ToString());
                            ddlGeneroId.Items.Add(i);
                        }
                        ddlGeneroId.SelectedValue = pelicula.GeneroId.ToString();

                        this.txtNombre.Text = pelicula.Nombre;
                        this.txtDuracionHoras.Text = pelicula.DuracionHoras.ToString();
                        this.txtFechaLanzamiento.Text = pelicula.FechaLanzamiento.ToString();
                        this.txtImdb.Text = pelicula.Imdb;
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
                    int generoId = int.Parse(ddlGeneroId.SelectedItem.Value);
                    string nombre = txtNombre.Text;
                    float duracionHoras = float.Parse(txtDuracionHoras.Text);
                    string fechaLanzamiento = txtFechaLanzamiento.Text;
                    string imdb = txtImdb.Text;

                    if (generoId != 0 && nombre != "" && duracionHoras != 0 && fechaLanzamiento != "" && imdb != "")
                    {                        
                        PeliculasBLL.InsPelicula(generoId, nombre, duracionHoras, DateTime.Parse(fechaLanzamiento), imdb);
                        Util.SweetBox("Correcto", "La Película ha sido Agregada con Éxito!", "success", this.Page, this.GetType());
                    }
                    else
                    {
                        Util.SweetBox("Advertencia", "Ninguno de los campos puede estar vacío.", "warning", this.Page, this.GetType());
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
                    int generoId = int.Parse(ddlGeneroId.SelectedItem.Value);
                    string nombre = txtNombre.Text;
                    float duracionHoras = float.Parse(txtDuracionHoras.Text);
                    string fechaLanzamiento = txtFechaLanzamiento.Text;
                    string imdb = txtImdb.Text;

                    if (generoId != 0 && nombre != "" && duracionHoras != 0 && fechaLanzamiento != "" && imdb != "")
                    {
                        PeliculaVO peliculaVO = PeliculasBLL.GetPeliculaById(int.Parse(Request.QueryString["Id"]));
                        PeliculasBLL.UdpPelicula(peliculaVO.PeliculaId, generoId, nombre, duracionHoras, DateTime.Parse(fechaLanzamiento), imdb);
                        Util.SweetBox("Correcto", "La Película ha sido Actualizada con Éxito!", "success", this.Page, this.GetType());
                    }
                    else
                    {
                        Util.SweetBox("Advertencia", "Ninguno de los campos puede estar vacío.", "warning", this.Page, this.GetType());
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