using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApıWithToken.Domain.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApiWithTokenDBContext context;

        public UnitOfWork(ApiWithTokenDBContext context)
        {
            this.context = context;
        }

        public void Complete()
        {
            this.context.SaveChanges();
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
