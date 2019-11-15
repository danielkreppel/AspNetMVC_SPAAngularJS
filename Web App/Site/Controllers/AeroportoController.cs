using System;
using System.Collections.Generic;
using System.Web.Http;
using Newtonsoft.Json;
using Service.Contract;
using Application.AeroportoViewModels;
using System.Threading.Tasks;

namespace Site.Controllers
{
    public class AeroportoController : ApiController
    {
        private IAeroportoService _aeroportoService;

        public AeroportoController(IAeroportoService repo) 
        {
            _aeroportoService = repo;
        }

        [HttpGet]
        [Route("Api/Aeroporto/BuscarTodos")]
        public async Task<IEnumerable<AeroportosViewModel>> BuscarAeroportos()
        {
            return await _aeroportoService.BuscarAeroportos();
        }
    }
}
