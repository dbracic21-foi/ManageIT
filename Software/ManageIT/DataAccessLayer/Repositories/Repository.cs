using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public abstract class Repository<T> : IDisposable where T : class
    {
        protected ManageIT Context { get; set; }
        protected DbSet<T> Entities { get; set; }
        public Repository(ManageIT context)
        {
            Context = new ManageIT();
            Entities = Context.Set<T>();
        }
        public virtual IQueryable<T> GetAll()
        {
            var query = from x in Entities
                        select x;
            return query;
        }
        public virtual int Remove(T entity, bool saveChanges = true)
        {
            Entities.Attach(entity);
            Entities.Remove(entity);
            if (saveChanges)
            {
                return SaveChanges();
            }
            else
            {
                return 0;
            }
        }
        public virtual void Dispose()
        {
            Context.Dispose();
        }
        public virtual int SaveChanges()
        {
            return Context.SaveChanges();
        }
    }
}
