using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Project001.Repo.ModelsDTO
{
    public class DataContext : DbContext
    {
        DbContextOptions<DbContext> options;
        public DataContext(){}
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        // Table reference / handle
        public DbSet<Person> Person { get; set; }
        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                base.OnConfiguring(optionsBuilder);
                optionsBuilder.UseSqlServer("Data Source=localHost;" +
                    "Initial Catalog=Project001;Integrated Security=True");
            }
        }



    }
}
