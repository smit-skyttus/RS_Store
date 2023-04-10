using AutoMapper;
using InfiGrowth.Entity.Manage;
using InfiGrowth.Infra.Repository.Interfaces;
using InfiGrowth.Models.Models;
using InfiGrowth.Services.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiGrowth.Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthService(IAuthRepository authRepository, IMapper mapper, IConfiguration configuration)
        {
            _authRepository = authRepository;
            _mapper = mapper;
            _configuration = configuration;

        }

        public Task<ServiceResponse<string>> Login(string username, string password)
        {
            return _authRepository.Login(username, password);
        }

        public Task<ServiceResponse<int>> Register(UserRequestModel user, string password)
        {
            var result = _authRepository.Register(_mapper.Map<InfiGrowth.Entity.Manage.User>(user),password);
            return (result);
        }
    }
}
