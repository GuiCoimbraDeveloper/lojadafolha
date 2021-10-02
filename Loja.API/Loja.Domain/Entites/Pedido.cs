using Loja.Domain.Entites.Base;
using System;
using System.Collections.Generic;

namespace Loja.Domain.Entites
{
    public class Pedido : Comum
    {
        public Pedido()
        {
            PedidoItens = new List<PedidoItens>();
        }
        public int Numero { get; set; }
        public DateTime Data { get; set; }
        public int ClienteId { get; set; }
        public decimal Valor { get; set; }
        public decimal? Desconto { get; set; }
        public decimal ValorTotal { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual List<PedidoItens> PedidoItens { get; set; }
    }
}
