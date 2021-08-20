using System;

namespace SmartSchool.WebAPI.Dtos
{
    /// <summary>
    /// Esse é o DTO para efetuar o salvamento no banco de dados
    /// </summary>
    public class AlunoRegisterDto
    {
        /// <summary>
        /// chave primaria do aluno
        /// </summary>
        /// <value></value>
        public int Id { get; set; }
        /// <summary>
        /// Matricula do aluno
        /// </summary>
        /// <value></value>
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNasc { get; set; }
        public DateTime DataIni { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public bool Ativo { get; set; } = true;
    }
}