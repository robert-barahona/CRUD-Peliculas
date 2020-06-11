using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEU.Transactions
{
    public class PeliculaBLL
    {
        public static void Create(tblPelicula p)
        {
            using (dbpeliculasEntities db = new dbpeliculasEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.tblPelicula.Add(p);
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static tblPelicula Get(int? id)
        {
            dbpeliculasEntities db = new dbpeliculasEntities();
            return db.tblPelicula.Find(id);
        }

        public static void Update(tblPelicula pelicula)
        {
            using (dbpeliculasEntities db = new dbpeliculasEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.tblPelicula.Attach(pelicula);
                        db.Entry(pelicula).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static void Delete(int? id)
        {
            using (dbpeliculasEntities db = new dbpeliculasEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        tblPelicula pelicula = db.tblPelicula.Find(id);
                        db.Entry(pelicula).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public static List<tblPelicula> List()
        {
            dbpeliculasEntities db = new dbpeliculasEntities();
            return db.tblPelicula.ToList();
        }
    }
}
