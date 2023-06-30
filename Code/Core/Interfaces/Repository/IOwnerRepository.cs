using Core.Entities;
using Core.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repository
{
    public interface IOwnerRepository<TContext> : IBaseRepository<Owner, TContext> where TContext : DbContext, new()
    {
        Task UpdateOwner(Owner obj);
    }
}
