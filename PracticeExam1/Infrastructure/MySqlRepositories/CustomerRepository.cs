using Microsoft.EntityFrameworkCore;
using PracticeExam1.Domain.Models;
using PracticeExam1.Domain.Repositories;

namespace PracticeExam1.Infrastructure.MySqlRepositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly MySqlDbContext _context;

    public CustomerRepository(MySqlDbContext context)
    {
        _context = context;
    }

    public async Task<Customer> AddAsync(Customer customer)
    {
        _context.Customers.Add(customer);

        await _context.SaveChangesAsync();

        return customer;
    }

    public async Task<List<Customer>> FindAllAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task<Customer?> FindByIdAsync(int id)
    {
        return await _context.Customers.FindAsync(id);
    }

    public async Task<Customer> UpdateAsync(Customer customer)
    {
        var existingCustomer = await _context.Customers.FindAsync(customer.Id);

        if (existingCustomer == null)
            throw new ArgumentException("Customer does not exist");

        _context.Entry(existingCustomer).CurrentValues.SetValues(customer);

        _context.Customers.Update(existingCustomer);

        await _context.SaveChangesAsync();

        return existingCustomer;
    }

    public async Task DeleteAsync(Customer customer)
    {
        var existingCustomer = await _context.Customers.FindAsync(customer.Id);

        if (existingCustomer == null)
            throw new ArgumentException("Customer does not exist");

        _context.Customers.Remove(existingCustomer);

        await _context.SaveChangesAsync();
    }
}
