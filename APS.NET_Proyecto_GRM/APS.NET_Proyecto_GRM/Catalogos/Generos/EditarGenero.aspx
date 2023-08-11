﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarGenero.aspx.cs" Inherits="APS.NET_Proyecto_GRM.Catalogos.Generos.EditarGenero" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%-- Encabezado de Editar --%>
    <div class="container">
        <div class="row">
            <asp:Label ID="Titulo" runat="server" CssClass="text-center modal-title"></asp:Label>
            <asp:Label ID="Subtitulo" runat="server" CssClass="text-center modal-title"></asp:Label>
            <%--<h1>Editar Genero</h1>
            <h3>ID del Genero: 
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </h3>--%>
        </div>
    </div>

    <%-- Formulario --%>
    <div class="row">
        <div class="col-md-2">
            <div class="form-group">
                <asp:Label ID="lblGeneroId" runat="server" Text=""></asp:Label><br />

                <asp:Label ID="lblNombre" runat="server" Text="">Nombre del Género:</asp:Label>
                <asp:TextBox ID="txtNombre" runat="server" placeholder="" MaxLength="50" CssClass="form-control"></asp:TextBox>                

                <asp:Button ID="btnGuardar" CssClass="btn btn-success" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                
            </div>
        </div>
    </div>

</asp:Content>