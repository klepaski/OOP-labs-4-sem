using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace _lab11
{
    class TicketsContext : DbContext
    {
        public TicketsContext()
            : base("DbConnection")
        { }

        public DbSet<Lextury> Lexturys { get; set; }
    }
}
