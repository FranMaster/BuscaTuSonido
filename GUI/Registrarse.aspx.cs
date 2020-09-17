﻿using BE;
using BLL;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class Registrarse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sendregistrarse_Click(object sender, EventArgs e)
        {
            if(!tyc.Checked)
            {
                Response.Write("<script>alert('Debe aceptar los Términos y Condiciones')</script>");
                return;
            }

            bool Insertado = GestorCliente.Agregar(
                                       nombre.Text.Trim(),
                                       apellido.Text.Trim(),
                                       email.Text.Trim(),
                                       telefono.Text.Trim(),
                                       domEntrega.Text.Trim(),
                                       domFactura.Text.Trim(),
                                       EnvioEmails.md5(password.Text.Trim()),
                                       int.Parse(dni.Text.Trim()),
                                       username.Text.Trim());
            
            bool UserNuevo = GestorUsuario.Agregar(
                                       username.Text.Trim(),
                                       nombre.Text.Trim(),
                                       apellido.Text.Trim(),
                                       EnvioEmails.md5(password.Text.Trim()),
                                       "Activo",
                                       1,
                                       int.Parse(dni.Text.Trim()));

            bool Cliente = GestorGestionRoles.AsignarRolCliente(int.Parse(dni.Text.Trim()),8);

            if (Insertado)
            {
                EnvioEmails.EnviarMail(email.Text.Trim(),
                                     "Mail de Confirmacion",
                                     //$"<h1>Codigo de Seguridad</h1>" +
                                     //$"<p>{EnvioEmails.md5(this.password.Text.Trim())}</p>");
                                     $"Su registro se ha realizado correctamente.");

                Response.Write("<script>alert('Se ha registrado correctamente')</script>");
                
            }

            //Response.Redirect("~/Login");
        }
        protected void sendcancelar_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.close()</script>");
        }
    }
}