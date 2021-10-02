using Loja.Domain.Entites.Base;
using System;

namespace Loja.Domain.Entites
{
    public class PedidoItens : Comum
    {
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}
