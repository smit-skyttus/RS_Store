using InfiGrowth.Entity.Manage;
using InfiGrowth.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiGrowth.Services.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(UserRequestModel user, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
    }
}
