using System;
using System.Collections.Generic;

namespace projetoProva.Models
{
    public partial class Videogame
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string? Fabricante { get; set; }
        public int? Geracao { get; set; }
        public short? Ano { get; set; }
    }
}
