using System;
using System.Collections.Generic;

namespace ExpenseTracker.Api.Models
{
  public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public IList<Transaction> Transactions { get; set; } = new List<Transaction>();
}

}
