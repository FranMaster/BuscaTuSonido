﻿using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class EditarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            string IdUsuario = Request.QueryString["IdUsuario"].ToString();
            string Usuario = Request.QueryString["Usuario"].ToString();
            string Nombre = Request.QueryString["Nombre"].ToString();
            string Apellido = Request.QueryString["Apellido"].ToString();
            string Pass = Request.QueryString["Password"].ToString();
            string Dni = Request.QueryString["Dni"].ToString();
            string Estado = Request.QueryString["Estado"].ToString();

            Id.Text = IdUsuario;
            username.Text = Usuario;
            nombre.Text = Nombre;
            apellido.Text = Apellido;
            password.Text = Pass;
            dni.Text = Dni;
            estado.Text = Estado;

        }

        protected void sendEditar_Click(object sender, EventArgs e)
        {
            bool Modificado = GestorUsuario.ModificarUsuario(
                                       int.Parse(Id.Text.Trim()),
                                       username.Text.Trim(),
                                       nombre.Text.Trim(),
                                       apellido.Text.Trim(),
                                       EnvioEmails.md5(password.Text.Trim()),
                                       estado.Text.Trim(),
                                       1,
                                       int.Parse(dni.Text.Trim()));

            if (Modificado)
            {
                GestorBitacora.Agregar(DateTime.Now, "Se edito un registro", "Admin", "Usuario");
                Response.Write("<script>alert('Los cambios se guardaron correctamente')</script>");
                return;
                //Response.Redirect("/ABMC-Usuarios");
            }
        }

            protected void sendcancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ABMC-Usuarios");
        }
    }
}