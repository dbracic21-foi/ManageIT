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
        protected ManageITModel Context { get; set; }
        protected DbSet<T> Entities { get; set; }
        public Repository(ManageITModel context)
        {
            Context = new ManageITModel();
            Entities = Context.Set<T>();
        }
        public virtual IQueryable<T> GetAll()
        {
            var query = from x in Entities
                        select x;
            return query;
        }
        public virtual void Dispose()
        {
            Context.Dispose();
        }

        public virtual int Add(T entity, bool saveChanges = true) {
            Entities.Add(entity);
            if (saveChanges) {
                return SaveChanges();
            } else {
                return 0;
            }
        }

        public virtual int SaveChanges() {
            return Context.SaveChanges();
        }
    }
}

