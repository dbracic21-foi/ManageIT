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
        public virtual void Dispose()
        {
            Context.Dispose();
        }   
    }
}
