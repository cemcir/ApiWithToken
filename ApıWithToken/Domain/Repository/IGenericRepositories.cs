using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApıWithToken.Domain.Repository
{
    public interface IGenericRepositories<T> where T:class
    {
        T GetById(int id);

        IEnumerable<T> GetWhere(Expression<Func<T, bool>> predicate);

        int CountWhere(Expression<Func<T, bool>> predicate);

        void Add(T entry);

        void Update(T entry);

        void Delete(int id);
    }
}
