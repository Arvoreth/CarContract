using PracticeExam1.Domain.Repositories;

namespace PracticeExam1.Domain.Models;

public class Car : IEntity
{
    public int Id { get; set; }

    public string Make { get; set; }

    public string Model { get; set; }

    public int Year { get; set; }
}
