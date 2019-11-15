using Domain.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TipoAeronave : IEntidadeDominio
    {
        public int IDTIPOAERONAVE { get; set; }

        public string DESCRICAO { get; set; }

    }
}
