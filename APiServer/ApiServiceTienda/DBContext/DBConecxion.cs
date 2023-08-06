using ApiServiceTienda.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiServiceTienda.DBContext
{
    public class DBConecxion: DbContext
    {

        public DBConecxion(DbContextOptions<DBConecxion> context) : base(context)
        {

        }

        public DbSet<Producto> Producto { get; set; }
        public DbSet<demo> Demo { get; set; }
    }
}
