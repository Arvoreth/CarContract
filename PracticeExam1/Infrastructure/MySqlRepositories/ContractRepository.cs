using Microsoft.EntityFrameworkCore;
using PracticeExam1.Domain.Models;
using PracticeExam1.Domain.Repositories;

namespace PracticeExam1.Infrastructure.MySqlRepositories;

public class ContractRepository : IContractRepository 
{
    private readonly MySqlDbContext _context;

    public ContractRepository(MySqlDbContext context)
    {
        _context = context;
    }

    public async Task<Contract> AddAsync(Contract contract)
    {
        _context.Contracts.Add(contract);

        await _context.SaveChangesAsync();

        return contract;
    }

    public async Task<List<Contract>> FindAllAsync()
    {
        return await _context.Contracts.ToListAsync();
    }

    public async Task<Contract?> FindByIdAsync(int id)
    {
        return await _context.Contracts.FindAsync(id);
    }

    public async Task<Contract> UpdateAsync(Contract contract)
    {
        var existingContract = await _context.Contracts.FindAsync(contract.Id);

        if (existingContract == null)
            throw new ArgumentException("Contract does not exist");

        _context.Entry(existingContract).CurrentValues.SetValues(contract);

        _context.Contracts.Update(existingContract);

        await _context.SaveChangesAsync();

        return existingContract;
    }

    public async Task DeleteAsync(Contract contract)
    {
        var existingContract = await _context.Contracts.FindAsync(contract.Id);

        if (existingContract == null)
            throw new ArgumentException("Contract does not exist");

        _context.Contracts.Remove(existingContract);

        await _context.SaveChangesAsync();
    }
}
