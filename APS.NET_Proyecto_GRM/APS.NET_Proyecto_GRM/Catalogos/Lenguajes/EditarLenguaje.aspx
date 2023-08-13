﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarLenguaje.aspx.cs" Inherits="APS.NET_Proyecto_GRM.Catalogos.Lenguajes.EditarLenguaje" %>

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
                <asp:Label ID="lblLenguajeId" runat="server" Text=""></asp:Label><br />

                <asp:Label ID="lblNombre" runat="server" Text="">Nombre del Lenguaje:</asp:Label>
                <asp:TextBox ID="txtNombre" runat="server" placeholder="" MaxLength="100" CssClass="form-control"></asp:TextBox>

                <asp:Button ID="btnGuardar" CssClass="btn btn-success" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                
            </div>
        </div>
    </div>

</asp:Content>
