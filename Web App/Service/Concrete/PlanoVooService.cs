using Application.PlanoDeVooViewModels;
using Application.Extensions;
using AutoMapper;
using Data.Contract;
using Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Application.Log.Contract;

namespace Service.Concrete
{
    public class PlanoVooService : IPlanoVooService
    {
        private IPlanoVooRepository _planoVooRepo;
        private IMapper _mapper;
        private ILog _log;

        public PlanoVooService(
            IMapper mapper, 
            IPlanoVooRepository planoVooRepo,
            ILog log
            )
        {
            _mapper = mapper;
            _planoVooRepo = planoVooRepo;
            _log = log;
        }

        public async Task<IEnumerable<PlanoVooViewModel>> BuscarPlanosVoos()
        {
            try
            {
                var planosVoo = await _planoVooRepo.BuscarTodosAsync();
                return planosVoo.ProjetarViewModel<PlanoVooViewModel>(_mapper);
            }
            catch(Exception e)
            {
                _log.LogError(e);
                return null;
            }
        }

        public async Task<bool> NumeroVooCadastradoAsync(string numero)
        {
            try
            {
                return await _planoVooRepo.NumeroVooCadastradoAsync(numero);
            }
            catch(Exception e)
            {
                _log.LogError(e);
                throw;
            }
        }

        public async Task<bool> Salvar(PlanoVooViewModel model)
        {
            try
            {
                if (model.IdPlanoVoo == 0)
                    return await _planoVooRepo.InserirAsync(_mapper.Map<PlanoVoo>(model));
                else
                    return await _planoVooRepo.AtualizarAsync(_mapper.Map<PlanoVoo>(model));
            }
            catch(Exception e)
            {
                _log.LogError(e);
                return false;
            }
            
        }

        public async Task<bool> Excluir(PlanoVooViewModel model)
        {
            try
            {
                return await _planoVooRepo.RemoverAsync(_mapper.Map<PlanoVoo>(model));
            }
            catch(Exception e)
            {
                _log.LogError(e);
                return false;
            }
        }
    }
}
