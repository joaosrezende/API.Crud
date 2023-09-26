using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;

namespace Infra.Configuration
{
    public class ClienteProdutoConfiguration : IEntityTypeConfiguration<ClienteProduto>
    {
        public void Configure(EntityTypeBuilder<ClienteProduto> builder)
        {
            builder.ToTable("ClienteProduto");
            builder.HasKey(cp => cp.Id);
        }
    }
}
