using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repository;
        public AlunoController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var dados = _repository.GetAllAlunos(true);
            return Ok(dados);
        }
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repository.GetAlunoById(id);
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
        public IActionResult GetByName(string nome)
        {
            var aluno = _repository.GetAlunoByName(nome, true);
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
            _repository.Add(aluno);
            if (_repository.SaveChanges())
            {
                return Ok(aluno);
            }
            else
            {
                return BadRequest("Aluno não cadastrado");
            }
        }
        [HttpPut()]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = _repository.GetAlunoById(id);
            if (alu == null)
            {
                return BadRequest("Aluno não encontrado");
            }
            else
            {
                _repository.Update(aluno);
                if (_repository.SaveChanges())
                {
                    return Ok(aluno);
                }
                else
                {
                    return BadRequest("Aluno não Atualizado");
                }
            }
        }
        [HttpPatch()]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alu = _repository.GetAlunoById(id);
            if (alu == null)
            {
                return BadRequest("Aluno não encontrado");
            }
            else
            {
                _repository.Update(aluno);
                if (_repository.SaveChanges())
                {
                    return Ok(aluno);
                }
                else
                {
                    return BadRequest("Aluno não Atualizado");
                }
            }
        }
        [HttpDelete()]
        public IActionResult Delete(int id)
        {
            var aluno = _repository.GetAlunoById(id);
            if (aluno == null)
            {
                return BadRequest("Aluno não encontrado");
            }
            else
            {
                _repository.Delete(aluno);
                if (_repository.SaveChanges())
                {
                    return Ok("Aluno deletado");
                }
                else
                {
                    return BadRequest("Aluno não deletado");
                }
            }
        }
    }
}