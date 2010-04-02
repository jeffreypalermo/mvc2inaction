using System;
using System.Web.Mvc;
using Core;
using Core.Common;
using StructureMap;

namespace Website.ActionResults
{
   public abstract class CommandResult : ActionResult
   {
      public abstract object Message { get; }
      public abstract ActionResult Success { get; }
      public abstract ActionResult Failure { get; }

      public override void ExecuteResult(ControllerContext context)
      {
         Execute(context);
      }

      public abstract void Execute(ControllerContext context);
   }

   public class CommandResult<TInput, TResult> : CommandResult
   {
      readonly TInput _message;
      readonly Func<TInput, ActionResult> _failure;
      readonly Func<TResult, ActionResult> _success;
      TResult _result;

      public CommandResult(TInput message,
                           Func<TResult, ActionResult> success,
                           Func<TInput, ActionResult> failure)
      {
         _message = message;
         _success = success;
         _failure = failure;
      }

      public override object Message
      {
         get { return _message; }
      }

      public override ActionResult Success
      {
         get { return _success(_result); }
      }

      public override ActionResult Failure
      {
         get { return _failure(_message); }
      }

      public override void Execute(ControllerContext context)
      {
         var modelState = context.Controller.ViewData.ModelState;

         if (modelState.IsValid)
         {
            var rulesEngine = ObjectFactory.GetInstance<IMyRulesEngine>();
            var result = rulesEngine.Process(_message);
            if (result.Successful)
            {
               _result = result.Result<TResult>();
               Success.ExecuteResult(context);
               return;
            }

            foreach (var errorMessage in result.Errors)
            {
               var name = UINameHelper.BuildNameFrom(errorMessage.InvalidProperty);
               modelState.AddModelError(name, errorMessage.Message);
            }
         }

         Failure.ExecuteResult(context);
      }
   }
}