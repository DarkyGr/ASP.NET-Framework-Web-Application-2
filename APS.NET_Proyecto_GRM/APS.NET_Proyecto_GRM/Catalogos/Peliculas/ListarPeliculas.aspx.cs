using APS.NET_Proyecto_GRM.Utilidades;
using Capa_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace APS.NET_Proyecto_GRM.Catalogos.Pelicula
{
    public partial class ListarPeliculas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Evaluamos si la pagina no se haya refrescado (solo abrir la page)
            if (!IsPostBack)
            {
                try
                {
                    RefrescarGrid();
                }
                catch (Exception ex)
                {

                }
            }
        }

        public void RefrescarGrid()
        {
            // Lenamos el grid de los datos de los choferes
            GVPeliculas.DataSource = PeliculasBLL.GetListPeliculas();

            // Actualizar el contenido del Grid
            GVPeliculas.DataBind();
        }

        protected void GVPeliculas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string PeliculaId = GVPeliculas.DataKeys[e.RowIndex].Values["PeliculaId"].ToString();
            string Resultado = PeliculasBLL.DelPelicula(int.Parse(PeliculaId));
            string mensaje = "";
            string sub = "";
            string clase = "";

            switch (Resultado)
            {
                case "1":
                    mensaje = "Película eliminada con EXITO!!";
                    sub = "";
                    clase = "success";
                    break;

                case "0":
                    mensaje = "La Película NO puede ser eliminado";
                    sub = "Pregunte con nuestro soporte tecnico";
                    clase = "warning";
                    break;
            }
            Util.SweetBox(mensaje, sub, clase, this.Page, this.GetType());
            RefrescarGrid();
        }

        protected void GVPeliculas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Aqui redireccionar al formulario de editar
            if (e.CommandName == "Select")
            {
                // Recuperando indice del comando que lo ejecuto
                int peliculaId = int.Parse(e.CommandArgument.ToString());
                // obtener la cadena del comando que lo detono
                string peliculaIdParaEnviar = GVPeliculas.DataKeys[peliculaId].Values["PeliculaId"].ToString();
                // completamos la url concatenando con el chofer id para enviar
                Response.Redirect("EditarPelicula.aspx?Id=" + peliculaIdParaEnviar);
            }

        }

        protected void GVPeliculas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Get index de la tupla a editar
            GVPeliculas.EditIndex = e.NewEditIndex;
            RefrescarGrid();
        }

        protected void GVPeliculas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string peliculaId = GVPeliculas.DataKeys[e.RowIndex].Values["PeliculaId"].ToString();

            string nombre = e.NewValues["Nombre"].ToString();
            string duracionHoras = e.NewValues["DuracionHoras"].ToString();

            PeliculaVO peliculaVO = PeliculasBLL.GetPeliculaById(int.Parse(peliculaId));
            PeliculasBLL.UdpPelicula(int.Parse(peliculaId), peliculaVO.GeneroId, nombre, float.Parse(duracionHoras), peliculaVO.FechaLanzamiento, peliculaVO.Imdb);
            GVPeliculas.EditIndex = -1;
            RefrescarGrid();
            Util.SweetBox("Correcto", "La Película ha sido Actualizado con Éxito!", "success", this.Page, this.GetType());
        }

        protected void GVPeliculas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Actualizar index de pantalla
            GVPeliculas.EditIndex = -1;
            RefrescarGrid();
        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditarPelicula.aspx");
        }
    }
}