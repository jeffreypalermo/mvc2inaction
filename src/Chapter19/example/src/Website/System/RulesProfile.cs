using AutoMapper;
using Core;
using Website.Models;

namespace Website.System
{
   public class RulesProfile : Profile
   {
      protected override void Configure()
      {
         Mapper.CreateMap<CustomerInput, SaveCustomerCommand>();
      }
   }
}