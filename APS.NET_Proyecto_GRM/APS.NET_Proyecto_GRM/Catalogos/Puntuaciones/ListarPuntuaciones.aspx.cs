using APS.NET_Proyecto_GRM.Utilidades;
using Capa_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace APS.NET_Proyecto_GRM.Catalogos.Puntuaciones
{
    public partial class ListarPuntuaciones : System.Web.UI.Page
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
            GVPuntuaciones.DataSource = PuntuacionesBLL.GetListPuntuaciones();

            // Actualizar el contenido del Grid
            GVPuntuaciones.DataBind();
        }

        protected void GVPuntuacion_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string PuntuacionId = GVPuntuaciones.DataKeys[e.RowIndex].Values["PuntuacionId"].ToString();
            string Resultado = PuntuacionesBLL.DelPuntuacion(int.Parse(PuntuacionId));
            string mensaje = "";
            string sub = "";
            string clase = "";

            switch (Resultado)
            {
                case "1":
                    mensaje = "Puntuacion eliminada con EXITO!!";
                    sub = "";
                    clase = "success";
                    break;

                case "0":
                    mensaje = "La Puntuacion NO puede ser eliminada";
                    sub = "Pregunte con nuestro soporte tecnico";
                    clase = "warning";
                    break;
            }
            Util.SweetBox(mensaje, sub, clase, this.Page, this.GetType());
            RefrescarGrid();
        }

        protected void GVPuntuacion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Aqui redireccionar al formulario de editar
            if (e.CommandName == "Select")
            {
                // Recuperando indice del comando que lo ejecuto
                int puntuacionId = int.Parse(e.CommandArgument.ToString());
                // obtener la cadena del comando que lo detono
                string puntuacionIdParaEnviar = GVPuntuaciones.DataKeys[puntuacionId].Values["PuntuacionId"].ToString();
                // completamos la url concatenando con el chofer id para enviar
                Response.Redirect("EditarPuntuacion.aspx?Id=" + puntuacionIdParaEnviar);
            }

        }

        protected void GVPuntuaciones_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Get index de la tupla a editar
            GVPuntuaciones.EditIndex = e.NewEditIndex;
            RefrescarGrid();
        }

        protected void GVPuntuaciones_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string puntuacionId = GVPuntuaciones.DataKeys[e.RowIndex].Values["PuntuacionId"].ToString();
            //string puntuacion = e.NewValues["Puntuacion"].ToString();

            PuntuacionVO puntuacionVO = PuntuacionesBLL.GetPuntuacionById(int.Parse(puntuacionId));
            PuntuacionesBLL.UdpPuntuacion(int.Parse(puntuacionId), puntuacionVO.PeliculaId, puntuacionVO.Plataforma, puntuacionVO.Puntuacion);
            GVPuntuaciones.EditIndex = -1;
            RefrescarGrid();
            Util.SweetBox("Correcto", "La Puntuación ha sido Actualizada con Éxito!", "success", this.Page, this.GetType());
        }

        protected void GVPuntuaciones_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Actualizar index de pantalla
            GVPuntuaciones.EditIndex = -1;
            RefrescarGrid();
        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditarPuntuacion.aspx");
        }
    }
}