using ApıWithToken.Domain.Repository;
using ApıWithToken.Domain.Responses;
using ApıWithToken.Domain.Services;
using ApıWithToken.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ApıWithToken.DataControl;

namespace ApıWithToken.Services
{
    public class GenericsService<T> : IGenericsService<T> where T : class
    {
        private readonly IGenericRepositories<T> genericRepositories;
        private readonly IUnitOfWork unitOfWork;

        public GenericsService(IGenericRepositories<T> genericRepositories, IUnitOfWork unitOfWork)
        {
            this.genericRepositories = genericRepositories;
            this.unitOfWork = unitOfWork;
        }

        public BaseResponse<T> Add(T entry)
        {
            try
            {
                this.genericRepositories.Add(entry);
                this.unitOfWork.Complete();
                return new BaseResponse<T>(entry);
            }
            catch (Exception ex)
            {
                return new BaseResponse<T>(ex.Message);
            }
        }

        public int CountWhere(Expression<Func<T, bool>> predicate)
        {
            return genericRepositories.CountWhere(predicate);
        }

        public BaseResponse<T> Delete(int id)
        {
            try
            {
                T entry = this.genericRepositories.GetById(id);
                if (entry != null)
                {
                    this.genericRepositories.Delete(id);
                    this.unitOfWork.Complete();
                    return new BaseResponse<T>(entry);
                }
                return new BaseResponse<T>("id sahip satır bulunamadı");
            }
            catch (Exception ex)
            {
                return new BaseResponse<T>(ex.Message);
            }
        }

        public BaseResponse<T> GetById(int id)
        {
            try
            {
                T entry = this.genericRepositories.GetById(id);
                if (entry != null)
                {
                    return new BaseResponse<T>(entry);
                }
                return new BaseResponse<T>("Id sahip ürün bulunamadı");
            }
            catch(Exception ex)
            {
                return new BaseResponse<T>(ex.Message);
            }
        }

        public BaseResponse<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> t = this.genericRepositories.GetWhere(predicate);
            if (t != null)
            {
                return new BaseResponse<IEnumerable<T>>(t);
            }
            return new BaseResponse<IEnumerable<T>>("ürün bulunamadı");
        }

        public BaseResponse<T> Update(T entry)
        {
            try
            {
                this.genericRepositories.Update(entry);
                this.unitOfWork.Complete();
                return new BaseResponse<T>(entry);
            }
            catch (Exception ex)
            {
                return new BaseResponse<T>(ex.Message);
            }
        }
    }
}

