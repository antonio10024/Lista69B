using AutoMapper;
using Lista69B.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista69B.Application.Lista.Map
{
    public class Lista69BMapper : Profile
    {
        public Lista69BMapper()
        {
            CreateMap<Lista69BRegistroEntity, DTO.RegistroLista69BDTO>();
        }
    }
}
