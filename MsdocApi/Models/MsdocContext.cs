using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MsdocApi.Models
{
    public class MsdocContext:DbContext
    {
        public MsdocContext(DbContextOptions<MsdocContext> options):base(options)
        {    }

        public DbSet<MsdocItem> MsdocItems { get; set; }
    }
}
