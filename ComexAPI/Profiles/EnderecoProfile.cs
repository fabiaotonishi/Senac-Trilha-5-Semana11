using AutoMapper;
using ComexAPI.Dtos;
using ComexAPI.Models;

namespace ComexAPI.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CadastroEnderecoDto, Endereco>();
            CreateMap<Endereco, ConsultaEnderecoDto>();
        }
    }
}
