using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Base
{
    public interface IDbFactory<TContext> : IDisposable where TContext : DbContext , new()
    {
        TContext Init();
    }
}
