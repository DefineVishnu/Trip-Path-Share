using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip.Path.Share.Common.UnitOfWork
{
    public interface IUnitOfWork<TContext> where TContext : DbContext
    {
        Task<int> Commit();
    }
}
