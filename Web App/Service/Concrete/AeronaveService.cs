using Application.AeronaveViewModels;
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
    public class AeronaveService : IAeronaveService
    {
        private IAeronavesRepository _aeronaveRepo;
        private ITiposAeronavesRepository _tipoAeronaveRepo;   
        private IMapper _mapper;
        private ILog _log;

        public AeronaveService(
            IMapper mapper, 
            IAeronavesRepository aeronaveRepo,
            ITiposAeronavesRepository tipoAeronaveRepo,
            ILog log
            )
        {
            _mapper = mapper;
            _aeronaveRepo = aeronaveRepo;
            _tipoAeronaveRepo = tipoAeronaveRepo;
            _log = log;
        }

        public async Task<IEnumerable<MatriculasAeronavesViewModel>> BuscarMatriculas()
        {
            try
            {
                var aeronaves = await _aeronaveRepo.BuscarTodosAsync();
                var tiposAeronaves = await _tipoAeronaveRepo.BuscarTodosAsync();
                var model = aeronaves.ProjetarViewModel<MatriculasAeronavesViewModel>(_mapper);

                foreach(var m in model)
                {
                    m.TipoAeronave = tiposAeronaves.Where(t => t.IDTIPOAERONAVE == m.IdAeronave).FirstOrDefault()?.DESCRICAO;
                }

                return model;
            }
            catch(Exception e)
            {
                _log.LogError(e);
                return null;
            }
        }
    }
}
