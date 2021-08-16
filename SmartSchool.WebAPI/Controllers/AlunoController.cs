using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private IList<Aluno> _alunos;
        public AlunoController()
        {
            _alunos = new List<Aluno>();

            for (int i = 0; i <= 10; i++)
            {
                _alunos.Add(new Aluno(i, "Jessé" + i.ToString(), "Matiazzo" + i.ToString(), "94336182" + i.ToString()));
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_alunos);
        }
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null)
            {
                return BadRequest("Aluno não encontrado");
            }
            else
            {
                return Ok(aluno);
            }
        }
        [HttpGet("GetByName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = _alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));
            if (aluno == null)
            {
                return BadRequest("Aluno não encontrado");
            }
            else
            {
                return Ok(aluno);
            }
        }
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            return Ok(aluno);
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            return Ok(aluno);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}