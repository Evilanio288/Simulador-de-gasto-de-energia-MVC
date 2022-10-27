using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APISolar.Models;

namespace APISolar.Data
{
    public class APISolarContext : DbContext
    {
        public APISolarContext (DbContextOptions<APISolarContext> options)
            : base(options)
        {
        }

        public DbSet<APISolar.Models.LocalidadeModel> LocalidadeModel { get; set; } = default!;
    }
}
