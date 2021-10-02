using Loja.Domain.Entites.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Loja.Infra.Mapping
{
    public abstract class BaseEntityMapping<T> : IEntityTypeConfiguration<T> where T : Comum
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.CreatedAt).HasDefaultValueSql("getdate()");
            builder.Property(x => x.AlteredAt).HasDefaultValueSql("getdate()");
        }
    }
}
