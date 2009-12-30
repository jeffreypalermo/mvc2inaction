using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Core
{
	public abstract class Enumeration : IComparable
	{
		protected Enumeration()
		{
		}

		protected Enumeration(int value, string displayName)
		{
			Value = value;
			DisplayName = displayName;
		}

		public virtual string DisplayName { get; private set; }
		public virtual int Value { get; private set; }

		public virtual int CompareTo(object other)
		{
			return Value.CompareTo(((Enumeration) other).Value);
		}

		public static int AbsoluteDifference(Enumeration firstValue, Enumeration secondValue)
		{
			int absoluteDifference = Math.Abs(firstValue.Value - secondValue.Value);
			return absoluteDifference;
		}

		public static T FromDisplayName<T>(string displayName) where T : Enumeration
		{
			T matchingItem = parse<T, string>(displayName, "display name", item => item.DisplayName == displayName);
			return matchingItem;
		}

		public static T FromValue<T>(int value) where T : Enumeration
		{
			T matchingItem = parse<T, int>(value, "value", item => item.Value == value);
			return matchingItem;
		}

		public static IEnumerable<T> GetAll<T>() where T : Enumeration
		{
			Type type = typeof (T);
			FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

			foreach (var info in fields)
			{
				var locatedValue = info.GetValue(null) as T;

				if (locatedValue != null)
				{
					yield return locatedValue;
				}
			}
		}

		public static IEnumerable GetAll(Type type)
		{
			FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

			foreach (var info in fields)
			{
				yield return info.GetValue(null);
			}
		}

		public static bool operator ==(Enumeration left, Enumeration right)
		{
			return Equals(left, right);
		}

		public static implicit operator string(Enumeration enumeration)
		{
			return enumeration == null ? null : enumeration.ToString();
		}

		public static bool operator !=(Enumeration left, Enumeration right)
		{
			return !Equals(left, right);
		}

		public virtual string GetUniqueName()
		{
			return DisplayName;
		}

		public override bool Equals(object obj)
		{
			var otherValue = obj as Enumeration;

			if (otherValue == null)
			{
				return false;
			}

			bool typeMatches = GetType().Equals(obj.GetType());
			bool valueMatches = Value.Equals(otherValue.Value);

			return typeMatches && valueMatches;
		}

		public override int GetHashCode()
		{
			return Value.GetHashCode();
		}

		public override string ToString()
		{
			return DisplayName;
		}

		private static T parse<T, K>(K value, string description, Func<T, bool> predicate) where T : Enumeration
		{
			T matchingItem = GetAll<T>().FirstOrDefault(predicate);

			if (matchingItem == null)
			{
				string message = string.Format("'{0}' is not a valid {1} in {2}", value, description, typeof (T));
				throw new ApplicationException(message);
			}

			return matchingItem;
		}
	}
}