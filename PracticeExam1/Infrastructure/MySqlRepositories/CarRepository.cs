using Microsoft.EntityFrameworkCore;
using PracticeExam1.Domain.Models;
using PracticeExam1.Domain.Repositories;

namespace PracticeExam1.Infrastructure.MySqlRepositories;

public class CarRepository : ICarRepository
{
    private readonly MySqlDbContext _context;

    public CarRepository(MySqlDbContext context)
    {
        _context = context;
    }

    public async Task<Car> AddAsync(Car car)
    {
        _context.Cars.Add(car);

        await _context.SaveChangesAsync();
        
        return car;
    }

    public async Task<List<Car>> FindAllAsync()
    {
        return await _context.Cars.ToListAsync();
    }

    public async Task<Car?> FindByIdAsync(int id)
    {
        return await _context.Cars.FindAsync(id);
    }

    public async Task<Car> UpdateAsync(Car car)
    {
        var existingCar = await _context.Cars.FindAsync(car.Id);

        if (existingCar == null)
            throw new ArgumentException("Car does not exist");

        _context.Entry(existingCar).CurrentValues.SetValues(car);

        _context.Cars.Update(existingCar);

        await _context.SaveChangesAsync();

        return existingCar;

    }

    public async Task DeleteAsync(Car car)
    {
        var existing = await _context.Cars.FindAsync(car.Id);

        if (existing == null)
            throw new ArgumentException("Car does not exist");

        _context.Cars.Remove(existing);

        await _context.SaveChangesAsync();
    }
}
