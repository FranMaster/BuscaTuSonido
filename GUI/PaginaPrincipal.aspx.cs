﻿using BLL;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class PaginaPrincipal : System.Web.UI.Page
    {
        private const string mensaje = "{menssage:Usted ha enviado} ";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sendSuscribirse_Click(object sender, EventArgs e)
        {
            bool Insertado = false;
            
            if(string.IsNullOrEmpty(email.Text.Trim()))
            {
                Response.Write("<script>alert('¡Debe ingresar un email!')</script>");

            }

            if (!CheckOfertas.Checked)
            {
                if (!CheckEventos.Checked)
                {
                    if(!CheckNoticias.Checked)
                    {
                        Response.Write("<script>alert('¡Debe elegir al menos una categoría!')</script>");
                    }
                }
            }



            if (CheckOfertas.Checked)
            {
                if (CheckEventos.Checked)
                {
                    if (CheckNoticias.Checked)
                    {
                        Insertado = GestorSuscripcion.Agregar(
                                       email.Text.Trim(),
                                       "",
                                       "Activo",
                                       true,
                                       true,
                                       true);
                    }
                    else
                    {
                        Insertado = GestorSuscripcion.Agregar(
                                       email.Text.Trim(),
                                       "",
                                       "Activo",
                                       true,
                                       true,
                                       false);
                    }

                }
                else if (CheckNoticias.Checked)
                {
                    Insertado = GestorSuscripcion.Agregar(
                                       email.Text.Trim(),
                                       "",
                                       "Activo",
                                       true,
                                       false,
                                       true);
                }
            }
            else if (CheckEventos.Checked)
            {
                if (CheckNoticias.Checked)
                {
                    Insertado = GestorSuscripcion.Agregar(
                               email.Text.Trim(),
                               "",
                               "Activo",
                               false,
                               true,
                               true);
                }
                else 
                {
                    Insertado = GestorSuscripcion.Agregar(
                                   email.Text.Trim(),
                                   "",
                                   "Activo",
                                   false,
                                   true,
                                   false);
                }
            }
            else if(CheckNoticias.Checked)
            {
                Insertado = GestorSuscripcion.Agregar(
                                   email.Text.Trim(),
                                   "",
                                   "Activo",
                                   false,
                                   false,
                                   true);
            }
        

            if (Insertado)
            {
                Response.Write("<script>alert('¡Suscripción realizada con éxito!')</script>");

                email.Text = "";
                CheckOfertas.Checked = false;
                CheckEventos.Checked = false;
                CheckNoticias.Checked = false;
                suscribirse.Visible = false;
                

                return;
            }

        }

        protected void opcionSuscribirse_Click(object sender, EventArgs e)
        {
            email.Visible = true;
            suscribirse.Visible = true;
            CheckOfertas.Visible = true;
            CheckEventos.Visible = true;
            CheckNoticias.Visible = true;
            desuscribirse.Visible = false;
        }

        protected void opcionDesuscribirse_Click(object sender, EventArgs e)
        {
            email.Visible = true;
            desuscribirse.Visible = true;
            motivo.Visible = true;
            suscribirse.Visible = false;
        }

        protected void sendDesuscribirse_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(motivo.Text.Trim()))
            {
                Response.Write("<script>alert('¡Debe ingresar un motivo!')</script>");
            }

            if (string.IsNullOrEmpty(email.Text.Trim()))
            {
                Response.Write("<script>alert('¡Debe ingresar un email!')</script>");
            }

            bool Eliminado = GestorSuscripcion.Eliminar(email.Text.Trim(), motivo.Text.Trim());

            if (Eliminado)
            {
                Response.Write("<script>alert('¡Su suscripción se ha cancelado correctamente!')</script>");
                email.Visible = false;
                desuscribirse.Visible = false;
                motivo.Visible = false;
                suscribirse.Visible = false;
            }

        }

        public void CheckOfertas_Clicked(object sender, EventArgs e)
        {
            

        }

        protected void CheckEventos_Clicked(object sender, EventArgs e)
        {


        }

        protected void CheckNoticias_Clicked(object sender, EventArgs e)
        {


        }



        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static EncuestaDelDia CargarEncuestaDeDia()
        {
            //cargar Encuesta del dia

      
            EncuestaDelDia encuesta = new EncuestaDelDia
            {
                titulo = "Que le gusta más los Violines o las Guitarras",
                Respuesta = new List<Respuestas>
                {
                    new Respuestas{imagen="Violin.jpg",Texto="Violines"},
                    new Respuestas{imagen="Guitarra1.png",Texto="Guitarras"},
                }
            };


            return encuesta;
        }




        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]

        public static ValoresPorcentuales Votar(string Voto)
        {

            //realizar un store que devuelva ambos valores
            return new ValoresPorcentuales { Valor1 = 80, Valor2 = 20 };
        }









    }

    public class EncuestaDelDia
    {
        public string titulo { get; set; }
        public List<Respuestas> Respuesta { get; set; }
    }



    public class Respuestas
    {
        public string Texto { get; set; }
        public string imagen { get; set; }
    }

    public class ValoresPorcentuales
    {
        public int  Valor1{ get; set; }
        public int  Valor2{ get; set; }
    }



}