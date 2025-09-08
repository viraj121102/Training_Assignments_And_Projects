using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos.Repos
{
    public interface IRepogeneric<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int? id);
        string Create(T Obj);
        string Update(T Obj);
        string Delete(T Obj);
    }

    public class Repogeneric<T> : IRepogeneric<T> where T : class
    {
        private DbSet<T> db = null;
        private readonly RepoContext _context;

        public Repogeneric(RepoContext context)
        {
            _context = context;
            db = _context.Set<T>();
        }
        public string Create(T Obj)
        {
            try
            {
                _context.Add(Obj);
                _context.SaveChanges();
                return "Record Added Successfully ";
            }
            catch (Exception ex)
            {
                return $"Error Occured {ex.Message}";

            }
        }
        public string Delete(T Obj)
        {
            //throw new NotImplementedException();
            try
            {
                _context.Remove(Obj);
                _context.SaveChanges();
                return "Record Deleted Successfully ";
            }
            catch (Exception ex)
            {
                return $"Error Occured {ex.Message}";
            }
        }
        public IEnumerable<T> GetAll()
        {
            return db.ToList(); 
        }
        public T GetById(int? id)
        {
            //throw new NotImplementedException();
            return db.Find(id);
        }
        public string Update(T Obj)
        {
            throw new NotImplementedException();
        }
    }
}
