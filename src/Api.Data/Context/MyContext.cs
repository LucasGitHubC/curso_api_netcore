using Api.Data.Mapping;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    public class MyContext : DbContext
    {
        //Define uma propriedade do tipo DbSet<UserEntity>, que representa a tabela de usuários no banco de dados.
        public DbSet<UserEntity> Users { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
            //Configura a entidade UserEntity usando a classe UserMap,
            //que define detalhes específicos do mapeamento da entidade para a tabela do banco de dados
        }

    }
}
