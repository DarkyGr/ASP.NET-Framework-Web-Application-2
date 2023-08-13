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

                    CargarDDL();
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
                        CargarDDL();
                        ddlPeliculaId.SelectedValue = puntuacion.PeliculaId.ToString();
                        ddlPeliculaId.Enabled = false;

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

        private void CargarDDL()
        {
            #region Pelicla
            ListItem ddlP = new ListItem("Seleccione una película", "0");
            ddlPeliculaId.Items.Add(ddlP);
            foreach (PeliculaVO pelicula in PeliculasBLL.GetListPeliculas())
            {
                ListItem i = new ListItem(pelicula.Nombre, pelicula.PeliculaId.ToString());
                ddlPeliculaId.Items.Add(i);
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
            PuntuacionVO puntuacion = new PuntuacionVO();

            if (int.Parse(ddlPeliculaId.Text) != 0 && txtPlataforma.Text != "" && float.Parse(txtPuntuacion.Text) > 0 && float.Parse(txtPuntuacion.Text) <= 10)
            {
                try
                {
                    // Agregar
                    puntuacion.PeliculaId = int.Parse(ddlPeliculaId.SelectedItem.Value);
                    puntuacion.Plataforma = txtPlataforma.Text;
                    puntuacion.Puntuacion = float.Parse(txtPuntuacion.Text);
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
                    foreach (PeliculaVO peliculaVO in PeliculasBLL.GetListPeliculas())
                    {
                        if (peliculaVO.PeliculaId == puntuacion.PeliculaId)
                        {
                            flag = true;
                        }
                    }

                    foreach (PuntuacionVO puntuaciones in PuntuacionesBLL.GetListPuntuaciones())
                    {
                        if (puntuaciones.Plataforma != puntuacion.Plataforma)
                        {
                            flag = false;
                        }
                        else
                        {
                            flag = true;
                        }
                    }

                    // Si no existe se agrega
                    if (!flag)
                    {
                        string resultado = Do_Puntuaciones(puntuacion, true);
                        Util.SweetBox("Correcto", resultado, "success", this.Page, this.GetType());
                    }
                    else
                    {
                        Util.SweetBox("Error", "Ya existe una Puntuación con la misma Película y Plataforma.", "error", this.Page, this.GetType());
                    }
                }
                else
                {
                    // Estoy Actualizando
                    puntuacion.PuntuacionId = int.Parse(Request.QueryString["Id"]);
                    string resultado = Do_Puntuaciones(puntuacion, false);
                    Util.SweetBox("Correcto", resultado, "success", this.Page, this.GetType());
                }
            }
            else
            {
                Util.SweetBox("Advertencia", "Ningún campo puede quedar vacío y Puntuación debe estar entre el rango de 1 a 10 (se aceptan decimales).", "warning", this.Page, this.GetType());
            }

        }

        private string Do_Puntuaciones(PuntuacionVO puntuacion, bool accion)
        {
            string respuesta;

            if (accion)
            {
                // Agregar
                try
                {
                    PuntuacionesBLL.InsPuntuacion(puntuacion.PeliculaId, puntuacion.Plataforma, puntuacion.Puntuacion);
                    respuesta = "Puntuación agregada con éxito";
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
                    PuntuacionesBLL.UdpPuntuacion(puntuacion.PuntuacionId, puntuacion.PeliculaId, puntuacion.Plataforma, puntuacion.Puntuacion);
                    respuesta = "Puntuación actualizada con éxito";
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