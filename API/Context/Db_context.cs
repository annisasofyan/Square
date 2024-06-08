

using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using System.Security.Principal;

namespace API.Context
{
    public class Db_context : DbContext
    {
        public Db_context(DbContextOptions<Db_context> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Square> Squares{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //tulis modelBuilder dsini guys
        }
    }
}
