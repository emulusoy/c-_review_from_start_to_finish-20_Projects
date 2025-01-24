using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Different20P_4_EntityFramework_CodeFirst.DAL.Entities;

namespace Different20P_4_EntityFramework_CodeFirst.DAL.Context
{
    public class MovieContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
