﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarAudios.aspx.cs" Inherits="APS.NET_Proyecto_GRM.Catalogos.Audios.ListarAudios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <div class="row">
            <div class="card text-bg-dark">
                <img src="/Recursos/wp-1.jpg" class="card-img" alt="...">
                <div class="card-img-overlay text-center">
                    <h1 class="card-title">Lista de Audios</h1>
                    <p class="card-text">Aquí encontrarás todos los Formatos que se usan en los DVDs.</p>
                    <p class="card-text"><small>**NOTA: Se podrá agregar y editar un formato, pero si se desea eliminar, el formato no debe estar presente en ningún DVD.</small></p>
                </div>
            </div>
        </div>

        <br />
        <asp:Button ID="Insert" runat="server" Text="Agregar Audio" ControlStyle-CssClass="btn btn-success btn-xs" ItemStyle-Width="50px" OnClick="Insert_Click" /><br /><br />

        <div class="row">            
            <asp:GridView ID="GVAudios"
                runat="server"
                CssClass="table table-bordered table-striped table-condensed text-center"
                AutoGenerateColumns="false"
                DataKeyNames="AudioId"
                OnRowDeleting="GVAudios_RowDeleting"
                OnRowCommand="GVAudios_RowCommand"
                OnRowEditing="GVAudios_RowEditing"
                OnRowUpdating="GVAudios_RowUpdating"
                OnRowCancelingEdit="GVAudios_RowCancelingEdit">

                <%-- EVENTOS --%>

                <Columns>
                    <asp:BoundField DataField="AudioId" HeaderText="ID Audio" ItemStyle-Width="50px" ReadOnly="true" HeaderStyle-BackColor="BlueViolet" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="text-center"/>
                    <asp:BoundField DataField="Formato" HeaderText="Formato" ItemStyle-Width="50px" HeaderStyle-BackColor="BlueViolet" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="text-center"/> 
                    
                    <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Botón" ShowHeader="true" Text="Editar" ControlStyle-CssClass="btn btn-warning btn-xs" HeaderStyle-BackColor="BlueViolet" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="text-center" ItemStyle-Width="25px"/>
                    <%--<asp:CommandField ButtonType="Button" HeaderText="Botón" ShowEditButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-warning btn-xs" HeaderStyle-BackColor="BlueViolet" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="text-center" ItemStyle-Width="25px"/>--%>
                    <asp:CommandField ButtonType="Button" HeaderText="Botón" ShowDeleteButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-danger btn-xs" HeaderStyle-BackColor="BlueViolet" HeaderStyle-ForeColor="White" HeaderStyle-CssClass="text-center" ItemStyle-Width="25px"/>
                </Columns>

            </asp:GridView>
        </div>
    </div>

</asp:Content>
