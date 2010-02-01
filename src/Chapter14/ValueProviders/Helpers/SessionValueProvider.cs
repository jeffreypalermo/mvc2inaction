using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Web;
using System.Web.Mvc;
using System.Linq;

namespace ValueProvidersExample.Helpers
{
public class SessionValueProvider : IValueProvider
{
    public SessionValueProvider(HttpSessionStateBase session)
    {
        AddValues(session);
    }

private readonly HashSet<string> _prefixes
    = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
private readonly Dictionary<string, ValueProviderResult> _values
    = new Dictionary<string, ValueProviderResult>(StringComparer.OrdinalIgnoreCase);

private void AddValues(HttpSessionStateBase session)
{
    if (session.Keys.Count > 0)
    {
        _prefixes.Add("");
    }

    foreach (string key in session.Keys)
    {
        if (key != null)
        {
            _prefixes.Add(key);

            object rawValue = session[key];
            string attemptedValue = session[key].ToString();
            _values[key] = new ValueProviderResult(
                rawValue, 
                attemptedValue, 
                CultureInfo.CurrentCulture);
        }
    }
}

public bool ContainsPrefix(string prefix)
{
    return _prefixes.Contains(prefix);
}

public ValueProviderResult GetValue(string key)
{
    ValueProviderResult result;
    
    _values.TryGetValue(key, out result);
    
    return result;
}
    }
}