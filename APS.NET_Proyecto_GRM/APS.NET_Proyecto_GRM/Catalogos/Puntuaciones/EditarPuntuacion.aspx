﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarPuntuacion.aspx.cs" Inherits="APS.NET_Proyecto_GRM.Catalogos.Puntuaciones.EditarPuntuacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%-- Encabezado de Editar --%>
    <div class="container">
        <div class="row">
            <asp:Label ID="Titulo" runat="server" CssClass="text-center modal-title"></asp:Label>
            <asp:Label ID="Subtitulo" runat="server" CssClass="text-center modal-title"></asp:Label>
            <%--<h1>Editar Puntuacion</h1>
            <h3>ID del Puntuacion: 
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </h3>--%>
        </div>
    </div>

    <%-- Formulario --%>
    <div class="row">
        <div class="col-md-2">
            <div class="form-group">
                <asp:Label ID="lblPuntuacionId" runat="server" Text=""></asp:Label><br />

                <asp:Label ID="lblPeliculaId" runat="server" Text="">Película:</asp:Label>
                <asp:DropDownList ID="ddlPeliculaId" runat="server" /><br /><br />

                <asp:Label ID="lblPlataforma" runat="server" Text="">Plataforma:</asp:Label>
                <asp:TextBox ID="txtPlataforma" runat="server" placeholder="" MaxLength="100" CssClass="form-control"></asp:TextBox>

                <asp:Label ID="lblPuntuacion" runat="server" Text="">Puntuación:</asp:Label>
                <asp:TextBox ID="txtPuntuacion" runat="server" placeholder="" MaxLength="10" CssClass="form-control"></asp:TextBox>

                <asp:Button ID="btnGuardar" CssClass="btn btn-success" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                
            </div>
        </div>
    </div>

</asp:Content>
