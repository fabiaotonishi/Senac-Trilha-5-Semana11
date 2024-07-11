﻿namespace ComexAPI.Dtos
{
    public class ConsultaClienteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Profissao { get; set; }
        public string Telefone { get; set; }
        public ConsultaClienteDto Endereco { get; set; }
    }
}
