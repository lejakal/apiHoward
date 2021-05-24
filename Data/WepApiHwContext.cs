using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WepApiHw.Models;

namespace WepApiHw.Data
{
    public class WepApiHwContext : DbContext
    {
        public WepApiHwContext (DbContextOptions<WepApiHwContext> options)
            : base(options)
        {
        }

        public DbSet<WepApiHw.Models.aspirantes> aspirantes { get; set; }
    }
}
