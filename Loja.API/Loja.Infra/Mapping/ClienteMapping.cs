using Loja.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loja.Infra.Mapping
{
    public class ClienteMapping : BaseEntityMapping<Cliente>
    {
        public override void Configure(EntityTypeBuilder<Cliente> builder)
        {
            base.Configure(builder);

            builder.ToTable("Cliente");

            builder.Property(x => x.Nome).IsRequired();
            
            builder.Property(x => x.Email).IsRequired();
            builder.HasIndex(u => u.Email) .IsUnique();
            
            builder.Property(x => x.Aldeia).IsRequired();

        }
    }
}
