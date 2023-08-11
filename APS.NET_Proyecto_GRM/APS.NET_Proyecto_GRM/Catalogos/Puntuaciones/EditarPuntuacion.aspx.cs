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

namespace APS.NET_Proyecto_GRM.Catalogos.Puntuaciones
{
    public partial class EditarPuntuacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Obtenemos el Id del QueryString
                if (Request.QueryString["Id"] == null)
                {
                    //Response.Redirect("ListarPuntuaciones.aspx");
                    Titulo.Text = "Agregar Puntuación";
                    Subtitulo.Text = "Registro de una nueva Puntuación";
                    ListItem i;

                    // DDL Pelicula Id
                    foreach (PeliculaVO pelicula in PeliculasBLL.GetListPeliculas())
                    {
                        i = new ListItem(pelicula.Nombre, pelicula.PeliculaId.ToString());
                        ddlPeliculaId.Items.Add(i);
                    }
                }
                else    // Si existe el Id
                {
                    int puntuacionId = int.Parse(Request.QueryString["Id"]);
                    PuntuacionVO puntuacion = PuntuacionesBLL.GetPuntuacionById(puntuacionId);

                    Titulo.Text = "Editar Puntuación";
                    Subtitulo.Text = "Actualizando la Puntuación con ID: " + puntuacionId;

                    //this.Label1.Text = puntuacionId.ToString();

                    if (puntuacion.PuntuacionId != 0)
                    {
                        // Asginamos
                        ListItem i;

                        // DDL Pelicula Id
                        foreach (PeliculaVO pelicula in PeliculasBLL.GetListPeliculas())
                        {
                            i = new ListItem(pelicula.Nombre, pelicula.PeliculaId.ToString());
                            ddlPeliculaId.Items.Add(i);
                        }
                        ddlPeliculaId.SelectedValue = puntuacion.PeliculaId.ToString();

                        this.txtPlataforma.Text = puntuacion.Plataforma;
                        this.txtPuntuacion.Text = puntuacion.Puntuacion.ToString();
                    }
                    else
                    {
                        // Redireccionar
                        Util.SweetBox("Ops...", "No se encontró la Puntuación", "warning", this.Page, this.GetType());
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
                    int peliculaId = int.Parse(ddlPeliculaId.SelectedItem.Value);
                    string plataforma = txtPlataforma.Text;
                    float puntuacion = float.Parse(txtPuntuacion.Text);

                    if (peliculaId != 0 && plataforma != "" && puntuacion > 0 && puntuacion <= 10)
                    {                        
                        PuntuacionesBLL.InsPuntuacion(peliculaId, plataforma, puntuacion);
                        Util.SweetBox("Correcto", "La Puntuación ha sido Agregada con Éxito!", "success", this.Page, this.GetType());
                    }
                    else
                    {
                        Util.SweetBox("Advertencia", "Ninguno de los campos puede estar vacío y el campo Puntuación se califica del 1 al 10 con y sin decimales.", "warning", this.Page, this.GetType());
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
                    int peliculaId = int.Parse(ddlPeliculaId.SelectedItem.Value);
                    string plataforma = txtPlataforma.Text;
                    float puntuacion = float.Parse(txtPuntuacion.Text);

                    if (peliculaId != 0 && plataforma != "" && puntuacion > 0 && puntuacion <= 10)
                    {
                        PuntuacionVO puntuacionVO = PuntuacionesBLL.GetPuntuacionById(int.Parse(Request.QueryString["Id"]));
                        PuntuacionesBLL.UdpPuntuacion(puntuacionVO.PuntuacionId, peliculaId, plataforma, puntuacion);
                        Util.SweetBox("Correcto", "La Puntuación ha sido Actualizada con Éxito!", "success", this.Page, this.GetType());
                    }
                    else
                    {
                        Util.SweetBox("Advertencia", "Ninguno de los campos puede estar vacío y el campo Puntuación se califica del 1 al 10 con y sin decimales.", "warning", this.Page, this.GetType());
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