using AutoMapper;
using Core.Domain;
using Website.Models;

namespace Website.System
{
   public class WebsiteProfile : Profile
   {
      protected override void Configure()
      {
         Mapper.CreateMap<Customer, CustomerInput>();
         Mapper.CreateMap<Order, OrderInfo>();
      }
   }
}