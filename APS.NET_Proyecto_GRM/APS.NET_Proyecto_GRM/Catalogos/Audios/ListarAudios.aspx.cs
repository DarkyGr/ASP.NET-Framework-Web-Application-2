using APS.NET_Proyecto_GRM.Utilidades;
using Capa_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace APS.NET_Proyecto_GRM.Catalogos.Audios
{
    public partial class ListarAudios : System.Web.UI.Page
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
            GVAudios.DataSource = AudiosBLL.GetListAudios();

            // Actualizar el contenido del Grid
            GVAudios.DataBind();
        }

        protected void GVAudios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string AudioId = GVAudios.DataKeys[e.RowIndex].Values["AudioId"].ToString();
            string Resultado = AudiosBLL.DelAudio(int.Parse(AudioId));
            string mensaje = "";
            string sub = "";
            string clase = "";

            switch (Resultado)
            {
                case "1":
                    mensaje = "Audio eliminado con EXITO!!";
                    sub = "";
                    clase = "success";
                    break;

                case "0":
                    mensaje = "El Audio NO puede ser eliminado";
                    sub = "Pregunte con nuestro soporte tecnico";
                    clase = "warning";
                    break;
            }
            Util.SweetBox(mensaje, sub, clase, this.Page, this.GetType());
            RefrescarGrid();
        }

        protected void GVAudios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Aqui redireccionar al formulario de editar
            if (e.CommandName == "Select")
            {
                // Recuperando indice del comando que lo ejecuto
                int audioId = int.Parse(e.CommandArgument.ToString());
                // obtener la cadena del comando que lo detono
                string audioIdParaEnviar = GVAudios.DataKeys[audioId].Values["AudioId"].ToString();
                // completamos la url concatenando con el chofer id para enviar
                Response.Redirect("EditarAudio.aspx?Id=" + audioIdParaEnviar);
            }

        }

        protected void GVAudios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Get index de la tupla a editar
            GVAudios.EditIndex = e.NewEditIndex;
            RefrescarGrid();
        }

        protected void GVAudios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string audioId = GVAudios.DataKeys[e.RowIndex].Values["AudioId"].ToString();
            string formato = e.NewValues["Formato"].ToString();            

            AudioVO audioVO = AudiosBLL.GetAudioById(int.Parse(audioId));
            AudiosBLL.UdpAudio(int.Parse(audioId), formato);
            GVAudios.EditIndex = -1;
            RefrescarGrid();
            Util.SweetBox("Correcto", "El Audio ha sido Actualizado con Éxito!", "success", this.Page, this.GetType());
        }

        protected void GVAudios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Actualizar index de pantalla
            GVAudios.EditIndex = -1;
            RefrescarGrid();
        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditarAudio.aspx");
        }
    }
}