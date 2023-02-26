
using Microsoft.EntityFrameworkCore;


namespace WebMysql.Data
{
    public class DataContext: DbContext
    {
        protected readonly IConfiguration Configuration;
        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        

        
        public DbSet<Customer> Customers { get; set; }
    
    }
}
