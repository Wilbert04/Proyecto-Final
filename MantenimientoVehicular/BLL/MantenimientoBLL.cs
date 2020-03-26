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
    public class MantenimientoBLL
    {
        public static bool Guardar(Mantenimiento mantenimiento)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.mantenimientos.Add(mantenimiento) != null)
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

        public static bool Modificar(Mantenimiento mantenimiento)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(mantenimiento).State = EntityState.Modified;
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
                var eliminar = db.mantenimientos.Find(id);
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


        //public static Mantenimiento Buscar(int id)
        //{

        //    Contexto db = new Contexto();
        //    Mantenimiento mantenimiento = new Mantenimiento();

        //    try
        //    {
        //        mantenimiento = db.mantenimientos.Find(id);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        db.Dispose();
        //    }
        //    return mantenimiento;
        //}

        public static List<Mantenimiento> GetList(Expression<Func<Mantenimiento, bool>> mantenimiento)
        {
            List<Mantenimiento> Lista = new List<Mantenimiento>();
            Contexto db = new Contexto();
            try
            {
                Lista = db.mantenimientos.Where(mantenimiento).ToList();
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
