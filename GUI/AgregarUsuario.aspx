﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Backend.Master" AutoEventWireup="true" CodeBehind="AgregarUsuario.aspx.cs" Inherits="GUI.AgregarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row justify-content-center align-items-center" style="height:100vh">
            <div class="col-4">
                <div class="row">
                     <div class="col-md-4 order-md-1 mb-4">
                        <h2>Nuevo Usuario</h2>
                        <div class="card-body">
                            <div class="form-group">
                                <label>Usuario</label>
                                <asp:TextBox runat="server" type="text" cssclass="form-control" id="username"/>
                            </div>
                            <div class="form-group">
                                <label>Contraseña</label>
                                <asp:TextBox runat="server" type="password" cssclass="form-control" id="password"/>
                            </div>
                            <div class="form-group">
                                <label>Nombre</label>
                                <asp:TextBox runat="server" type="text" cssclass="form-control" id="nombre"/>
                            </div>
                            <div class="form-group">
                                 <label>Apellido</label>
                                 <asp:TextBox runat="server" type="text" cssclass="form-control" id="apellido"/>
                            </div>
                            <div class="form-group">
                                 <label>Dni</label>
                                 <asp:TextBox runat="server" type="text" cssclass="form-control" id="dni"/>
                            </div>
                            <div class="form-group">
                                 <label>Estado</label>
                                 <asp:TextBox runat="server" type="text" cssclass="form-control" id="estado"/>
                            </div>
                            <asp:Button runat="server" content="nuevoUsuario" id="Agregar" cssclass="btn btn-primary btn-lg" Text="Agregar" OnClick="sendAgregar_Click"/>
                            <asp:Button runat="server" content="nuevoUsuario" id="cancelar" cssclass="btn btn-warning btn-lg" Text="Cancelar" OnClick="sendcancelar_Click"/>
                        </div>
                    </div>
              </div>
        </div>
    </div>
</div>
</asp:Content>
