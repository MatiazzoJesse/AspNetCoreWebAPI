using System.Collections.Generic;
using System.Threading.Tasks;
using SmartSchool.WebAPI.Helpers;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        //CONSULTAS ALUNOS
        Task<PageList<Aluno>> GetAllAlunosAsync(PageParams pageParams, bool includeProfessor = false);
        Task<Aluno[]> GetAllAlunosbyDisciplinasIdAsync(int disciplinaId, bool includeProfessor = false);
        Task<Aluno> GetAlunoByIdAsync(int alunoId, bool includeProfessor = false);
        Task<Aluno> GetAlunoByNameAsync(string name, bool includeprofessor = false);

        //CONSULTAS PROFESSORES
        Task<Professor[]> GetAllProfessoresAsync(bool includeAlunos = false);
        Task<Professor[]> GetAllProfessoresbyAlunoIdAsync(int disciplinaId, bool includeAlunos = false);
        Task<Professor> GetProfessorByIdAsync(int idProfessor, bool includeAlunos = false);
        Task<Professor> GetProfessorByNameAsync(string name, bool includeAlunos = false);
    }
}