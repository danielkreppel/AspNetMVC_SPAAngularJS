using System;
using System.Collections.Generic;
using System.Web.Http;
using Newtonsoft.Json;
using Service.Contract;
using Application.PlanoDeVooViewModels;
using System.Threading.Tasks;
using Application.ViewModels;
using Application.Log.Contract;

namespace Site.Controllers
{
    public class PlanoVooController : ApiController
    {
        private IPlanoVooService _planoVooService;
        private ILog _log;

        public PlanoVooController(IPlanoVooService repo, ILog log) 
        {
            _planoVooService = repo;
            _log = log;
        }

        [HttpGet]
        [Route("Api/PlanoDeVoo/PlanosDeVoo")]
        public async Task<IEnumerable<PlanoVooViewModel>> BuscarPlanosVoo()
        {
            return await _planoVooService.BuscarPlanosVoos();
        }

        [HttpPost]
        [Route("Api/PlanoDeVoo/Salvar")]
        public async Task<JsonRetornoViewModel> SalvarPlanoVoo([FromBody]PlanoVooViewModel model)
        {
            try
            {
                if (model.IdPlanoVoo == 0 && await _planoVooService.NumeroVooCadastradoAsync(model.NumeroVoo))
                {
                    return new JsonRetornoViewModel { Erro = true, Mensagem = "Número do vôo digitado já existe." };
                }
                else if (!await _planoVooService.Salvar(model))
                {
                    return new JsonRetornoViewModel{ Erro = true };
                }

                return new JsonRetornoViewModel { Erro = false };
            }
            catch (Exception e)
            {
                _log.LogError(e);
                return new JsonRetornoViewModel { Erro = true };
            }
            
        }

        [HttpPost]
        [Route("Api/PlanoDeVoo/Excluir")]
        public async Task<JsonRetornoViewModel> ExcluirPlanoVoo([FromBody]PlanoVooViewModel model)
        {
            try
            {
                if (!await _planoVooService.Excluir(model))
                {
                    return new JsonRetornoViewModel { Erro = true };
                }
            }
            catch (Exception e)
            {
                _log.LogError(e);
                return new JsonRetornoViewModel { Erro = true };
            }
            return new JsonRetornoViewModel { Erro = false };
        }
    }
}
