using System.ComponentModel.DataAnnotations;
using static System.Double;

namespace FinancesBackend.Models;

public enum Category
{
    Fun,
    Clothes,
    Food,
    Tech,
    Transportation,
    Office
}

public class Expense
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    
    [Range(0, MaxValue)]
    public double Value { get; set; }
    public DateTime DateTime { get; set; }
    public Category Category { get; set; }
}