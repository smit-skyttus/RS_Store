using Microsoft.EntityFrameworkCore;

namespace Skyttus.Core.Infra.Context
{
    public class SkyttusBaseContext : DbContext
    {
        public SkyttusBaseContext(DbContextOptions options) : base(options)
        {

        }

    }
}
