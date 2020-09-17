﻿using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GestorCliente
    {
        public static Cliente ValidadMailCliente(string email)
        {
            return MapperCliente.ValidarEmail(email);
        }

        public static Cliente ValidadRolCliente(string user)
        {
            return MapperCliente.ValidarCliente(user);
        }

        public static bool Agregar(string nombre, string apellido, string email, string tel,
                                   string domEntrega, string domFact, string pass, int dni, string user)
        {
            return MapperCliente.InsertarCliente(nombre,apellido,email,tel,domEntrega,domFact,pass,dni,user);
        }

    }
}
