using AutoMapper;
using ExpenseTracker.Api.Data;
using ExpenseTracker.Api.Dtos.Category;
using ExpenseTracker.Api.Models;
using ExpenseTracker.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseTracker.Api.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _ctx;
        private readonly IMapper _mapper;

        public CategoryService(AppDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await _ctx.Categories.ToListAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetByIdAsync(Guid id)
        {
          var cat = await _ctx.Categories.FindAsync(id);
          if (cat == null)
            throw new KeyNotFoundException($"Categoria {id} não encontrada.");
            return _mapper.Map<CategoryDto>(cat);
        }

        public async Task<CategoryDto> CreateAsync(CreateCategoryDto dto)
        {
            var entity = _mapper.Map<Category>(dto);
            _ctx.Categories.Add(entity);
            await _ctx.SaveChangesAsync();
            return _mapper.Map<CategoryDto>(entity);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var cat = await _ctx.Categories.FindAsync(id);
            if (cat == null) return false;
            _ctx.Categories.Remove(cat);
            await _ctx.SaveChangesAsync();
            return true;
        }
    }
}
