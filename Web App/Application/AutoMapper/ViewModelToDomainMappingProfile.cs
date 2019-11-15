using Application.PlanoDeVooViewModels;
using Application.AeronaveViewModels;
using Application.AeroportoViewModels;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<PlanoVooViewModel, PlanoVoo>()
            .ForMember(dest => dest.IDPLANOVOO, opts => opts.MapFrom(src => src.IdPlanoVoo))
            .ForMember(dest => dest.NUMEROVOO, opts => opts.MapFrom(src => src.NumeroVoo))
            .ForMember(dest => dest.DATA, opts => opts.MapFrom(src => src.Data))
            .ForMember(dest => dest.IDAERONAVE, opts => opts.MapFrom(src => src.IdAeronave))
            .ForMember(dest => dest.IDAEROPORTOORIGEM, opts => opts.MapFrom(src => src.IdAeroportoOrigem))
            .ForMember(dest => dest.IDAEROPORTODESTINO, opts => opts.MapFrom(src => src.IdAeroportoDestino))
            .ForMember(dest => dest.MATRICULA, opts => opts.MapFrom(src => src.Matricula))
            .ForMember(dest => dest.TIPOAERONAVE, opts => opts.MapFrom(src => src.TipoAeronave))
            .ForMember(dest => dest.ORIGEM, opts => opts.MapFrom(src => src.Origem))
            .ForMember(dest => dest.DESTINO, opts => opts.MapFrom(src => src.Destino));
        }
    }
}
