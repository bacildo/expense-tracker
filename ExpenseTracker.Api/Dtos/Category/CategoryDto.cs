using System;

namespace ExpenseTracker.Api.Dtos.Category
{
  public class CategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
}
