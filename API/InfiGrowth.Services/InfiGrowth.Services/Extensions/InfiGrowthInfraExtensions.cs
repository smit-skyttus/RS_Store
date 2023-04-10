using InfiGrowth.Services.Helpers;
using InfiGrowth.Services.Services;
using InfiGrowth.Services.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace InfiGrowth.Services.Extensions
{
    public static class InfiGrowthServiceExtensions
    {
        public static IServiceCollection InfiGrowthInfraService(this IServiceCollection builder)
        {
            //All service needs to register for Dependency injection
            builder.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
                
            builder.AddScoped<ICustomersService, CustomersService>();
            builder.AddScoped<ICategoriesService, CategoriesService>();
            builder.AddScoped<IDeliveriesService, DeliveriesService>();
            builder.AddScoped<IProductService, ProductService>();
            builder.AddScoped<ISellerService, SellerService>();
            builder.AddScoped<IShoppingService, ShoppingService>();
            
            builder.AddScoped<IPaymentService, PaymentService>();
            builder.AddScoped<ITransactionReportsService, TransactionReportsService>();
            builder.AddScoped<IAuthService, AuthService>();

            return builder;
        }
    }
}
