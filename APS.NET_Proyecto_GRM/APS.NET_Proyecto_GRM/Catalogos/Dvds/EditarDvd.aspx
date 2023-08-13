<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarDvd.aspx.cs" Inherits="APS.NET_Proyecto_GRM.Catalogos.Dvds.EditarDvd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%-- Encabezado de Editar --%>
    <div class="row">
        <div class="card text-bg-dark">
            <img src="/Recursos/wp-2.jpg" class="card-img" alt="...">
            <div class="card-img-overlay text-center">
                <h1 class="card-title"><asp:Label ID="Titulo" runat="server" CssClass="text-center modal-title"></asp:Label></h1>
                <p class="card-text fw-bold"><asp:Label ID="Subtitulo" runat="server" CssClass="text-center modal-title"></asp:Label></p>
            </div>
        </div>
    </div>

    <%-- Formulario --%>
    <div class="row">
        <div class="col-md-2">
            <div class="form-group">
                <asp:Label ID="lblDvdId" runat="server" Text=""></asp:Label><br />

                <asp:Label ID="lblPelicula" runat="server" Text="">Nombre de Película:</asp:Label>
                <asp:DropDownList ID="ddlPeliculaId" runat="server" /><br /><br />

                <asp:Label ID="lblLenguajeId" runat="server" Text="">Lenguaje:</asp:Label><br />
                <asp:DropDownList ID="ddlLenguajeId" runat="server" /><br /><br />

                <asp:Label ID="lblAudio" runat="server" Text="">Formato de Audio:</asp:Label>
                <asp:DropDownList ID="ddlAudioId" runat="server" /><br /><br />

                <asp:Label ID="lblIsbn" runat="server" Text="">Isbn:</asp:Label>
                <asp:TextBox ID="txtIsbn" runat="server" placeholder="" MaxLength="16" CssClass="form-control"></asp:TextBox>

                <asp:Label ID="lblEdicion" runat="server" Text="">Edición:</asp:Label>
                <asp:TextBox ID="txtEdicion" runat="server" placeholder="" MaxLength="32" CssClass="form-control"></asp:TextBox>

                <asp:Label ID="lblFormatoPantalla" runat="server" Text="">Formato de Pantalla:</asp:Label>
                <asp:TextBox ID="txtFormatoPantalla" runat="server" placeholder="" MaxLength="32" CssClass="form-control"></asp:TextBox>

                <asp:Label ID="lblRegion" runat="server" Text="">Región:</asp:Label>
                <asp:TextBox ID="txtRegion" runat="server" placeholder="" MaxLength="16" CssClass="form-control"></asp:TextBox>

                <asp:Label ID="lblFechaSalida" runat="server" Text="">Fecha de Lanzamiento:</asp:Label>
                <asp:TextBox ID="txtFechaSalida" runat="server" placeholder="mm/dd/aaaa" MaxLength="10" CssClass="form-control"></asp:TextBox>

                <asp:Label ID="lblImagen" runat="server">Imagen(portada):</asp:Label>
                <input type="file" id="SubeImagen" runat="server" class="btn btn-file">
                <asp:Button ID="btnSubeImagen" runat="server" CssClass="btn btn-primary" Text="Subir Imagen" OnClick="btnSubeImagen_Click"/><br /><br />

                <asp:Label ID="lblPortadaNueva" runat="server">Portada DVD:</asp:Label><br />
                <asp:Image ID="imgPortadaNueva" Width="100" Height="100" runat="server" /><br /><br />

                <asp:Image ID="imgPortadaVieja" Width="100" Height="100" runat="server" />
                <asp:Label ID="lblPortadaVieja" runat="server">Url Foto</asp:Label><br />

                <asp:Button ID="btnGuardar" CssClass="btn btn-success" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                
            </div>
        </div>
    </div>

</asp:Content>
