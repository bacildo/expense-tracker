using System;

namespace ExpenseTracker.Api.Models
{
public class Transaction
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;    // ou = default!;
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string Note { get; set; } = string.Empty;
}

}


