using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaAutoPecas.Models
{
    public class Pecas
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public bool InStock { get; set; }
    }
}