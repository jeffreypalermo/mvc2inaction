using AutoMapper;
using Core.Messages;
using Website.Controllers;
using Website.Models;

namespace Website.System
{
   public class RulesProfile : Profile
   {
      protected override void Configure()
      {
         Mapper.CreateMap<CustomerInput, SaveCustomer>();
         Mapper.CreateMap<ShipOrderMessage, ShipOrder>();
      }
   }
}