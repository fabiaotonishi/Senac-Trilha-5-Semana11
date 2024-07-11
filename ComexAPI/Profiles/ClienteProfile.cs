using AutoMapper;
using ComexAPI.Dtos;
using ComexAPI.Models;

namespace ComexAPI.Profiles
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<CadastroClienteDto, Cliente>();
            CreateMap<Cliente, ConsultaClienteDto>()
                .ForMember(e => e.Endereco, r => r.MapFrom(cliente => cliente.Endereco));
        }
    }
}
