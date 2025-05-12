namespace PracticeExam1.Domain.Repositories;

public interface IRepository<TEntity> where TEntity : IEntity
{
    public Task<TEntity?> FindAllAsync();

    public Task<TEntity?> FindByIdAsync(int id);

    public Task<TEntity?> AddAsync(TEntity entity);

    public Task<TEntity?> UpdateAsync(TEntity entity);

    public Task<TEntity?> DeleteAsync(int id);
}

public interface IEntity
{
    public int Id { get; set; }
}
