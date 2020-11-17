﻿using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GestorNP
    {
        public static List<NotaPedido> Listar()
        {
            return MapperNP.ListarNotasPedido();

        }

        public static int ObtenerNP(string usuario, string total)
        {
            return MapperNP.ObtenerIdNP(usuario, total);
        }

        public static DataSet ListarNotasPedidoDS()
        {
            return MapperNP.ListarNotasPedidoDS();

        }

        public static bool Agregar(string usuario, string total)
        {
            return MapperNP.InsertarNotaPedido(usuario, total);
        }

        public static bool ModificarEstado(int Nro, string estado)
        {
            return MapperNP.ActualizarEstadoNP(Nro, estado);
        }

        public static bool Eliminar(int Nro)
        {
            return MapperNP.EliminarNotaPedido(Nro);
        }
    }
}
