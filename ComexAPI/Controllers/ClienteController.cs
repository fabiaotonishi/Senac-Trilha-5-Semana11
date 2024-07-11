using AutoMapper;
using ComexAPI.Data;
using ComexAPI.Dtos;
using ComexAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComexAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private DataContext _dataContext;
        private IMapper _mapper;

        public ClienteController(
            ILogger<ClienteController> logger
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
            var cliente = _dataContext.Clientes.FirstOrDefault(en => en.Id == id);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado!");
            }
            ConsultaClienteDto clienteDto = _mapper.Map<ConsultaClienteDto>(cliente);
            return Ok(clienteDto);
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            var clientes = _dataContext.Clientes.ToList();
            return Ok(_mapper.Map<List<ConsultaClienteDto>>(clientes));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CadastroClienteDto clienteDto)
        {
            if (ModelState.IsValid)
            {
                Cliente cliente = _mapper.Map<Cliente>(clienteDto);
                _dataContext.Clientes.Add(cliente);
                _dataContext.SaveChanges();
                return Ok("Cliente adicionado com sucesso!");
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CadastroClienteDto clienteDto)
        {
            if (ModelState.IsValid)
            {
                var cliente = _dataContext.Clientes.FirstOrDefault(p => p.Id == id);
                if (cliente == null)
                {
                    return NotFound("Cliente não encontrado!");
                }
                _mapper.Map(clienteDto, cliente);
                _dataContext.Clientes.Update(cliente);
                _dataContext.SaveChanges();
                return Ok("Cliente atualizado com sucesso!");
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

            var cliente = _dataContext.Clientes.FirstOrDefault(p => p.Id == id);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado!");
            }
            _dataContext.Clientes.Remove(cliente);
            _dataContext.SaveChanges();
            return Ok("Cliente apagado com sucesso!");
        }
    }
}
