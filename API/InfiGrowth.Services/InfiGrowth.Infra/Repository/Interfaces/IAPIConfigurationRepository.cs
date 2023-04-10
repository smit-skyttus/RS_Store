namespace InfiGrowth.Infra.Repository.Interfaces
{
    public interface IAPIConfigurationRepository
    {
        Task<List<T>> GetConfiguration<T>(string type) where T : class;
        Task UpdateConfiguration<T>(string type, Guid id) where T : class;
    }
}
