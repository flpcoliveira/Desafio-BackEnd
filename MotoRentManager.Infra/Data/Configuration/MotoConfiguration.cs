using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotoRentManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoRentManager.Infra.Data.Configuration
{
    public class MotoConfiguration : IEntityTypeConfiguration<Moto>
    {
        public void Configure(EntityTypeBuilder<Moto> builder)
        {
            builder.ToTable("MOTOS");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Identificador)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(m => m.Ano);

            builder.Property(m => m.Modelo)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(m => m.Placa)
                .IsRequired()
                .HasMaxLength(8);
        }
    }
}
