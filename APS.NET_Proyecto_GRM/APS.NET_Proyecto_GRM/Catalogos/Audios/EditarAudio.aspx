<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarAudio.aspx.cs" Inherits="APS.NET_Proyecto_GRM.Catalogos.Audios.EditarAudio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%-- Encabezado de Editar --%>
    <div class="container">
        <div class="row">
            <asp:Label ID="Titulo" runat="server" CssClass="text-center modal-title"></asp:Label>
            <asp:Label ID="Subtitulo" runat="server" CssClass="text-center modal-title"></asp:Label>

            <%--<h1>Editar Audio</h1>
            <h3>ID del Audio: 
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </h3>--%>
        </div>
    </div>

    <%-- Formulario --%>
    <div class="row">
        <div class="col-md-2">
            <div class="form-group">
                <asp:Label ID="lblAudioId" runat="server" Text=""></asp:Label><br />

                <asp:Label ID="lblFormato" runat="server" Text="">Formato de Audio:</asp:Label>
                <asp:TextBox ID="txtFormato" runat="server" placeholder="" MaxLength="20" CssClass="form-control"></asp:TextBox>                

                <asp:Button ID="btnGuardar" CssClass="btn btn-success" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                
            </div>
        </div>
    </div>

</asp:Content>
