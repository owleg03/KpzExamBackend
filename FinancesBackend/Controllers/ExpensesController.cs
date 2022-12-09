using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using FinancesBackend.Efc;
using FinancesBackend.Models;

namespace FinancesBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ExpensesController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // GET: api/Expenses
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Expense>>> GetExpenses()
    {
        return await _context.Expenses.ToListAsync();
    }

    // GET: api/Expenses/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Expense>> GetExpense(int id)
    {
        var expense = await _context.Expenses.FindAsync(id);

        if (expense == null)
        {
            return NotFound("Could not find this expense.");
        }

        return expense;
    }

    // PUT: api/Expenses/5
    [HttpPut("{id}")]
    public async Task<ActionResult<Expense>> PutExpense(int id, Expense expense)
    {
        if (id != expense.Id)
        {
            return BadRequest("Provided id does not match with expense id.");
        }

        var storedExpense = await _context.Expenses.FindAsync(id);
        if (storedExpense == null)
        {
            return NotFound("Could not find this expense.");
        }

        storedExpense.Name = expense.Name;
        storedExpense.Value = expense.Value;
        storedExpense.DateTime = expense.DateTime;
        storedExpense.Category = expense.Category;

        await _context.SaveChangesAsync();
        return Ok(storedExpense);
    }
    
    // PUT: api/Expenses/3
    [HttpPut("{id}/{category}")]
    public async Task<ActionResult<Expense>> PutExpense(int id, Category category)
    {
        var storedExpense = await _context.Expenses.FindAsync(id);
        if (storedExpense == null)
        {
            return NotFound("Could not find this expense.");
        }
        
        storedExpense.Category = category;
        await _context.SaveChangesAsync();
        
        return Ok(storedExpense);
    }

    // POST: api/Expenses
    [HttpPost]
    public async Task<ActionResult<Expense>> PostExpense(ExpenseDto expenseDto)
    {
        var expense = _mapper.Map<Expense>(expenseDto);
        
        _context.Expenses.Add(expense);
        await _context.SaveChangesAsync();

        return Ok(expense);
    }

    // DELETE: api/Expenses/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteExpense(int id)
    {
        var expense = await _context.Expenses.FindAsync(id);
        if (expense == null)
        {
            return NotFound("Could not find this expense.");
        }

        _context.Expenses.Remove(expense);
        await _context.SaveChangesAsync();

        return Ok($"Expense {expense.Name} was deleted successfully.");
    }
}