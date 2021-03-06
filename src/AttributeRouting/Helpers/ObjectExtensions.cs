﻿using System;

namespace AttributeRouting.Helpers
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Returns true if the object is null or it's string representation is null or empty.
        /// </summary>
        public static bool HasNoValue(this object obj)
        {
            return (obj == null || obj.ToString().HasNoValue());
        }

        /// <summary>
        /// Will attempt to get the value returned from the delegate.
        /// If a NullReferenceException is thrown, the default for the leaf type will be returned.
        /// </summary>
        public static TResult SafeGet<T, TResult>(this T obj, Func<T, TResult> memberExpression)
        {
            return SafeGet(obj, memberExpression, default(TResult));
        }

        /// <summary>
        /// Will attempt to get the value returned from the delegate.
        /// If a NullReferenceException is thrown, the given default will be returned.
        /// </summary>
        public static TResult SafeGet<T, TResult>(this T obj, Func<T, TResult> memberExpression, TResult defaultValue)
        {
            try
            {
                return memberExpression(obj);
            }
            catch (NullReferenceException)
            {
                return defaultValue;
            }
        }
    }
}
