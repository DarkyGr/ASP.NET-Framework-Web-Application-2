<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarPuntuaciones.aspx.cs" Inherits="APS.NET_Proyecto_GRM.Catalogos.Puntuaciones.ListarPuntuaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <div class="row">
            <div class="card text-bg-dark">
                <img src="/Recursos/wp-1.jpg" class="card-img" alt="...">
                <div class="card-img-overlay text-center">
                    <h1 class="card-title">Lista de Puntuaciones</h1>
                    <p class="card-text">Aquí encontrarás todas las Puntuaciones que obtuvieron las Películas.</p>
                    <p class="card-text"><small>**NOTA: Se podrá agregar y editar una puntuación.</small></p>
                </div>
            </div>
        </div>

        <br />
        <asp:Button ID="Insert" runat="server" Text="Agregar Puntuación" ControlStyle-CssClass="btn btn-success btn-xs" ItemStyle-Width="50px" OnClick="Insert_Click" /><br /><br />

        <div class="row">
            <asp:GridView ID="GVPuntuaciones"
                runat="server"
                CssClass="table table-bordered table-striped table-condensed text-center"
                AutoGenerateColumns="false"
                DataKeyNames="PuntuacionId"
                OnRowDeleting="GVPuntuacion_RowDeleting"
                OnRowCommand="GVPuntuacion_RowCommand"
                OnRowEditing="GVPuntuaciones_RowEditing"
                OnRowUpdating="GVPuntuaciones_RowUpdating"
                OnRowCancelingEdit="GVPuntuaciones_RowCancelingEdit">

                <%-- EVENTOS --%>

                <Columns>

                    <asp:BoundField DataField="PuntuacionId" HeaderText="ID Puntuación" ItemStyle-Width="50px" ReadOnly="true" HeaderStyle-BackColor="BlueViolet" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="text-center"/>
                    <asp:BoundField DataField="PeliculaId" HeaderText="ID Película" ItemStyle-Width="50px" ReadOnly="true" HeaderStyle-BackColor="BlueViolet" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="text-center"/>
                    <asp:BoundField DataField="Plataforma" HeaderText="Plataforma" ItemStyle-Width="50px" ReadOnly="true" HeaderStyle-BackColor="BlueViolet" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="text-center"/>
                    <asp:BoundField DataField="Puntuacion" HeaderText="Puntuación" ItemStyle-Width="50px" ReadOnly="true" HeaderStyle-BackColor="BlueViolet" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="text-center"/>

                    <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Botón" ShowHeader="true" Text="Editar" ControlStyle-CssClass="btn btn-warning btn-xs" HeaderStyle-BackColor="BlueViolet" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="text-center" ItemStyle-Width="25px"/>
                    <%--<asp:CommandField ButtonType="Button" HeaderText="Botón" ShowEditButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-warning btn-xs" HeaderStyle-BackColor="BlueViolet" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="text-center" ItemStyle-Width="25px"/>--%>
                    <asp:CommandField ButtonType="Button" HeaderText="Botón" ShowDeleteButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-danger btn-xs" HeaderStyle-BackColor="BlueViolet" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="text-center" ItemStyle-Width="25px"/>
                </Columns>

            </asp:GridView>
        </div>
    </div>

</asp:Content>
