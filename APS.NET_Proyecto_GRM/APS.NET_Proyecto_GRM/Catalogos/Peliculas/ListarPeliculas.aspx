<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarPeliculas.aspx.cs" Inherits="APS.NET_Proyecto_GRM.Catalogos.Pelicula.ListarPeliculas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <div class="row">
            <div class="card text-bg-dark">
                <img src="/Recursos/wp-1.jpg" class="card-img" alt="...">
                <div class="card-img-overlay text-center">
                    <h1 class="card-title">Lista de Películas</h1>
                    <p class="card-text">Aquí encontrarás todas las Películas que se podrán convertir en formatos DVDs.</p>
                    <p class="card-text"><small>**NOTA: Se podrá agregar y editar una película, pero si se desea eliminar, la película no debe estar presente en ningún DVD y Puntuación.</small></p>
                </div>
            </div>
        </div>

        <br />
        <asp:Button ID="Insert" runat="server" Text="Agregar Película" ControlStyle-CssClass="btn btn-success btn-xs" ItemStyle-Width="50px" OnClick="Insert_Click" /><br /><br />

        <div class="row">            
            <asp:GridView ID="GVPeliculas"
                runat="server"
                CssClass="table table-bordered table-striped table-condensed text-center"
                AutoGenerateColumns="false"
                DataKeyNames="PeliculaId"
                OnRowDeleting="GVPeliculas_RowDeleting"
                OnRowCommand="GVPeliculas_RowCommand"
                OnRowEditing="GVPeliculas_RowEditing"
                OnRowUpdating="GVPeliculas_RowUpdating"
                OnRowCancelingEdit="GVPeliculas_RowCancelingEdit">

                <%-- EVENTOS --%>

                <Columns>
                    <asp:BoundField DataField="PeliculaId" HeaderText="ID Película" ItemStyle-Width="50px" ReadOnly="true" HeaderStyle-BackColor="BlueViolet" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="text-center"/>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" ItemStyle-Width="50px" HeaderStyle-BackColor="BlueViolet" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="text-center"/>
                    <asp:BoundField DataField="DuracionHoras" HeaderText="Duración en Horas" ItemStyle-Width="50px" HeaderStyle-BackColor="BlueViolet" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="text-center"/>
                    <asp:BoundField DataField="GeneroId" HeaderText="ID Género" ItemStyle-Width="50px" ReadOnly="true" HeaderStyle-BackColor="BlueViolet" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="text-center"/>
                    <%--<asp:BoundField DataField="FechaLanzamiento" HeaderText="Fecha de Lanzamiento" ItemStyle-Width="50px" ReadOnly="true" HeaderStyle-BackColor="BlueViolet" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="text-center"/>--%>
                    <%--<asp:BoundField DataField="Imdb" HeaderText="Imdb" ItemStyle-Width="50px" ReadOnly="true" HeaderStyle-BackColor="BlueViolet" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="text-center"/>--%>

                    <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Botón" ShowHeader="true" Text="Editar" ControlStyle-CssClass="btn btn-warning btn-xs" HeaderStyle-BackColor="BlueViolet" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="text-center" ItemStyle-Width="25px"/>
                    <%--<asp:CommandField ButtonType="Button" HeaderText="Botón" ShowEditButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-warning btn-xs" HeaderStyle-BackColor="BlueViolet" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="text-center" ItemStyle-Width="25px"/>--%>
                    <asp:CommandField ButtonType="Button" HeaderText="Botón" ShowDeleteButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-danger btn-xs" HeaderStyle-BackColor="BlueViolet" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="text-center" ItemStyle-Width="25px"/>
                </Columns>

            </asp:GridView>
        </div>
    </div>

</asp:Content>
