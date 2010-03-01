using System;
using System.Web.Mvc;
using Core;
using Core.Common;
using StructureMap;

namespace Website.ActionResults
{
   public abstract class CommandResult : ActionResult
   {
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
      readonly Func<TInput, ActionResult> _failure;

      readonly TInput _message;
      readonly Func<TResult, ActionResult> _success;
      TResult _result;

      public CommandResult(TInput message, Func<TResult, ActionResult> success, Func<TInput, ActionResult> failure)
      {
         _message = message;
         _success = success;
         _failure = failure;
      }

      public override ActionResult Success
      {
         get { return _success.Invoke(_result); }
      }

      public override ActionResult Failure
      {
         get { return _failure.Invoke(_message); }
      }

      public override void Execute(ControllerContext context)
      {
         var modelState = context.Controller.ViewData.ModelState;

         if (modelState.IsValid)
         {
            var rulesEngine = ObjectFactory.GetInstance<IRulesEngine>();
            var result = rulesEngine.Process(_message);
            if (result.Successful)
            {
               _result = result.Result<TResult>();
               Success.ExecuteResult(context);
               return;
            }

            foreach (var errorMessage in result.Errors)
            {
               modelState.AddModelError(UINameHelper.BuildNameFrom(errorMessage.InvalidProperty), errorMessage.Message);
            }
         }

         Failure.ExecuteResult(context);
      }
   }
}