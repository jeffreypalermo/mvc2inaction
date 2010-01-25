using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Routing;

namespace AccountProfile.Models
{
    public abstract class ExplicitFacadeDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        protected abstract IDictionary<TKey, TValue> Wrapped { get; }

        void IDictionary<TKey, TValue>.Add(TKey key, TValue value)
        {
            Wrapped.Add(key, value);
        }

        bool IDictionary<TKey, TValue>.ContainsKey(TKey key)
        {
            return Wrapped.ContainsKey(key);
        }

        ICollection<TKey> IDictionary<TKey, TValue>.Keys
        {
            get { return Wrapped.Keys; }
        }

        bool IDictionary<TKey, TValue>.Remove(TKey key)
        {
            return Wrapped.Remove(key);
        }

        bool IDictionary<TKey, TValue>.TryGetValue(TKey key, out TValue value)
        {
            return Wrapped.TryGetValue(key, out value);
        }

        ICollection<TValue> IDictionary<TKey, TValue>.Values
        {
            get { return Wrapped.Values; }
        }

        TValue IDictionary<TKey, TValue>.this[TKey key]
        {
            get
            {
                return Wrapped[key];
            }
            set
            {
                Wrapped[key] = value;
            }
        }

        void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item)
        {
            Wrapped.Add(item);
        }

        void ICollection<KeyValuePair<TKey, TValue>>.Clear()
        {
            Wrapped.Clear();
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item)
        {
            return Wrapped.Contains(item);
        }

        void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            Wrapped.CopyTo(array, arrayIndex);
        }

        int ICollection<KeyValuePair<TKey, TValue>>.Count
        {
            get { return Wrapped.Count; }
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly
        {
            get { return Wrapped.IsReadOnly; }
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
        {
            return Wrapped.Remove(item);
        }

        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
        {
            return Wrapped.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }

public class ParamBuilder : ExplicitFacadeDictionary<string, object>
{
    private readonly IDictionary<string, object> _params = new Dictionary<string, object>();

    protected override IDictionary<string, object> Wrapped
    {
        get { return _params; }
    }

    public static implicit operator RouteValueDictionary(ParamBuilder paramBuilder)
    {
        return new RouteValueDictionary(paramBuilder);
    }

    public ParamBuilder Username(string value)
    {
        _params.Add("username", value);
        return this;
    }
}
}