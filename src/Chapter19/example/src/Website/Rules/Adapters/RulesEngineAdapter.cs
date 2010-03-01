using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Tarantino.RulesEngine;
using ErrorMessage=Core.ErrorMessage;

namespace Website.Rules.Adapters
{
   public class RulesEngineAdapter : IRulesEngine
   {
      readonly CommandProcessor.IRulesEngine _rulesEngine;

      public RulesEngineAdapter(CommandProcessor.IRulesEngine rulesEngine)
      {
         _rulesEngine = rulesEngine;
      }

      public ICanSucceed Process(object message)
      {
         var result = _rulesEngine.Process(message);
         return
            new SuccessResult(
               Messages(result),
               Results(result.ReturnItems)) {Successful = result.Successful};
      }

      Dictionary<Type, object> Results(GenericItemDictionary result)
      {
         var returnVal = new Dictionary<Type, object>();
         foreach (KeyValuePair<Type, object> executionResult in result)
         {
            returnVal.Add(executionResult.Key, executionResult.Value);
         }
         return returnVal;
      }

      List<ErrorMessage> Messages(ExecutionResult result)
      {
         return result.Messages.Select(
            errorMessage =>
            new ErrorMessage
               {
                  InvalidProperty = errorMessage.IncorrectAttribute,
                  Message = errorMessage.MessageText
               })
            .ToList();
      }
   }
}