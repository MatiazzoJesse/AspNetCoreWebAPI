using AutoMapper;
using SmartSchool.WebAPI.Dtos;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Helpers
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            // MAPEAMENTO ALUNO
            CreateMap<Aluno, AlunoDto>()
            .ForMember(
                dest => dest.Nome,
                opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}"))
            .ForMember(
                dest => dest.Idade,
                opt => opt.MapFrom(src => src.DataNasc.GetCurrentYear())
            ).ReverseMap();
            CreateMap<Aluno, AlunoRegisterDto>().ReverseMap();

            // MAPEAMENTO PROFESSOR
            CreateMap<Professor, ProfessorDto>()
            .ForMember(
                dest => dest.Nome,
                opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenonome}")
            ).ReverseMap();
            CreateMap<Professor, ProfessorRegisterDto>().ReverseMap();
        }
    }
}