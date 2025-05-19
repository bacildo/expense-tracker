using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExpenseTracker.Api.Dtos.Category;

namespace ExpenseTracker.Api.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<CategoryDto> GetByIdAsync(Guid id);
        Task<CategoryDto> CreateAsync(CreateCategoryDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
