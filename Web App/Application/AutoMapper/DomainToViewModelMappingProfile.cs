using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using AutoMapper;
using Application.PlanoDeVooViewModels;
using Application.AeronaveViewModels;
using Application.AeroportoViewModels;

namespace Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<PlanoVoo, PlanoVooViewModel>()
            .ForMember(dest => dest.IdPlanoVoo, opts => opts.MapFrom(src => src.IDPLANOVOO))
            .ForMember(dest => dest.NumeroVoo, opts => opts.MapFrom(src => src.NUMEROVOO))
            .ForMember(dest => dest.Data, opts => opts.MapFrom(src => src.DATA))
            .ForMember(dest => dest.IdAeronave, opts => opts.MapFrom(src => src.IDAERONAVE))
            .ForMember(dest => dest.IdAeroportoOrigem, opts => opts.MapFrom(src => src.IDAEROPORTOORIGEM))
            .ForMember(dest => dest.IdAeroportoDestino, opts => opts.MapFrom(src => src.IDAEROPORTODESTINO))
            .ForMember(dest => dest.Matricula, opts => opts.MapFrom(src => src.MATRICULA))
            .ForMember(dest => dest.TipoAeronave, opts => opts.MapFrom(src => src.TIPOAERONAVE))
            .ForMember(dest => dest.Origem, opts => opts.MapFrom(src => src.ORIGEM))
            .ForMember(dest => dest.Destino, opts => opts.MapFrom(src => src.DESTINO));

            CreateMap<Aeronave, MatriculasAeronavesViewModel>()
            .ForMember(dest => dest.IdAeronave, opts => opts.MapFrom(src => src.IDAERONAVE))
            .ForMember(dest => dest.Matricula, opts => opts.MapFrom(src => src.MATRICULA))
            .ForMember(dest => dest.IdTipoAeronave, opts => opts.MapFrom(src => src.IDTIPOAERONAVE));

            CreateMap<Aeroporto, AeroportosViewModel>()
            .ForMember(dest => dest.IdAeroporto, opts => opts.MapFrom(src => src.IDAEROPORTO))
            .ForMember(dest => dest.Sigla, opts => opts.MapFrom(src => src.SIGLA));
        }
    }
}
