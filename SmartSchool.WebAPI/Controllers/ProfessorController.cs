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
        private readonly IRepository _repository;

        public ProfessorController(IRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var dados = _repository.GetAllProfessores(true);
            return Ok(dados);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var prof = _repository.GetProfessorById(id);
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
            var prof = _repository.GetProfessorByName(name);
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
            _repository.Add(professor);
            if (_repository.SaveChanges())
            {
                return Ok(professor);
            }
            else
            {
                return BadRequest("Professor não cadastrado");
            }
        }
        [HttpPut]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _repository.GetProfessorById(id);
            if (prof == null)
            {
                return BadRequest("Professor não encontrado");
            }
            else
            {
                _repository.Update(professor);
                if (_repository.SaveChanges())
                {
                    return Ok(professor);
                }
                else
                {
                    return BadRequest("Professor não foi alterado");
                }
            }
        }
        [HttpPatch]
        public IActionResult Patch(int id, Professor professor)
        {
            var prof = _repository.GetProfessorById(id);
            if (prof == null)
            {
                return BadRequest("Professor não encontrado");
            }
            else
            {
                _repository.Update(professor);
                if (_repository.SaveChanges())
                {
                    return Ok(professor);
                }
                else
                {
                    return BadRequest("Professor não foi alterado");
                }
            }
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var prof = _repository.GetProfessorById(id);
            if (prof == null)
            {
                return BadRequest("Professor não encontrado");
            }
            else
            {
                _repository.Delete(prof);
                if(_repository.SaveChanges()){
                return Ok("Professor excluido com sucesso");
                }
                else{
                    return BadRequest("Professor não foi deletado");
                }
            }
        }
    }
}