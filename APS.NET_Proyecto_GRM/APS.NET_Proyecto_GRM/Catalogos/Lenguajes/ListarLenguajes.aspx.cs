using APS.NET_Proyecto_GRM.Utilidades;
using Capa_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace APS.NET_Proyecto_GRM.Catalogos.Lenguajes
{
    public partial class ListarLenguajes : System.Web.UI.Page
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
            GVLenguajes.DataSource = LenguajesBLL.GetListLenguajes();

            // Actualizar el contenido del Grid
            GVLenguajes.DataBind();
        }

        protected void GVLenguajes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string LenguajeId = GVLenguajes.DataKeys[e.RowIndex].Values["LenguajeId"].ToString();
            string Resultado = LenguajesBLL.DelLenguaje(int.Parse(LenguajeId));
            string mensaje = "";
            string sub = "";
            string clase = "";

            switch (Resultado)
            {
                case "1":
                    mensaje = "Lenguaje eliminado con EXITO!!";
                    sub = "";
                    clase = "success";
                    break;

                case "0":
                    mensaje = "El Lenguaje NO puede ser eliminado";
                    sub = "Pregunte con nuestro soporte tecnico";
                    clase = "warning";
                    break;
            }
            Util.SweetBox(mensaje, sub, clase, this.Page, this.GetType());
            RefrescarGrid();
        }

        protected void GVLenguajes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Aqui redireccionar al formulario de editar
            if (e.CommandName == "Select")
            {
                // Recuperando indice del comando que lo ejecuto
                int lenguajeId = int.Parse(e.CommandArgument.ToString());
                // obtener la cadena del comando que lo detono
                string lenguajeIdParaEnviar = GVLenguajes.DataKeys[lenguajeId].Values["LenguajeId"].ToString();
                // completamos la url concatenando con el chofer id para enviar
                Response.Redirect("EditarLenguaje.aspx?Id=" + lenguajeIdParaEnviar);
            }

        }

        protected void GVLenguajes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Get index de la tupla a editar
            GVLenguajes.EditIndex = e.NewEditIndex;
            RefrescarGrid();
        }

        protected void GVLenguajes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string lenguajeId = GVLenguajes.DataKeys[e.RowIndex].Values["LenguajeId"].ToString();
            string nombre = e.NewValues["Nombre"].ToString();

            LenguajeVO lenguajeVO = LenguajesBLL.GetLenguajeById(int.Parse(lenguajeId));
            LenguajesBLL.UdpLenguaje(int.Parse(lenguajeId), nombre);
            GVLenguajes.EditIndex = -1;
            RefrescarGrid();
            Util.SweetBox("Correcto", "El Lenguaje ha sido Actualizado con Éxito!", "success", this.Page, this.GetType());
        }

        protected void GVLenguajes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Actualizar index de pantalla
            GVLenguajes.EditIndex = -1;
            RefrescarGrid();
        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditarLenguaje.aspx");
        }
    }
}