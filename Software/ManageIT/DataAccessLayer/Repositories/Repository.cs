using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
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

     

        public virtual int Add(T entity, bool saveChanges = true) {
            Entities.Add(entity);
            if (saveChanges) {
                return SaveChanges();
            } else {
                return 0;
            }
        }

        public virtual int SaveChanges()
        {
            try
            {
                return Context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        // Log or handle each validation error
                        Console.WriteLine($"Entity: {validationErrors.Entry.Entity.GetType().Name}, Property: {validationError.PropertyName}, Error: {validationError.ErrorMessage}");
                    }
                }

                // Handle the exception as needed
                // For example, you might choose to rethrow the exception or return a specific error message.
                throw; // Rethrow the exception to maintain the original exception behavior
            }
        }

    }
}

