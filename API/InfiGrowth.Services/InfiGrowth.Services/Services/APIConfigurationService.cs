using InfiGrowth.Infra.Repository.Interfaces;
using InfiGrowth.Services.Services.Interfaces;

namespace InfiGrowth.Services.Services
{
    public class APIConfigurationService : IAPIConfigurationService
    {
        private readonly IAPIConfigurationRepository _configurationRepository;

        public APIConfigurationService(IAPIConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }

        public Task<List<T>> GetConfiguration<T>(string type) where T : class
        {
            return _configurationRepository.GetConfiguration<T>(type);
        }
    }
}
