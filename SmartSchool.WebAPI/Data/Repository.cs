using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public class Repository : IRepository
    {
        private readonly SmartContext _context;
        public Repository(SmartContext context)
        {
            _context = context;

        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public Aluno[] GetAllAlunos(bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;
            if (includeProfessor)
            {
                query = query.Include(a => a.AlunoDisciplinas)
                .ThenInclude(ad => ad.Disciplina)
                .ThenInclude(d => d.Professor);
            }
            query = query.AsNoTracking().OrderBy(a => a.Id);
            return query.ToArray();
        }

        public Aluno[] GetAllAlunosbyDisciplinasId(int disciplinaId, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;
            if (includeProfessor)
            {
                query = query.Include(a => a.AlunoDisciplinas)
                .ThenInclude(ad => ad.Disciplina)
                .ThenInclude(d => d.Professor);
            }
            query = query.AsNoTracking().OrderBy(a => a.Id)
            .Where(a => a.AlunoDisciplinas.Any(d => d.DisciplinaId == disciplinaId));
            return query.ToArray();
        }

        public Aluno GetAlunoById(int alunoId, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;
            if (includeProfessor)
            {
                query = query.Include(a => a.AlunoDisciplinas)
                .ThenInclude(ad => ad.Disciplina)
                .ThenInclude(d => d.Professor);
            }
            query = query.AsNoTracking()
            .Where(a => a.Id == alunoId);
            return query.FirstOrDefault();
        }

        public Aluno GetAlunoByName(string name, bool includeprofessor)
        {
            IQueryable<Aluno> query = _context.Alunos;
            if (includeprofessor)
            {
                query = query.Include(a => a.AlunoDisciplinas)
                .ThenInclude(ad => ad.Disciplina)
                .ThenInclude(d => d.Professor);
            }
            query = query.AsNoTracking()
            .Where(a => a.Nome.ToLower().Contains(name.ToLower()));
            return query.FirstOrDefault();
        }

        public Professor[] GetAllProfessores(bool includeAlunos = false)
        {
            IQueryable<Professor> query = _context.Professores;
            if (includeAlunos)
            {
                query = query.Include(p => p.Disciplinas)
                .ThenInclude(d => d.AlunoDisciplinas)
                .ThenInclude(ad => ad.Aluno);
            }
            query = query.AsNoTracking().OrderBy(p => p.Id);
            return query.ToArray();
        }

        public Professor[] GetAllProfessoresbyAlunoId(int disciplinaId, bool includeAlunos = false)
        {
            IQueryable<Professor> query = _context.Professores;
            if (includeAlunos)
            {
                query = query.Include(p => p.Disciplinas)
                .ThenInclude(d => d.AlunoDisciplinas)
                .ThenInclude(ad => ad.Aluno);
            }
            query = query.AsNoTracking()
            .OrderBy(p => p.Id)
            .Where(p => p.Disciplinas.Any(d => d.AlunoDisciplinas.Any(a => a.DisciplinaId == disciplinaId)));
            return query.ToArray();
        }

        public Professor GetProfessorById(int idProfessor, bool includeAlunos = false)
        {
            IQueryable<Professor> query = _context.Professores;
            if (includeAlunos)
            {
                query.Include(p => p.Disciplinas)
                .ThenInclude(d => d.AlunoDisciplinas)
                .ThenInclude(ad => ad.Aluno);
            }
            query = query.AsNoTracking().Where(p => p.Id == idProfessor);
            return query.FirstOrDefault();
        }

        public Professor GetProfessorByName(string name, bool includeAlunos)
        {
            IQueryable<Professor> query = _context.Professores;
            if (includeAlunos)
            {
                query = query.Include(p => p.Disciplinas)
                .ThenInclude(d => d.AlunoDisciplinas)
                .ThenInclude(ad => ad.Aluno);
            }
            query = query.AsNoTracking().Where(p => p.Nome.ToLower().Contains(name.ToLower()));
            return query.FirstOrDefault();
        }
    }
}