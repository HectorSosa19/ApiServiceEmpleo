using ApiService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Context
{
    public class AppDbContexts : DbContext
    {
        public AppDbContexts(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Usuarios> usuario { get; set; }
    }
}

