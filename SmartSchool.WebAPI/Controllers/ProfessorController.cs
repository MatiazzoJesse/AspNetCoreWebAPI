using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IActionResult> Get()
        {
            var dados = await _repository.GetAllProfessoresAsync(true);
            return Ok(_mapper.Map<IEnumerable<ProfessorDto>>(dados));
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok(new ProfessorRegisterDto());
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var prof = await _repository.GetProfessorByIdAsync(id);
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
        public async Task<IActionResult> GetByName(string name)
        {
            var prof = await _repository.GetProfessorByNameAsync(name);
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
        public async Task<IActionResult> Put(int id, ProfessorRegisterDto model)
        {
            var prof = await _repository.GetProfessorByIdAsync(id);
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
        public async Task<IActionResult> Patch(int id, ProfessorRegisterDto model)
        {
            var prof = await _repository.GetProfessorByIdAsync(id);
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
        public async Task<IActionResult> Delete(int id)
        {
            var prof = await _repository.GetProfessorByIdAsync(id);
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