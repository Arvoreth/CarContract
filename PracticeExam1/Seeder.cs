using PracticeExam1.Domain.Models;
using PracticeExam1.Infrastructure.MySqlRepositories;

namespace PracticeExam1;

public static class Seeder
{
    public static void FillMockData(MySqlDbContext context)
    {
        if (!context.Customers.Any())
        {
            Customer customer1 = new Customer()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Phone = "123-456-7890",
                DriverLicense = "DL123456",
            };

            Customer customer2 = new Customer()
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Smith",
                Phone = "987-654-3210",
                DriverLicense = "DL654321",
            };

            context.Customers.Add(customer1);
            context.Customers.Add(customer2);
        }

        if (!context.Cars.Any())
        {
            Car car1 = new Car
            {
                Id = 1,
                Make = "Toyota",
                Model = "Camry",
                Year = 2020,
            };

            Car car2 = new Car
            {
                Id = 2,
                Make = "Honda",
                Model = "Honda",
                Year = 2021,
            };

            context.Cars.Add(car1);
            context.Cars.Add(car2);
        }

        if (!context.Contracts.Any())
        {
            Contract contract1 = new Contract
            {
                Id = 1,
                CustomerId = 1,
                CarId = 1,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(8),
                Price = 1000.00m
            };

            Contract contract2 = new Contract
            {
                Id = 2,
                CustomerId = 2,
                CarId = 2,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(4),
                Price = 1200.00m
            };

            context.Contracts.Add(contract1);
            context.Contracts.Add(contract2);
        }

        int states = context.SaveChanges();

        Console.WriteLine($"Added {states} records to the database.");
    }
}
