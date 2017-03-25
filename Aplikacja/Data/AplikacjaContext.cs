using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Aplikacja.Models
{
    public class AplikacjaContext : DbContext
    {
        public AplikacjaContext (DbContextOptions<AplikacjaContext> options)
            : base(options)
        {
        }

        public DbSet<Aplikacja.Models.IPinfo> IPinfo { get; set; }
    }
}
