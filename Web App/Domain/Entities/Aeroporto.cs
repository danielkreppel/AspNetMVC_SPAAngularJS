using Domain.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Aeroporto : IEntidadeDominio
    {
        public int IDAEROPORTO { get; set; }
     
        public string SIGLA { get; set; }

    }
}
