using MantenimientoVehicular.DAL;
using MantenimientoVehicular.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MantenimientoVehicular.BLL
{
    public class PedidoProveedoreBLL
    {
        public static bool Guardar(PedidosProveedores pedidosProveedores)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.pedidosProveedores.Add(pedidosProveedores) != null)
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

        public static bool Modificar(PedidosProveedores pedidosProveedores)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(pedidosProveedores).State = EntityState.Modified;
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
                var eliminar = db.pedidosProveedores.Find(id);
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

        public static List<PedidosProveedores> GetList(Expression<Func<PedidosProveedores, bool>> pedidos)
        {
            List<PedidosProveedores> Lista = new List<PedidosProveedores>();
            Contexto db = new Contexto();
            try
            {
                Lista = db.pedidosProveedores.Where(pedidos).ToList();
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
