using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args) 
        {
            // Usado para criar migrações com o banco 
            var connectionString = "User Id=TESTE;Password=teste;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XEPDB1)))";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseOracle(connectionString);
            return new MyContext(optionsBuilder.Options);
        }
    }
}
