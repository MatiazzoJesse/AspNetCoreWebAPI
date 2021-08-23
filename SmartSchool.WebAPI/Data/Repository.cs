using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Helpers;
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

        public async Task<PageList<Aluno>> GetAllAlunosAsync(PageParams pageParams, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;
            if (includeProfessor)
            {
                query = query.Include(a => a.AlunoDisciplinas)
                .ThenInclude(ad => ad.Disciplina)
                .ThenInclude(d => d.Professor);
            }

            if (pageParams.aluno != null)
            {

                if (!string.IsNullOrEmpty(pageParams.aluno.Nome))
                {
                    query = query.Where(a => a.Nome.ToUpper().Contains(pageParams.aluno.Nome.ToUpper()));
                }

                if (!string.IsNullOrEmpty(pageParams.aluno.Sobrenome))
                {
                    query = query.Where(a => a.Sobrenome.ToUpper().Contains(pageParams.aluno.Sobrenome.ToUpper()));
                }

                if (pageParams.aluno.Matricula > 0)
                {
                    query = query.Where(a => a.Matricula == pageParams.aluno.Matricula);
                }
                query = query.Where(a => a.Ativo == pageParams.aluno.Ativo);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id);
            // return await query.ToArrayAsync();
            return await PageList<Aluno>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }

        public async Task<Aluno[]> GetAllAlunosbyDisciplinasIdAsync(int disciplinaId, bool includeProfessor = false)
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
            return await query.ToArrayAsync();
        }

        public async Task<Aluno> GetAlunoByIdAsync(int alunoId, bool includeProfessor = false)
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
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Aluno> GetAlunoByNameAsync(string name, bool includeprofessor)
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
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Professor[]> GetAllProfessoresAsync(bool includeAlunos = false)
        {
            IQueryable<Professor> query = _context.Professores;
            if (includeAlunos)
            {
                query = query.Include(p => p.Disciplinas)
                .ThenInclude(d => d.AlunoDisciplinas)
                .ThenInclude(ad => ad.Aluno);
            }
            query = query.AsNoTracking().OrderBy(p => p.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Professor[]> GetAllProfessoresbyAlunoIdAsync(int disciplinaId, bool includeAlunos = false)
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
            return await query.ToArrayAsync();
        }

        public async Task<Professor> GetProfessorByIdAsync(int idProfessor, bool includeAlunos = false)
        {
            IQueryable<Professor> query = _context.Professores;
            if (includeAlunos)
            {
                query.Include(p => p.Disciplinas)
                .ThenInclude(d => d.AlunoDisciplinas)
                .ThenInclude(ad => ad.Aluno);
            }
            query = query.AsNoTracking().Where(p => p.Id == idProfessor);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Professor> GetProfessorByNameAsync(string name, bool includeAlunos)
        {
            IQueryable<Professor> query = _context.Professores;
            if (includeAlunos)
            {
                query = query.Include(p => p.Disciplinas)
                .ThenInclude(d => d.AlunoDisciplinas)
                .ThenInclude(ad => ad.Aluno);
            }
            query = query.AsNoTracking().Where(p => p.Nome.ToLower().Contains(name.ToLower()));
            return await query.FirstOrDefaultAsync();
        }
    }
}