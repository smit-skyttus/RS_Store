using InfiGrowth.Infra.Context;
using InfiGrowth.Infra.Repository;
using InfiGrowth.Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InfiGrowth.Infra.Extensions
{
    public static class InfiGrowthInfraExtensions
    {
        public static IServiceCollection InfiGrowthInfraServiceRegistration(this IServiceCollection builder, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("InfiGrowthConnectionString");

            builder.AddDbContext<InfiGrowthContext>(options => {
                options.UseSqlServer(connectionString);
                options.EnableSensitiveDataLogging(true);
            });
            

            builder.AddScoped<DbContext, InfiGrowthContext>();
            builder.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.AddScoped<ICategoriesRepository, CategoriesRepository>();
            builder.AddScoped<IDeliveriesRepository, DeliveriesRepository>();
            builder.AddScoped<IProductRepository, ProductRepository>();
            builder.AddScoped<ISellerRepository, SellerRepository>();
            builder.AddScoped<IShoppingRpository, ShoppingRepository>();
   
            builder.AddScoped<IPaymentRepository, PaymentRepository>();
            builder.AddScoped<ITransactionReportsRepository, TransactionReportsRepository>();
            builder.AddScoped<IAuthRepository, AuthRepository>();


            return builder;
        }

        public static IServiceCollection InfiGrowthInfraServiceRegistrationForBackground(this IServiceCollection builder, IConfiguration configuration)
        {
            //builder.ConfigureCoreInfra();

            var connectionString = configuration.GetConnectionString("InfiGrowthConnectionString");

            builder.AddDbContext<InfiGrowthContext>(
                options => options.UseSqlServer(connectionString),
                ServiceLifetime.Singleton);

            builder.AddTransient<ICustomerRepository, CustomerRepository>();
            builder.AddTransient<ICategoriesRepository, CategoriesRepository>();
            builder.AddTransient<IDeliveriesRepository, DeliveriesRepository>();
            builder.AddTransient<IProductRepository, ProductRepository>();
            builder.AddTransient<ISellerRepository, SellerRepository>();
            builder.AddTransient<IShoppingRpository, ShoppingRepository>();
            builder.AddTransient<IPaymentRepository, PaymentRepository>();
            builder.AddTransient<ITransactionReportsRepository, TransactionReportsRepository>();
            builder.AddTransient<IAuthRepository, AuthRepository>();
          
            return builder;

        }

    }
}
