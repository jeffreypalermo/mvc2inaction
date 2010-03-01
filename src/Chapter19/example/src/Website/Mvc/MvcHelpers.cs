using System;
using System.Linq.Expressions;

namespace Website.Mvc
{
   public static class MvcHelpers
   {
      public static string GetControllerName(this Type controllerType)
      {
         return controllerType.Name.Replace("Controller", string.Empty);
      }

      public static string GetActionName(this LambdaExpression actionExpression)
      {
         return ((MethodCallExpression) actionExpression.Body).Method.Name;
      }
   }
}