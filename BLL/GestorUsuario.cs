﻿using BE;
using MPP;
using MPP.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GestorUsuario
    {
        public static Usuario ObtenerUsuario(string user, string pass)
        {
            var respuesta = MapperUsuario.ValidarUsuario(user, pass);
            return respuesta;
        }

        public static bool Agregar(string user, string nombre, string ape, string pass, string estado,
                                   int Ididioma, int dni)
        {
            return MapperUsuario.InsertarUsuario(user, nombre, ape, pass, estado, Ididioma, dni);
        }

        public static bool ModificarUsuario(int IdUser, string user, string nombre, string ape, string pass, string estado,
                                            int Ididioma, int dni)
        {
            return MapperUsuario.ActualizarUsuario(IdUser, user, nombre, ape, pass, estado, Ididioma, dni);
        }

        public static bool Eliminar(int IdUser)
        {
            return MapperUsuario.EliminarUsuario(IdUser);
        }

        public static DataSet Listar()
        {
            return MapperUsuario.ListarUsuarios();
        }
    }
}
