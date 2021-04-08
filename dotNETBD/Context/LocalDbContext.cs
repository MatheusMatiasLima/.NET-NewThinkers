using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNETBD.Entities;
using Microsoft.EntityFrameworkCore;


namespace dotNETBD.Context
{
    public class LocalDbContext : DbContext
    {
        public LocalDbContext (DbContextOptions<LocalDbContext> opt) : base (opt)
        {

        }

        public DbSet<Pessoa> pessoas { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            //para relacoes 
        }

    }
}
