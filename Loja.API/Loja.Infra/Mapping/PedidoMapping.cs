using Loja.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loja.Infra.Mapping
{
    public class PedidoMapping : BaseEntityMapping<Pedido>
    {
        public override void Configure(EntityTypeBuilder<Pedido> builder)
        {
            base.Configure(builder);

            builder.ToTable("Pedido");

            builder.Property(x => x.Numero).IsRequired();

            builder.Property(x => x.Data).IsRequired();

            builder.Property(x => x.ClienteId).IsRequired();

            builder.Property(x => x.Valor).IsRequired();

            builder.Property(x => x.ValorTotal).IsRequired();

            builder.HasOne(x => x.Cliente)
               .WithMany(x => x.Pedidos)
               .HasForeignKey(x => x.ClienteId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.PedidoItens)
              .WithOne(x => x.Pedido)
              .HasForeignKey(x => x.PedidoId)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
