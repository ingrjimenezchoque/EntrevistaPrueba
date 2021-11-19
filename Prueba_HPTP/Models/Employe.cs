using System;
using System.Collections.Generic;

namespace Prueba_HPTP.Models
{
    public partial class Employe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DocumentNumber { get; set; }
        public decimal? Salary { get; set; }
        public int? Age { get; set; }
        public string Profile { get; set; }
        public string Adicional1 { get; set; }
        public string Adicional2 { get; set; }
    }
}
