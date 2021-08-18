using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly SmartContext _context;
        public ProfessorController(SmartContext context)
        {
            _context = context;

        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }
        [HttpGet("GetById")]
        public IActionResult GetByName(int id)
        {
            var prof = _context.Professores.FirstOrDefault(p => p.Id == id);
            if (prof == null)
            {
                return BadRequest("Professor não encontrado!");
            }
            else
            {
                return Ok(prof);
            }
        }
        [HttpGet("GetByName")]
        public IActionResult GetByName(string name)
        {
            var prof = _context.Professores.FirstOrDefault(p => p.Nome.ToLower().Contains(name.ToLower()));
            if (prof == null)
            {
                return BadRequest("Professor não encontrado!");
            }
            else
            {
                return Ok(prof);
            }
        }
        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _context.Add(professor);
            _context.SaveChanges();
            return Ok(professor);
        }
        [HttpPut]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if (prof == null)
            {
                return BadRequest("Professor não encontrado");
            }
            else
            {
                _context.Update(professor);
                _context.SaveChanges();
                return Ok(professor);
            }
        }
        [HttpPatch]
        public IActionResult Patch(int id, Professor professor)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if (prof == null)
            {
                return BadRequest("Professor não encontrado");
            }
            else
            {
                _context.Update(professor);
                _context.SaveChanges();
                return Ok(professor);
            }
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if (prof == null)
            {
                return BadRequest("Professor não encontrado");
            }
            else
            {
                _context.Remove(prof);
                _context.SaveChanges();
                return Ok("Professor excluido com sucesso");
            }
        }
    }
}