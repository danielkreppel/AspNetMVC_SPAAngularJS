using System;
using System.Collections.Generic;
using System.Web.Http;
using Newtonsoft.Json;
using Service.Contract;
using Application.AeronaveViewModels;
using System.Threading.Tasks;

namespace Site.Controllers
{
    public class AeronaveController : ApiController
    {
        private IAeronaveService _aeronaveService;

        public AeronaveController(IAeronaveService repo) 
        {
            _aeronaveService = repo;
        }

        [HttpGet]
        [Route("Api/Aeronave/Matriculas")]
        public async Task<IEnumerable<MatriculasAeronavesViewModel>> BuscarMatriculasAeronaves()
        {
            return await _aeronaveService.BuscarMatriculas();
        }
    }
}
