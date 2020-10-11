﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using MPP.Helpers;

namespace MPP
{
    public class MapperProveedor
    {
        /// <summary>
        /// Retorna todos los proveedores de la Bd
        /// </summary>
        /// <returns></returns>
        public static DataSet ListarProveedores()
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                var respuesta = Conexion.GetInstance.RetornarDataReaderDeStore("ListarProveedores", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Inserta un Proveedor en Bd
        /// </summary>
        /// <param name="proveedor">Tipo Proveedor</param>
        /// <returns>Devuelve si se inserto o no</returns>
        public static bool InsertarProveedor(string codProveedor, string nombreEmpesa, string razonSocial, string dom,
                                       string email, string tel, string descrip, string cuit)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("CodProveedor", DbType.String, ParameterDirection.Input, codProveedor));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NombreEmpresa", DbType.String, ParameterDirection.Input, nombreEmpesa));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("RazonSocial", DbType.String, ParameterDirection.Input, razonSocial));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Domicilio", DbType.String, ParameterDirection.Input, dom));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Email", DbType.String, ParameterDirection.Input, email));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Telefono", DbType.String, ParameterDirection.Input, tel));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Descripcion", DbType.String, ParameterDirection.Input, descrip));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Cuit", DbType.String, ParameterDirection.Input, cuit));
                var respuesta = Conexion.GetInstance.EjecutarStore("InsertarProveedor", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }


        /// <summary>
        /// Actualiza un proveedor en Bd
        /// </summary>
        /// <param name="proveedor">Tipo proveedor</param>
        /// <returns>Devuelve si se actualiza o no</returns>
        public static bool ActualizarProveedor(int IdProveedor, string codProveedor, string nombreEmpesa, string razonSocial, string dom,
                                       string email, string tel, string descrip, string cuit)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdProveedor", DbType.Int32, ParameterDirection.Input, IdProveedor));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("CodProveedor", DbType.String, ParameterDirection.Input, codProveedor));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("NombreEmpresa", DbType.String, ParameterDirection.Input, nombreEmpesa));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("RazonSocial", DbType.String, ParameterDirection.Input, razonSocial));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Domicilio", DbType.String, ParameterDirection.Input, dom));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Email", DbType.String, ParameterDirection.Input, email));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Telefono", DbType.String, ParameterDirection.Input, tel));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Descripcion", DbType.String, ParameterDirection.Input, descrip));
                ListaParametros.Add(StoreProcedureHelper.SetParameter("Cuit", DbType.String, ParameterDirection.Input, cuit));
                var respuesta = Conexion.GetInstance.EjecutarStore("ActualizarProveedor", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Elimina un proveedor en Bd
        /// </summary>
        /// <param name="proveedor">Tipo Proveedor</param>
        /// <returns>Devuelve si se elimino o no</returns>
        public static bool EliminarProveedor(int IdProveedor)
        {
            try
            {
                List<SqlParameter> ListaParametros = new List<SqlParameter>();
                ListaParametros.Add(StoreProcedureHelper.SetParameter("IdProveedor", DbType.Int32, ParameterDirection.Input, IdProveedor));
                var respuesta = Conexion.GetInstance.EjecutarStore("EliminarProveedor", ListaParametros);

                return respuesta;
            }

            catch (Exception e)
            {
                return false;
            }
        }
    }
}
