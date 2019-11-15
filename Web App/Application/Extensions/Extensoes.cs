using AutoMapper;
using Domain.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static class Extensoes
    {
        public static IEnumerable<TVM> ProjetarViewModel<TVM>(this IEnumerable<IEntidadeDominio> ListaDeEntidadesDominio, IMapper mapper) {

            List<TVM> model = new List<TVM>();

            foreach (var a in ListaDeEntidadesDominio)
            {
                model.Add(mapper.Map<TVM>(a));
            }

            return model;
        }

    }
}
