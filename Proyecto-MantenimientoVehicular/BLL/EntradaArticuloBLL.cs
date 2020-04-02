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
            
          
            try
            {
                if (db.entradaArticulos.Add(entradaArticulos) != null)
                {


                    Articulos articulo = db.articulos.Find(entradaArticulos.ArticuloId) as Articulos;

                    articulo.Existencia += entradaArticulos.Cantidad;

                    paso = db.SaveChanges() > 0;
                    

                }

                db.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
           
            return paso;
        }

        public static bool Modificar(EntradaArticulos entradaArticulos)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                EntradaArticulos EntArt = BLL.EntradaArticuloBLL.Buscar(entradaArticulos.EntradaArticuloId);
                decimal resta;
                resta = entradaArticulos.Cantidad - EntArt.Cantidad;

                Articulos articulos = BLL.ArticuloBLL.Buscar(entradaArticulos.ArticuloId);
                articulos.Existencia += resta;
                BLL.ArticuloBLL.Modificar(articulos);

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
            
            bool paso = true;
            Contexto db = new Contexto();

            try
            {
                EntradaArticulos entradaArticulos = db.entradaArticulos.Find(id);

                if (entradaArticulos != null)
                {
                    Articulos articulos = BLL.ArticuloBLL.Buscar(entradaArticulos.EntradaArticuloId);
                    articulos.Existencia -= entradaArticulos.Cantidad;
                    BLL.ArticuloBLL.Modificar(articulos);

                    db.Entry(entradaArticulos).State = EntityState.Deleted;
                }

                if (db.SaveChanges() > 0)
                {
                    paso = true;
                    db.Dispose();
                }

                
                
            }
            catch (Exception)
            {
                throw;
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
