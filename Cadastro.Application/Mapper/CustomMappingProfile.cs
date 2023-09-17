using AutoMapper;
using Cadastro.Application.Command;
using Cadastro.Application.Command.ClienteCommand;
using Cadastro.Application.Command.LogradouroCommand;
using Cadastro.Application.Response;
using Cadastro.Core.Entities;

namespace Cadastro.Application.Mapper
{
    public class CustomMappingProfile : Profile
    {
        public CustomMappingProfile()
        {
            CreateMap<Cliente, ClienteResponse>().ReverseMap();
            CreateMap<Cliente, CreateClienteCommand>().ReverseMap();
            CreateMap<Cliente, UpdateClienteCommand>().ReverseMap();


            CreateMap<Logradouro, LogradouroResponse>().ReverseMap();
            CreateMap<Logradouro, CreateLogradouroCommand>().ReverseMap();
            CreateMap<Logradouro, UpdateLogradouroCommand>().ReverseMap();

            CreateMap<Login, AuthCommand>().ReverseMap();
            CreateMap<Login, LoginResponse>().ReverseMap();


        }
    }
}

