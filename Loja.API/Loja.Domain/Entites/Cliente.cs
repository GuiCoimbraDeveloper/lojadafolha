using Loja.Domain.Entites.Base;
using System.Collections.Generic;

namespace Loja.Domain.Entites
{
    public class Cliente : Comum
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Aldeia { get; set; }
        public virtual  IEnumerable<Pedido> Pedidos { get; set; }
    }
}
