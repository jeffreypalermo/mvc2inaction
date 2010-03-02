using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;
using Website.ActionResults;
using Website.Mvc;

namespace Website.Controllers
{
   public abstract class CommandController : Controller
   {
      public RedirectToRouteResult RedirectToAction<TController>(Expression<Func<TController, object>> actionExpression)
      {
         var controllerName = typeof (TController).GetControllerName();
         var actionName = actionExpression.GetActionName();

         return RedirectToAction(actionName, controllerName);
      }

      public RedirectToRouteResult RedirectToAction<TController>(Expression<Func<TController, object>> actionExpression,
                                                                 IDictionary<string, object> dictionary)
      {
         var controllerName = typeof (TController).GetControllerName();
         var actionName = actionExpression.GetActionName();

         return RedirectToAction(actionName, controllerName,
                                 new RouteValueDictionary(dictionary));
      }

      public RedirectToRouteResult RedirectToAction<TController>(Expression<Func<TController, object>> actionExpression,
                                                                 object values)
      {
         var controllerName = typeof (TController).GetControllerName();
         var actionName = actionExpression.GetActionName();

         return RedirectToAction(actionName, controllerName,
                                 new RouteValueDictionary(values));
      }

      /// <summary>
      /// 
      /// </summary>
      /// <typeparam name="TMessage"></typeparam>
      /// <typeparam name="TResult"></typeparam>
      /// <param name="message">The user interface message that will be sent to the rules engine.</param>
      /// <param name="success">The Action Result to perform on a successful command execution.</param>
      /// <param name="failure">The Action Result to perofmr on a failed command execution.</param>
      /// <returns></returns>
      public CommandResult Command<TMessage, TResult>(TMessage message, Func<TResult, ActionResult> success,
                                                      Func<TMessage, ActionResult> failure)
      {
         return new CommandResult<TMessage, TResult>(message, success, failure);
      }

      public CommandResult Command<TMessage>(TMessage message, Func<TMessage, ActionResult> result)
      {
         return new CommandResult<TMessage, TMessage>(message, result, result);
      }

      public CommandResult Command<TMessage>(TMessage message, Func<ActionResult> result)
      {
         return new CommandResult<TMessage, TMessage>(message, m => result(), m => result());
      }

      public CommandResult Command<TMessage>(TMessage message, Func<ActionResult> success, Func<ActionResult> failure)
      {
         return new CommandResult<TMessage, TMessage>(message, m => success(), m => failure());
      }

      public AutoMappedViewResult AutoMappedView<TModel>(object Model)
      {
         ViewData.Model = Model;
         return new AutoMappedViewResult(typeof (TModel))
                   {
                      ViewData = ViewData,
                      TempData = TempData
                   };
      }
   }
}