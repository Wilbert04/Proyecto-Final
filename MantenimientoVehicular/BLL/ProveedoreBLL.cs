﻿using MantenimientoVehicular.DAL;
using MantenimientoVehicular.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MantenimientoVehicular.BLL
{
    public class ProveedoreBLL
    {
        public static bool Guardar(Proveedores proveedores)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.proveedores.Add(proveedores) != null)
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

        public static bool Modificar(Proveedores proveedores)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(proveedores).State = EntityState.Modified;
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
                var eliminar = db.proveedores.Find(id);
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


        public static Proveedores Buscar(int id)
        {

            Contexto db = new Contexto();
            Proveedores proveedores = new Proveedores();

            try
            {
                proveedores = db.proveedores.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return proveedores;
        }

        public static List<Proveedores> GetList(Expression<Func<Proveedores, bool>> proveedores)
        {
            List<Proveedores> Lista = new List<Proveedores>();
            Contexto db = new Contexto();
            try
            {
                Lista = db.proveedores.Where(proveedores).ToList();
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
