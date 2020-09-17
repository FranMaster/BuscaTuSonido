﻿using BE;
using MPP;
using MPP.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GestorProducto
    {
        public static List<Producto> ObtenerCatalogo()
        {
            return MapperProducto.ListarProductosTOP();

        }

        public static bool Agregar(string upc, string nombre, string descrip, string categ, string TipoInst,
                                     int IdMarca, string modelo, string codProveedor, int IdProveedor, string color,
                                     string estado, string precio)
        {
            return MapperProducto.InsertarProducto(upc,nombre,descrip,categ,TipoInst,IdMarca,modelo,codProveedor,
                                                    IdProveedor,color,estado,precio);
        }

        public static bool Modificar(int IdProd, string upc, string nombre, string descrip, string categ, string TipoInst,
                                     int IdMarca, string modelo, string codProveedor, int IdProveedor, string color,
                                     string estado, string precio)
        {
            return MapperProducto.ActualizarProducto(IdProd, upc, nombre, descrip, categ, TipoInst, IdMarca, modelo, codProveedor,
                                                    IdProveedor, color, estado, precio);
        }

        public static bool Eliminar(int IdProd)
        {
            return MapperProducto.EliminarProducto(IdProd);
        }

        public static Producto ListarDetalleProducto(string nombre, string modelo)
        {
            return MapperProducto.ListarDetalleProducto(nombre, modelo);
        }
    }
}
