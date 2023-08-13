using APS.NET_Proyecto_GRM.Utilidades;
using Capa_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace APS.NET_Proyecto_GRM.Catalogos.Generos
{
    public partial class ListarGeneros : System.Web.UI.Page
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
            GVGeneros.DataSource = GenerosBLL.GetListGeneros();

            // Actualizar el contenido del Grid
            GVGeneros.DataBind();
        }

        protected void GVGeneros_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string generoId = GVGeneros.DataKeys[e.RowIndex].Values["GeneroId"].ToString();
            bool flag = false; // True si existe un lenguaje en uno o varios DVDs -- False si no hay

            foreach (PeliculaVO peli in PeliculasBLL.GetListPeliculas())
            {
                if (peli.GeneroId == int.Parse(generoId))
                {
                    flag = true;
                }
            }

            if (!flag)
            {
                string Resultado = GenerosBLL.DelGenero(int.Parse(generoId));
                string mensaje = "";
                string sub = "";
                string clase = "";

                switch (Resultado)
                {
                    case "1":
                        mensaje = "Genero eliminado con ÉXITO!!";
                        sub = "";
                        clase = "success";
                        break;

                    case "0":
                        mensaje = "El Género NO puede ser eliminado";
                        sub = "Pregunte con nuestro soporte técnico";
                        clase = "warning";
                        break;
                }
                Util.SweetBox(mensaje, sub, clase, this.Page, this.GetType());
                RefrescarGrid();
            }
            else
            {
                Util.SweetBox("Error", "El Audio no se puede eliminar porque se encuentra en una o varias Películas.", "error", this.Page, this.GetType());
            }
        }

        protected void GVGeneros_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Aqui redireccionar al formulario de editar
            if (e.CommandName == "Select")
            {
                // Recuperando indice del comando que lo ejecuto
                int generoId = int.Parse(e.CommandArgument.ToString());
                // obtener la cadena del comando que lo detono
                string generoIdParaEnviar = GVGeneros.DataKeys[generoId].Values["GeneroId"].ToString();
                // completamos la url concatenando con el chofer id para enviar
                Response.Redirect("EditarGenero.aspx?Id=" + generoIdParaEnviar);
            }

        }

        protected void GVGeneros_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Get index de la tupla a editar
            GVGeneros.EditIndex = e.NewEditIndex;
            RefrescarGrid();
        }

        protected void GVGeneros_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string generoId = GVGeneros.DataKeys[e.RowIndex].Values["GeneroId"].ToString();
            string nombre = e.NewValues["Nombre"].ToString();

            GeneroVO generoVO = GenerosBLL.GetGeneroById(int.Parse(generoId));
            GenerosBLL.UdpGenero(int.Parse(generoId), nombre);
            GVGeneros.EditIndex = -1;
            RefrescarGrid();
            Util.SweetBox("Correcto", "El Género ha sido Actualizado con Éxito!", "success", this.Page, this.GetType());
        }

        protected void GVGeneros_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Actualizar index de pantalla
            GVGeneros.EditIndex = -1;
            RefrescarGrid();
        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditarGenero.aspx");
        }
    }
}