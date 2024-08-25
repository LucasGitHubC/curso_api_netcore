using System;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("USERENTITY");  // Nome da tabela

            builder.HasKey(p => p.Id);

            builder.Property(u => u.Id)
                   .HasColumnName("ID");  // Nome da coluna 'Id' mapeada para 'ID'

            builder.HasIndex(p => p.Email)
                   .IsUnique();

            builder.Property(u => u.Name)
                   .IsRequired()
                   .HasMaxLength(60)
                   .HasColumnName("NAME");  // Nome da coluna

            builder.Property(u => u.Email)
                   .HasMaxLength(100)
                   .HasColumnName("EMAIL");  // Nome da coluna

            builder.Property(u => u.CrateAt)
                   .HasColumnName("CRATEAT");  // Nome da coluna

            builder.Property(u => u.UpdateAt)
                   .HasColumnName("UPDATEAT");  // Nome da coluna
        }
    }
}
