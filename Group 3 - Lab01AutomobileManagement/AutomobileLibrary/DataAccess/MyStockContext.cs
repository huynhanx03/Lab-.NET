using Microsoft.EntityFrameworkCore;


namespace AutomobileLibrary.DataAccess
{
    public class MyStockContext : DbContext
    {
        public DbSet<Car> Cars { get; set; } // Bảng Cars trong cơ sở dữ liệu

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(local);database=MyStock;uid=sa;pwd=123456;TrustServerCertificate=True;");
        }
    }

}


