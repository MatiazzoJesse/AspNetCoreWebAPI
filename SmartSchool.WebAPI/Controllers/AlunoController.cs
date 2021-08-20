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
    /// <summary>
    /// Api de Aluno
    /// </summary>    
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiversion}/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public AlunoController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        /// <summary>
        /// Método que retorna todos os alunos
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult Get()
        {
            var dados = _repository.GetAllAlunos(true);
            return Ok(_mapper.Map<IEnumerable<AlunoDto>>(dados));
        }
        /// <summary>
        /// Método que vai trazer apenas o modeto AlunoRegisterDto para teste
        /// </summary>
        /// <returns></returns>

        [HttpGet("teste")]
        public IActionResult teste()
        {
            return Ok(new AlunoRegisterDto());
        }
        /// <summary>
        /// Método para trazer um aluno pelo id
        /// </summary>
        /// <param name="id">Id do aluno</param>
        /// <returns></returns>

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
                return Ok(_mapper.Map<AlunoDto>(aluno));
            }
        }
        /// <summary>
        /// Método que retorna o Aluno através do nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
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
                return Ok(_mapper.Map<AlunoDto>(aluno));
            }
        }
        /// <summary>
        /// Método para adicionar um aluno
        /// </summary>
        /// <param name="model">modelo do aluno</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(AlunoRegisterDto model)
        {
            var aluno = _mapper.Map<Aluno>(model);
            _repository.Add(aluno);
            if (_repository.SaveChanges())
            {
                return Created($"/api/aluno/GetById/{aluno.Id}", _mapper.Map<AlunoDto>(aluno));
            }
            else
            {
                return BadRequest("Aluno não cadastrado");
            }
        }
        /// <summary>
        /// Método para alterar um aluno
        /// </summary>
        /// <param name="id">Id do aluno</param>
        /// <param name="model">Modelo do aluno</param>
        /// <returns></returns>
        [HttpPut()]
        public IActionResult Put(int id, AlunoRegisterDto model)
        {
            var aluno = _repository.GetAlunoById(id);
            if (aluno == null)
            {
                return BadRequest("Aluno não encontrado");
            }
            else
            {
                _mapper.Map(model, aluno);

                _repository.Update(aluno);
                if (_repository.SaveChanges())
                {
                    return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
                }
                else
                {
                    return BadRequest("Aluno não Atualizado");
                }
            }
        }
        [HttpPatch()]
        public IActionResult Patch(int id, AlunoRegisterDto model)
        {
            var aluno = _repository.GetAlunoById(id);
            if (aluno == null)
            {
                return BadRequest("Aluno não encontrado");
            }
            else
            {
                _mapper.Map(model, aluno);
                _repository.Update(aluno);
                if (_repository.SaveChanges())
                {
                    return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
                }
                else
                {
                    return BadRequest("Aluno não Atualizado");
                }
            }
        }
        /// <summary>
        /// Exluir um aluno
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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