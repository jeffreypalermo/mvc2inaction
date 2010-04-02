using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using MvcContrib.CommandProcessor;
using ErrorMessage = Core.ErrorMessage;

namespace Website.Rules.Adapters
{
   public class MyRulesEngine : IMyRulesEngine
   {
      readonly IRulesEngine _rulesEngine;

      public MyRulesEngine(IRulesEngine rulesEngine)
      {
         _rulesEngine = rulesEngine;
      }

      public IResult Process(object message)
      {
         var result = _rulesEngine.Process(message);
         return new SuccessResult(Messages(result), Results(result.ReturnItems)) {Successful = result.Successful};
      }

      static Dictionary<Type, object> Results(GenericItemDictionary result)
      {
         var returnVal = new Dictionary<Type, object>();
         foreach (KeyValuePair<Type, object> executionResult in result)
         {
            returnVal.Add(executionResult.Key, executionResult.Value);
         }
         return returnVal;
      }

      static List<ErrorMessage> Messages(ExecutionResult result)
      {
         return result.Messages.Select(msg => new ErrorMessage
                                                 {
                                                    InvalidProperty = msg.IncorrectAttribute,
                                                    Message = msg.MessageText
                                                 })
            .ToList();
      }
   }
}