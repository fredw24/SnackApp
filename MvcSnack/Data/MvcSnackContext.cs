using Microsoft.EntityFrameworkCore;
using MvcSnack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MvcSnack.Data
{
    public class MvcSnackContext : DbContext
    {
        public MvcSnackContext(DbContextOptions<MvcSnackContext> options) : base(options)
        {
        }

        public DbSet<Snack> Snack { get; set; }
    }
}
