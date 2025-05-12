using PracticeExam1.Domain.Repositories;

namespace PracticeExam1.Domain.Models;

public class Contract : IEntity
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Price { get; set; }

    public int CarId { get; set; } 
    public int CustomerId { get; set; }
}
