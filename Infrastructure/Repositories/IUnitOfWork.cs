namespace Infrastructure.Repositories
{
    public interface IUnitOfWork
    {
        IResponseRepository Responses { get; }
        Task<int> CompleteAsync();
    }

}