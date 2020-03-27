using Microsoft.EntityFrameworkCore;
using Proyecto_MantenimientoVehicular.DAL;
using Proyecto_MantenimientoVehicular.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Proyecto_MantenimientoVehicular.BLL
{
    public class PedidosProveedorBLL
    {
        public static bool Guardar(PedidosProveedor pedidosProveedor)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.pedidosProveedor.Add(pedidosProveedor) != null)
                    paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Modificar(PedidosProveedor pedidosProveedor)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(pedidosProveedor).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }


        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var eliminar = db.pedidosProveedor.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }


        //public static PedidosProveedores Buscar(int id)
        //{

        //    Contexto db = new Contexto();
        //    PedidosProveedores pedidosProveedores = new PedidosProveedores();

        //    try
        //    {
        //        pedidosProveedores = db.pedidosProveedores.Find(id);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        db.Dispose();
        //    }
        //    return pedidosProveedores;
        //}

        public static List<PedidosProveedor> GetList(Expression<Func<PedidosProveedor, bool>> pedidos)
        {
            List<PedidosProveedor> Lista = new List<PedidosProveedor>();
            Contexto db = new Contexto();
            try
            {
                Lista = db.pedidosProveedor.Where(pedidos).ToList();
            }

            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Lista;

        }

    }
}
