﻿using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class NotasPedidoAFacturar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var listaDatos = CargarDatos();
            this.gvNotasPedido.DataSource = listaDatos;
            this.gvNotasPedido.DataBind();
        }

        protected void btnFacturar_Click(object sender, EventArgs e)
        {
            //Generar factura (crear registro en tabla Factura) 
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            string Descripcion = row.Cells[0].Text.Trim();
            int Cantidad = int.Parse(row.Cells[1].Text.Trim());
            string PrecioTotal = row.Cells[2].Text.Trim();
            int CodCliente = int.Parse(row.Cells[3].Text.Trim());
            int NroPedido = int.Parse(row.Cells[4].Text.Trim());

            bool Facturado = GestorFactura.Agregar(Descripcion, Cantidad, PrecioTotal, CodCliente, NroPedido);

            if (Facturado)
            {
                GestorNP.ModificarEstado(NroPedido, "Facturado");

                Response.Write("<script>alert('La factura se ha generado correctamente')</script>");
            }
            
        }

        public DataSet CargarDatos()
        {
            return GestorNP.ListarNotasPedidoSinFacturar();
        }
    }
}