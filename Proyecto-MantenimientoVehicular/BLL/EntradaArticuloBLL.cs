using Microsoft.EntityFrameworkCore;
using Proyecto_MantenimientoVehicular.DAL;
using Proyecto_MantenimientoVehicular.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Proyecto_MantenimientoVehicular.BLL
{
    
    public class EntradaArticuloBLL
    {
        public static bool Guardar(EntradaArticulos entradaArticulos)
        {
            bool paso = false;
            Contexto db = new Contexto();
            Articulos articulos = new Articulos();
          
            try
            {
                if (db.entradaArticulos.Add(entradaArticulos) != null)
                {
                   

                    //db.articulos.Find(entradaArticulos.ArticuloId).Cantidad += entradaArticulos.Cantidad;
                    paso = db.SaveChanges() > 0;

                }
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

        public static bool Modificar(EntradaArticulos entradaArticulos)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(entradaArticulos).State = EntityState.Modified;
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
                var eliminar = db.entradaArticulos.Find(id);
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


        public static EntradaArticulos Buscar(int id)
        {

            Contexto db = new Contexto();
            EntradaArticulos entradaArticulos = new EntradaArticulos();

            try
            {
                entradaArticulos = db.entradaArticulos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return entradaArticulos;
        }

        public static List<EntradaArticulos> GetList(Expression<Func<EntradaArticulos, bool>> entradaArticulos)
        {
            List<EntradaArticulos> Lista = new List<EntradaArticulos>();
            Contexto db = new Contexto();
            try
            {
                Lista = db.entradaArticulos.Where(entradaArticulos).ToList();
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
