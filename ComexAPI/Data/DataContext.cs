using ComexAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ComexAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
    }
}
