using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Models;

namespace Todo.Data
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Token> Tokens => Set<Token>();
        public RepositoryContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-C6GVHIEK\\SQLEXPRESS; Database=TodoToken; Integrated Security=true; TrustServerCertificate=true");
        }
    }
}
