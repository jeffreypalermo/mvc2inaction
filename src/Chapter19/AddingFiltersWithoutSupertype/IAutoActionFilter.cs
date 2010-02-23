using System.Web.Mvc;

namespace AddingFiltersWithoutSupertype
{
   public interface IAutoActionFilter : IActionFilter, IResultFilter
   {
   }
}