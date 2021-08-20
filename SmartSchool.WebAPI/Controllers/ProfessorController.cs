using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Dtos;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiversion}/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public ProfessorController(IRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var dados = _repository.GetAllProfessores(true);
            return Ok(_mapper.Map<IEnumerable<ProfessorDto>>(dados));
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok(new ProfessorRegisterDto());
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
                return Ok(_mapper.Map<ProfessorDto>(prof));
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
                return Ok(_mapper.Map<ProfessorDto>(prof));
            }
        }
        [HttpPost]
        public IActionResult Post(ProfessorRegisterDto model)
        {
            var professor = _mapper.Map<Professor>(model);
            _repository.Add(professor);
            if (_repository.SaveChanges())
            {
                return Created($"/api/Professor/GetById?id={professor.Id}", _mapper.Map<ProfessorDto>(professor));
            }
            else
            {
                return BadRequest("Professor não cadastrado");
            }
        }
        [HttpPut]
        public IActionResult Put(int id, ProfessorRegisterDto model)
        {
            var prof = _repository.GetProfessorById(id);
            if (prof == null)
            {
                return BadRequest("Professor não encontrado");
            }
            else
            {
                _mapper.Map(model, prof);
                _repository.Update(prof);
                if (_repository.SaveChanges())
                {
                    return Created($"/api/professor/GetById?id={prof.Id}", _mapper.Map<ProfessorDto>(prof));
                }
                else
                {
                    return BadRequest("Professor não foi alterado");
                }
            }
        }
        [HttpPatch]
        public IActionResult Patch(int id, ProfessorRegisterDto model)
        {
            var prof = _repository.GetProfessorById(id);
            if (prof == null)
            {
                return BadRequest("Professor não encontrado");
            }
            else
            {
                _mapper.Map(model, prof);
                _repository.Update(prof);
                if (_repository.SaveChanges())
                {
                    return Created($"/api/professor/GetById?id={prof.Id}", _mapper.Map<ProfessorDto>(prof));
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
                if (_repository.SaveChanges())
                {
                    return Ok("Professor excluido com sucesso");
                }
                else
                {
                    return BadRequest("Professor não foi deletado");
                }
            }
        }
    }
}