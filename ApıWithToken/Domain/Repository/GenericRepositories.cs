using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApıWithToken.Domain.Repository
{
    public class GenericRepositories<T> : BaseRepository, IGenericRepositories<T> where T : class
    {

        private DbSet<T> table = null;

        public GenericRepositories(ApiWithTokenDBContext context) : base(context)
        {
            //this.context = context;
            table = context.Set<T>();
        }

        public void Add(T entry)
        {
            table.Add(entry);
        }

        public int CountWhere(Expression<Func<T, bool>> predicate)
        {
            return table.Count(predicate);
        }

        public void Delete(int id)
        {
            T entry = GetById(id);
            table.Remove(entry);
        }

        public T GetById(int id)
        {
            return table.Find(id);         
        }

        public IEnumerable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return table.Where(predicate).ToList();
        }

        public void Update(T entry)
        {
            table.Update(entry);
        }

    }
}
