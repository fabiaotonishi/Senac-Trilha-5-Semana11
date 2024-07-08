using AutoMapper;
using ComexAPI.Dtos;
using ComexAPI.Models;

namespace ComexAPI.Profiles
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<CadastroProdutoDto, Produto>();            
            CreateMap<Produto, ConsultaProdutoDto>();
        }
    }
}
