using Loja.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loja.Infra.Mapping
{
    public class ProdutoMapping : BaseEntityMapping<Produto>
    {
        public override void Configure(EntityTypeBuilder<Produto> builder)
        {
            base.Configure(builder);

            builder.ToTable("Produto");

            builder.Property(x => x.Descricao).IsRequired();

            builder.Property(x => x.Valor).IsRequired();

            builder.Ignore(c => c.File);

        }
    }
}
