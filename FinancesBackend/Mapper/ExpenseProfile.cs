using AutoMapper;

using FinancesBackend.Models;

namespace FinancesBackend.Mapper;

public class ExpenseProfile: Profile
{
    public ExpenseProfile()
    {
        CreateMap<ExpenseDto, Expense>();
    }
}