namespace InfiGrowth.Services.Services.Interfaces
{
    public interface IAPIConfigurationService
    {
        Task<List<T>> GetConfiguration<T>(string type) where T : class;
    }
}
