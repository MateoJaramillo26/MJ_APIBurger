using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MJ_APIBurger.Data.Models;

namespace MJ_APIBurger.Data
{
    public class MJ_APIBurgerContext : DbContext
    {
        public MJ_APIBurgerContext (DbContextOptions<MJ_APIBurgerContext> options)
            : base(options)
        {
        }

        public DbSet<MJ_APIBurger.Data.Models.MJBurger> Burger { get; set; } = default!;
        public DbSet<MJPromo> Promos { get; set; }
    }
}
