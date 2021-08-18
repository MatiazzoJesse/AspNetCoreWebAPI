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
        private readonly SmartContext _context;
        public AlunoController(SmartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alunos);
        }
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
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
            var aluno = _context.Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));
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
            _context.Add(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }
        [HttpPut()]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (alu == null)
            {
                return BadRequest("Aluno não encontrado");
            }
            else
            {
                _context.Update(aluno);
                _context.SaveChanges();
                return Ok(aluno);
            }
        }
        [HttpPatch()]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alu = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (alu == null)
            {
                return BadRequest("Aluno não encontrado");
            }
            else
            {
                _context.Update(aluno);
                _context.SaveChanges();
                return Ok(aluno);
            }
        }
        [HttpDelete()]
        public IActionResult Delete(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null)
            {
                return BadRequest("Aluno não encontrado");
            }
            else
            {
                _context.Remove(aluno);
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}