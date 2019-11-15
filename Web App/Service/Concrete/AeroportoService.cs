using Application.AeroportoViewModels;
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
    public class AeroportoService : IAeroportoService
    {
        private IAeroportosRepository _aeroportoRepo;
        private IMapper _mapper;
        private ILog _log;

        public AeroportoService(
            IMapper mapper, 
            IAeroportosRepository aeroportoRepo,
            ILog log
            )
        {
            _mapper = mapper;
            _aeroportoRepo = aeroportoRepo;
            _log = log;
        }
        
        public async Task<IEnumerable<AeroportosViewModel>> BuscarAeroportos()
        {
            try
            {
                var aeroportos = await _aeroportoRepo.BuscarTodosAsync();

                return aeroportos.ProjetarViewModel<AeroportosViewModel>(_mapper);
            }
            catch(Exception e)
            {
                _log.LogError(e);
                return null;
            }   
        }
    }
}
