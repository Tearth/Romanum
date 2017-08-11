using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Database
{
    public interface IDatabaseContext
    {
        IDbSet<Post> Posts { get; set; }

        int SaveChanges();
    }
}
