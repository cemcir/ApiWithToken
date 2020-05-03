using ApıWithToken.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApıWithToken.Domain.Services
{
    public interface IGenericsService<T> where T:class
    {
        BaseResponse<T> GetById(int id);

        BaseResponse<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);

        int CountWhere(Expression<Func<T, bool>> predicate);

        BaseResponse<T> Add(T entry);

        BaseResponse<T> Update(T entry);

        BaseResponse<T> Delete(int id);
    }
}
