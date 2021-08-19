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
        Aluno[] GetAllAlunos(bool includeProfessor);
        Aluno[] GetAllAlunosbyDisciplinasId(int disciplinaId, bool includeProfessor = false);
        Aluno GetAlunoById(int alunoId, bool includeProfessor = false);
        Aluno GetAlunoByName(string name, bool includeprofessor = false);

        //CONSULTAS PROFESSORES
        Professor[] GetAllProfessores(bool includeAlunos = false);
        Professor[] GetAllProfessoresbyAlunoId(int disciplinaId, bool includeAlunos = false);
        Professor GetProfessorById(int idProfessor, bool includeAlunos = false);
        Professor GetProfessorByName(string name, bool includeAlunos = false);
    }
}