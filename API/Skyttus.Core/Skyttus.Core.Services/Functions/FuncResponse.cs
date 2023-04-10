using Microsoft.AspNetCore.Mvc;
using Skyttus.Core.Services.Result;

namespace Skyttus.Core.Services.Functions
{
    public class FuncResponse
    {
        public IActionResult? Type { get; set; }
        public BaseResult? Result { get; set; }
    }
}
