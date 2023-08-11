using APS.NET_Proyecto_GRM.Utilidades;
using Capa_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace APS.NET_Proyecto_GRM.Catalogos.Dvds
{
    public partial class ListarDvds : System.Web.UI.Page
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
            GVDvds.DataSource = DvdsBLL.GetListDvds();

            // Actualizar el contenido del Grid
            GVDvds.DataBind();
        }

        protected void GVDvds_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string DvdId = GVDvds.DataKeys[e.RowIndex].Values["DvdId"].ToString();
            string Resultado = DvdsBLL.DelDvd(int.Parse(DvdId));
            string mensaje = "";
            string sub = "";
            string clase = "";

            switch (Resultado)
            {
                case "1":
                    mensaje = "DVD eliminado con EXITO!!";
                    sub = "";
                    clase = "success";
                    break;

                case "0":
                    mensaje = "El DVD NO puede ser eliminado";
                    sub = "Pregunte con nuestro soporte tecnico";
                    clase = "warning";
                    break;
            }
            Util.SweetBox(mensaje, sub, clase, this.Page, this.GetType());
            RefrescarGrid();
        }

        protected void GVDvds_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Aqui redireccionar al formulario de editar
            if (e.CommandName == "Select")
            {
                // Recuperando indice del comando que lo ejecuto
                int dvdId = int.Parse(e.CommandArgument.ToString());
                // obtener la cadena del comando que lo detono
                string dvdIdParaEnviar = GVDvds.DataKeys[dvdId].Values["DvdId"].ToString();
                // completamos la url concatenando con el chofer id para enviar
                Response.Redirect("EditarDvd.aspx?Id=" + dvdIdParaEnviar);
            }

        }

        protected void GVDvds_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Get index de la tupla a editar
            GVDvds.EditIndex = e.NewEditIndex;
            RefrescarGrid();
        }

        protected void GVDvds_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string dvdId = GVDvds.DataKeys[e.RowIndex].Values["DvdId"].ToString();
            string region = e.NewValues["Region"].ToString();
            string fechaSalida = e.NewValues["FechaSalida"].ToString();

            DvdVO dvdVO = DvdsBLL.GetDvdById(int.Parse(dvdId));
            DvdsBLL.UdpDvd(int.Parse(dvdId), dvdVO.PeliculaId, dvdVO.LenguajeId, dvdVO.AudioId, dvdVO.Isbn, dvdVO.Edicion, dvdVO.FormatoPantalla, region, DateTime.Parse(fechaSalida), dvdVO.UrlFoto);
            GVDvds.EditIndex = -1;
            RefrescarGrid();
            Util.SweetBox("Correcto", "El DVD ha sido Actualizado con Éxito!", "success", this.Page, this.GetType());
        }

        protected void GVDvds_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Actualizar index de pantalla
            GVDvds.EditIndex = -1;
            RefrescarGrid();
        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditarDvd.aspx");
        }
    }
}