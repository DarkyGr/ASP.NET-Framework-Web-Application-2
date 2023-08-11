<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarDvds.aspx.cs" Inherits="APS.NET_Proyecto_GRM.Catalogos.Dvds.ListarDvds" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <div class="card text-bg-dark">
                <img src="/Recursos/wp-1.jpg" class="card-img" alt="...">
                <div class="card-img-overlay text-center">
                    <h1 class="card-title">Lista de DVDs</h1>
                    <p class="card-text">Aquí encontrarás todos los DVDs que se han creado.</p>
                    <p class="card-text"><small>Última acutailización hace 1 hr.</small></p>
                </div>
            </div>
        </div>

        <br />
        <asp:Button ID="Insert" runat="server" Text="Agregar DVD" ControlStyle-CssClass="btn btn-success btn-xs" ItemStyle-Width="50px" OnClick="Insert_Click" /><br /><br />

        <div class="row">
            <asp:GridView ID="GVDvds"
                runat="server"
                CssClass="table table-bordered table-striped table-condensed text-center"
                AutoGenerateColumns="false"
                DataKeyNames="DvdId"
                OnRowDeleting="GVDvds_RowDeleting"
                OnRowCommand="GVDvds_RowCommand"
                OnRowEditing="GVDvds_RowEditing"
                OnRowUpdating="GVDvds_RowUpdating"
                OnRowCancelingEdit="GVDvds_RowCancelingEdit">

                <%-- EVENTOS --%>
                <Columns>

                    <%--<asp:BoundField DataField="DvdId" HeaderText="ID Chofer" ItemStyle-Width="50px" ReadOnly="true" HeaderStyle-BackColor="BlueViolet" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="text-center"/>--%>
                    <asp:ImageField HeaderText="Imagen" ReadOnly="true" ItemStyle-Width="120px" ControlStyle-Height="120px" ControlStyle-Width="120px" DataImageUrlField="UrlFoto" HeaderStyle-BackColor="BlueViolet" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="text-center">
                    </asp:ImageField>
                    <asp:BoundField DataField="PeliculaId" HeaderText="ID Película" ItemStyle-Width="50px" ReadOnly="true" HeaderStyle-BackColor="BlueViolet" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="text-center"/>
                    <asp:BoundField DataField="LenguajeId" HeaderText="ID Lenguaje" ItemStyle-Width="50px" ReadOnly="true" HeaderStyle-BackColor="BlueViolet" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="text-center"/>
                    <asp:BoundField DataField="AudioId" HeaderText="ID Audio" ItemStyle-Width="50px" ReadOnly="true" HeaderStyle-BackColor="BlueViolet" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="text-center"/>
                    <%--<asp:BoundField DataField="Isbn" HeaderText="Isbn" ItemStyle-Width="50px" ReadOnly="true" HeaderStyle-BackColor="BlueViolet" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="text-center"/>
                    <asp:BoundField DataField="Edicion" HeaderText="Edición" ItemStyle-Width="50px" ReadOnly="true" HeaderStyle-BackColor="BlueViolet" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="text-center"/>
                    <asp:BoundField DataField="FormatoPantalla" HeaderText="Formato de Pantalla" ReadOnly="true" ItemStyle-Width="50px" HeaderStyle-BackColor="BlueViolet" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="text-center"/>--%>
                    <asp:BoundField DataField="Region" HeaderText="Región" ItemStyle-Width="50px" HeaderStyle-BackColor="BlueViolet" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="text-center"/>
                    <asp:BoundField DataField="FechaSalida" HeaderText="Fecha de Salida" ItemStyle-Width="50px" HeaderStyle-BackColor="BlueViolet" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="text-center"/>                    

                    <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Botón" ShowHeader="true" Text="Editar" ControlStyle-CssClass="btn btn-warning btn-xs" HeaderStyle-BackColor="BlueViolet" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="text-center" ItemStyle-Width="25px"/>
                    <%--<asp:CommandField ButtonType="Button" HeaderText="Botón" ShowEditButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-warning btn-xs" HeaderStyle-BackColor="BlueViolet" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="text-center" ItemStyle-Width="25px"/>--%>
                    <asp:CommandField ButtonType="Button" HeaderText="Botón" ShowDeleteButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-danger btn-xs" HeaderStyle-BackColor="BlueViolet" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="text-center" ItemStyle-Width="25px"/>
                </Columns>

            </asp:GridView>
        </div>
    </div>

</asp:Content>
