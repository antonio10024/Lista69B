using AutoMapper;
using Lista69B.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lista69B.Application.Lista.Command.AddWatchlistCommand;

namespace Lista69B.Application.Lista.Map
{
    public class Lista69BMapper : Profile
    {
        public Lista69BMapper()
        {
            CreateMap<Lista69BRegistroEntity, DTO.RegistroLista69BDTO>();
            CreateMap<AddWatchlistCommandRequest, ListaSeguimiento>().ConstructUsing(x=>new ListaSeguimiento(x.RFC,x.RazonSocial));
            CreateMap<AddWatchlistCommandRequest, DTO.AddWatchlistDTO>();
            CreateMap<Lista69BEntity, DTO.List69BDTO>()
                .ForMember(x=>x.CreateDate,opt=>opt.MapFrom(y=>y.FechaCreacion))
                .ForMember(x=>x.RegisterCount,opt=>opt.MapFrom(y=>y.Items.Count));
        }
    }
}
