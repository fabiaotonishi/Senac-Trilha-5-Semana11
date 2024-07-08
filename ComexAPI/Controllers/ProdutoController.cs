using AutoMapper;
using ComexAPI.Data;
using ComexAPI.Dtos;
using ComexAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComexAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {

        private readonly ILogger<ProdutoController> _logger;
        private DataContext _dataContext;
        private IMapper _mapper;

        public ProdutoController(
            ILogger<ProdutoController> logger
            ,DataContext dataContext, 
            IMapper mapper)
        {
            _logger = logger;
            _dataContext = dataContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Read()
        {
            var produtos = _dataContext.Produtos.ToList();
            return Ok(_mapper.Map<List<ConsultaProdutoDto>>(produtos));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CadastroProdutoDto produtoDto)
        {
            if (ModelState.IsValid)
            {
                Produto produto = _mapper.Map<Produto>(produtoDto);
                _dataContext.Produtos.Add(produto);
                _dataContext.SaveChanges();
                return Ok("Produto Adicionado com sucesso!");
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CadastroProdutoDto produtoDto)
        {
            if (ModelState.IsValid)
            {
                var produto = _dataContext.Produtos.FirstOrDefault(p => p.Id == id);
                if (produto == null)
                {
                    return NotFound("Produto Não Encontrado!");
                }
                _mapper.Map(produtoDto, produto);
                _dataContext.SaveChanges();
                return Ok("Produto Atualizado com Sucesso!");
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var produto = _dataContext.Produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null)
            {
                return NotFound("Produto Não Encontrado!");
            }
            _dataContext.Produtos.Remove(produto);
            _dataContext.SaveChanges();
            return Ok("Produto Apagado com Sucesso!");
        }

    }
}
