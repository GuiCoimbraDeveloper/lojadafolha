using Loja.Domain.Entites.Base;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Loja.Domain.Entites
{
    public class Produto : Comum
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string Foto { get; set; }
        public IFormFile File { get; set; }
        public virtual  IEnumerable<PedidoItens> PedidoItens { get; set; }

    }
}
