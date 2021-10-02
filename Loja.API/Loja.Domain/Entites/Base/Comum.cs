using System;

namespace Loja.Domain.Entites.Base
{
    public class Comum
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? AlteredAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
