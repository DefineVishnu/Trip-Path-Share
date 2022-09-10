using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip.Path.Share.Common.UnitOfWork
{
    public class UnitOfWork<TConext> : IUnitOfWork<TConext> where TConext : DbContext
    {
        readonly TConext _conext;
        public UnitOfWork(TConext context)
        {
            _conext = context;
        }

        


        public async Task<int> Commit()
        {
          return await _conext.SaveChangesAsync();
        }
    }
}
