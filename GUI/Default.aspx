﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GUI._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Page Content -->
    <div class="container">

        <div class="row">

            <div class="col-lg-3">
                <img id="logo" class="imglogo" src="/imagenes/Portada/BuscaTuSonidoLogo.png" alt="">
                
                    <asp:Panel runat="server" ID="contenedorMenu">
                    </asp:Panel>
            </div>
            <div class="col-lg-9">

                <asp:Panel runat="server" ID="contenedor">
                </asp:Panel>

            </div>
        </div>
    </div>
    <br />
    <br />

    <footer>
        <hr />
        <div class="container-footer">
            <div class="row justify-content-left align-items-center">
                <div class="contenedor-suscripcion">

                    <div class="row">
                        <div class="body-content">
                            <div class="col-lg-6">
                            <div class="title">
                                <h4 style="color: white; font-weight: 400;">Contáctenos</h4>
                            </div>
                                <h4>Tel.: 116045-2099
                                </h4>
                                <h4>Email: info@buscatusonido.com
                                </h4>

                                <a href="TermyCond">Términos y Condiciones</a>
                            </div>

                            <div class="col-lg-6">
                                <%--<asp:Button runat="server" content="suscrib" ID="suscrib" CssClass="btn btn-link" Text="Suscribirse" OnClick="opcionSuscribirse_Click" />--%>
                                <asp:button runat="server" type="button" id="suscrib" class="btn btn-info" data-toggle="collapse" data-target="#demo" onclick="opcionSuscribirse_Click" Text="Suscribirse" />
                                <asp:button runat="server" type="button" id="desuscrib" class="btn btn-info" data-toggle="collapse" data-target="#demo" onclick="opcionDesuscribirse_Click" Text="Cancelar Suscripción" />
                                <%--<h4 style="color: white">Suscribirse al Newsletter</h4>--%>
                                <div class="form-group">
                                    <label style="font-weight: 200">Email</label>
                                    <asp:TextBox runat="server" type="text" CssClass="form-control" ID="email" Visible="false" />
                                </div>
                                <div>
                                    <asp:Button runat="server" content="suscribirse" ID="suscribirse" CssClass="btn btn-primary btn-md" Text="Confirmar" OnClick="sendSuscribirse_Click" Visible="false" />
                                    <asp:Button runat="server" content="suscribirse" ID="desuscribirse" CssClass="btn btn-primary btn-md" Text="Confirmar" OnClick="sendDesuscribirse_Click" Visible="false" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </footer>

    <!-- /.container -->

    <style>
        img {
            width: 15vw;
            height: 200px;
        }

        #logo{
            width: 20vw;
            height: 25vh;
        }

        footer{
            width:100vw !important
        }
        @media (max-width: 700px) {
            img {
                width: 50vw;
            }

            .card {
                width: 50vw;
                margin: auto;
            }
        }

        .container-footer {
            background-color: #222222;
            padding:2%;
            /*margin:auto;*/
        }

        .contenedor-suscripcion {
            width: 80%;
            margin: auto;
        }

        .body-content {
            color: #a6a6a6;
        }
    </style>

</asp:Content>
