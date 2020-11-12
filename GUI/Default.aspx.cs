﻿using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarProductos();
            CargarMenuVertical();
            CargarComboMarca();
            CargarComboCategoria();
            
        }


        protected void CargarMenuVertical()
        {
            HtmlGenericControl DivContenedor = new HtmlGenericControl("div");

            DivContenedor.InnerHtml = $"<div>";
            int cont = 0;
            foreach (var item in GestorMenu.ObtenerMenuVertical())
            {
                if (cont == 0)
                    DivContenedor.InnerHtml += "<div clas='row'>";
                if (cont < 3)
                {
                    DivContenedor.InnerHtml += CrearMenuVertical(item.NombreMenu);
                }
                else
                {
                    DivContenedor.InnerHtml += CrearMenuVertical(item.NombreMenu) + "</div>";
                    cont = 0;
                }
                cont++;
            }
            DivContenedor.InnerHtml += "</div>";
            this.contenedorMenu.Controls.Add(DivContenedor);
        }


        protected void CargarProductos()
        {
            HtmlGenericControl DivContenedor = new HtmlGenericControl("div");

            DivContenedor.InnerHtml = $"<div>";
            int cont = 0;
            foreach (var item in GestorProducto.ObtenerCatalogo())
            {
                if (cont == 0)
                    DivContenedor.InnerHtml += "<div clas='row'>";
                if (cont < 3)
                {
                    DivContenedor.InnerHtml += CrearCardProducto(item.Nombre, item.Modelo, item.Precio.ToString(), item.Descripcion, GestorProducto.GestionImagen(item.Nombre, "sin categoria"));
                }
                else
                {
                    DivContenedor.InnerHtml += CrearCardProducto(item.Nombre, item.Modelo, item.Precio.ToString(), item.Descripcion, GestorProducto.GestionImagen(item.Nombre, "sin categoria")) + "</div>";
                    cont = 0;
                }
                cont++;
            }
            DivContenedor.InnerHtml += "</div>";
            this.contenedor.Controls.Add(DivContenedor);
        }




        public string CrearCardProducto(string NombreProducto,
                                          string Modelo,
                                          string PrecioProducto,
                                          string Descripcion,
                                          string urlImagen)
        {
            return
            $"<div class='col-md-4 col-sm-4'><div class='card'><a href='#'><img class='card-img-top' " +
            $"src='{urlImagen}' alt='' /></a><div class='card-body'><h4 class='card-title'>" +
            $"<a href='DescripcionProducto.aspx?Nombre={NombreProducto}&Modelo={Modelo}'>{NombreProducto}</a></h4><h5>${PrecioProducto}</h5><p class='card-text'>" +
            $"{Descripcion}</p></div><div class='card-footer'></div></div></div>";

        }

        public string CrearMenuVertical(string Nombre)
        {
            return
            $"<div class='list-group'><a id='{Nombre}' href='/CatalogoProductos?NombreProducto={Nombre}' class='list - group - item' >{Nombre}</a></div>";

        }

        public void CargarComboMarca()
        {
            List<Marca> lista = GestorMarca.Listar();

            listMarca.DataSource = lista;
            listMarca.DataTextField = "Nombre";
            listMarca.DataValueField = "IdMarca";
            listMarca.DataBind();


        }

        public void CargarComboCategoria()
        {
            List<Producto> lista = GestorProducto.ListarCategorias();

            listCategoria.DataSource = lista;
            listCategoria.DataTextField = "Categoria";
            listCategoria.DataValueField = "Categoria";
            listCategoria.DataBind();
        }
        
        public void Buscar_Click(object sender, EventArgs e)
        {
            var marca = listMarca.SelectedItem.ToString();
            var categ = listCategoria.SelectedItem.ToString();

            if (!string.IsNullOrEmpty(marca))
            {
                if (!string.IsNullOrEmpty(categ))
                {
                    CargarProductosBuscados(marca, categ);
                }
                //else
                //{
                //    CargarProductosPorMarca(marca);
                //}
            }
            //else if (!string.IsNullOrEmpty(categ))
            //{
            //    CargarProductosPorCategoria(categ);
            //}

        }

        protected void CargarProductosBuscados(string marca, string categoria)
        {
            HtmlGenericControl DivContenedor = new HtmlGenericControl("div");

            DivContenedor.InnerHtml = $"<div>";
            int cont = 0;
            foreach (var item in GestorProducto.ListarProductosBuscados(marca, categoria))
            {
                if (cont == 0)
                    DivContenedor.InnerHtml += "<div clas='row'>";
                if (cont < 3)
                {
                    DivContenedor.InnerHtml += CrearCardProducto(item.Nombre, item.Modelo, item.Precio.ToString(), item.Descripcion, GestorProducto.GestionImagen(item.Nombre, "sin categoria"));
                }
                else
                {
                    DivContenedor.InnerHtml += CrearCardProducto(item.Nombre, item.Modelo, item.Precio.ToString(), item.Descripcion, GestorProducto.GestionImagen(item.Nombre, "sin categoria")) + "</div>";
                    cont = 0;
                }
                cont++;
            }
            DivContenedor.InnerHtml += "</div>";
            this.contenedor.Controls.Add(DivContenedor);
        }


    }
}