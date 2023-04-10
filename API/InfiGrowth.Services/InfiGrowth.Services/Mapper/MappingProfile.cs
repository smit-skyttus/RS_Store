using AutoMapper;
using InfiGrowth.Entity.Manage;
using dto = InfiGrowth.Models.Dto;
using model = InfiGrowth.Models.Models;

namespace InfiGrowth.Services.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<InfiGrowth.Models.Models.CustomersRequestModel, Customers>();
            CreateMap<Customers, InfiGrowth.Models.Models.CustomersRequestModel>();

            CreateMap<InfiGrowth.Models.Models.CustomersResponseModel, Customers>();
            CreateMap<Customers, InfiGrowth.Models.Models.CustomersResponseModel>();

            CreateMap<InfiGrowth.Models.Models.CategoriesRequestModel, Categories>();
            CreateMap<Categories, InfiGrowth.Models.Models.CategoriesRequestModel>();

            CreateMap<InfiGrowth.Models.Models.CategoriesResponseModel, Categories>();
            CreateMap<Categories, InfiGrowth.Models.Models.CategoriesResponseModel>();

            CreateMap<InfiGrowth.Models.Models.DeliveriesResponseModel, Deliveries>();
            CreateMap<Deliveries, InfiGrowth.Models.Models.DeliveriesResponseModel>();

            CreateMap<InfiGrowth.Models.Models.DeliveriesRequestModel, Deliveries>();
            CreateMap<Deliveries, InfiGrowth.Models.Models.DeliveriesRequestModel>();

            CreateMap<InfiGrowth.Models.Models.ProductsResponseModel, Products>();
            CreateMap<Products, InfiGrowth.Models.Models.ProductsResponseModel>();

            CreateMap<InfiGrowth.Models.Models.ProductRequestModel, Products>();
            CreateMap<Products, InfiGrowth.Models.Models.ProductRequestModel>();

            CreateMap<InfiGrowth.Models.Models.SellerRequest, Seller>();
            CreateMap<Seller, InfiGrowth.Models.Models.SellerRequest>();

            CreateMap<InfiGrowth.Models.Models.SellerResponseModel, Seller>();
            CreateMap<Seller, InfiGrowth.Models.Models.SellerResponseModel>();

            CreateMap<InfiGrowth.Models.Models.ShoppingRequestModel, ShoppingOrder>();
            CreateMap<ShoppingOrder, InfiGrowth.Models.Models.ShoppingRequestModel>();

            CreateMap<InfiGrowth.Models.Models.ShoppingResponseModel, ShoppingOrder>();
            CreateMap<ShoppingOrder, InfiGrowth.Models.Models.ShoppingResponseModel>();


            CreateMap<InfiGrowth.Models.Models.PaymentResponseModel, Payment>();
            CreateMap<Payment, InfiGrowth.Models.Models.PaymentResponseModel>();

            CreateMap<InfiGrowth.Models.Models.PaymentRequestModel, Payment>();
            CreateMap<Payment, InfiGrowth.Models.Models.PaymentRequestModel>();

            CreateMap<InfiGrowth.Models.Models.TransactionReportsResponseModel, TransactionReports>();
            CreateMap<TransactionReports, InfiGrowth.Models.Models.TransactionReportsResponseModel>();

            CreateMap<InfiGrowth.Models.Models.TransactionReportsRequestModel, TransactionReports>();
            CreateMap<TransactionReports, InfiGrowth.Models.Models.TransactionReportsRequestModel>();

            CreateMap<InfiGrowth.Models.Models.UserRequestModel, User>();
            CreateMap<User, InfiGrowth.Models.Models.UserRequestModel>();
        }
    }
}
