using AutoMapper;
using ComexAPI.Data;
using ComexAPI.Dtos;
using ComexAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComexAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly ILogger<EnderecoController> _logger;
        private DataContext _dataContext;
        private IMapper _mapper;

        public EnderecoController(
            ILogger<EnderecoController> logger
            , DataContext dataContext,
            IMapper mapper)
        {
            _logger = logger;
            _dataContext = dataContext;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult Read(int id)
        {
            var endereco = _dataContext.Enderecos.FirstOrDefault(en => en.Id == id);
            if (endereco == null)
            {
                return NotFound("Endereço não encontrado!");
            }
            ConsultaEnderecoDto enderecoDto = _mapper.Map<ConsultaEnderecoDto>(endereco);
            return Ok(enderecoDto);
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            var enderecos = _dataContext.Enderecos.ToList();
            return Ok(_mapper.Map<List<ConsultaEnderecoDto>>(enderecos));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CadastroEnderecoDto enderecoDto)
        {
            if (ModelState.IsValid)
            {
                Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
                _dataContext.Enderecos.Add(endereco);
                _dataContext.SaveChanges();
                return Ok("Endereco adicionado com sucesso!");
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CadastroEnderecoDto enderecoDto)
        {
            if (ModelState.IsValid)
            {
                var endereco = _dataContext.Enderecos.FirstOrDefault(p => p.Id == id);
                if (endereco == null)
                {
                    return NotFound("Endereco não encontrado!");
                }
                _mapper.Map(enderecoDto, endereco);
                _dataContext.Enderecos.Update(endereco);
                _dataContext.SaveChanges();
                return Ok("Endereco atualizado com sucesso!");
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

            var endereco = _dataContext.Enderecos.FirstOrDefault(p => p.Id == id);
            if (endereco == null)
            {
                return NotFound("Endereco não encontrado!");
            }
            _dataContext.Enderecos.Remove(endereco);
            _dataContext.SaveChanges();
            return Ok("Endereco apagado com sucesso!");
        }
    }
}
