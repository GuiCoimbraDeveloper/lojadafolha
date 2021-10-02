using System;
using System.Collections.Generic;

namespace Loja.Domain.Entites.Request.Pedido
{
    public class AddPedido
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int ClienteId { get; set; }
        public decimal Valor { get; set; }
        public decimal? Desconto { get; set; }
        public decimal ValorTotal { get; set; }
        public List<AddItens> PedidoItens { get; set; }
    }
}
