using Domain.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Aeronave : IEntidadeDominio
    {
        public int IDAERONAVE { get; set; }

        public string MATRICULA { get; set; }

        public int IDTIPOAERONAVE { get; set; }

    }
}
