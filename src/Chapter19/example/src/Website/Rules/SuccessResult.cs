using System;
using System.Collections.Generic;
using Core;

namespace Website.Rules
{
   public class SuccessResult : IResult
   {
      readonly List<ErrorMessage> _errorMessages;
      readonly Dictionary<Type, object> _results;

      public SuccessResult(List<ErrorMessage> errorMessages, Dictionary<Type, object> results)
      {
         _errorMessages = errorMessages;
         _results = results;
      }

      public bool Successful { get; set; }

      public IEnumerable<ErrorMessage> Errors
      {
         get { return _errorMessages; }
      }

      public T Result<T>()
      {
         if (_results.ContainsKey(typeof(T)))
            return (T)_results[typeof(T)];

         return default(T);
      }
   }
}