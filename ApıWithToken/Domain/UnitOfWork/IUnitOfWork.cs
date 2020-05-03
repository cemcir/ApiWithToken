using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApıWithToken.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
        void Complete();
    }
}
