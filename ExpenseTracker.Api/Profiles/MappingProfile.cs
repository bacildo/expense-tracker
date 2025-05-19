using AutoMapper;
using ExpenseTracker.Api.Models;
using ExpenseTracker.Api.Dtos.Category;

namespace ExpenseTracker.Api.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CreateCategoryDto, Category>();
            // quando criar Transaction, faça o mesmo aqui…
        }
    }
}
