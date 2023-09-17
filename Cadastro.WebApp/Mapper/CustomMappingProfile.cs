using AutoMapper;

namespace Cadastro.WebApp.Mapper
{
    public class CustomMappingProfile : Profile
    {
        public CustomMappingProfile()
        {
            CreateMap<Models.Cliente[], Core.Entities.Cliente[]>().ReverseMap();
            CreateMap<Core.Entities.Cliente[], Models.Cliente[]>().ReverseMap();

            //CreateMap<Cliente, CreateClienteCommand>().ReverseMap();

            //CreateMap<Logradouro, LogradouroResponse>().ReverseMap();
            //CreateMap<Logradouro, CreateLogradouroCommand>().ReverseMap();
        }
    }
}
