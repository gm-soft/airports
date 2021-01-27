using System;

namespace Airports.WebHost.Domain
{
    public static class Utils
    {
        public static void ThrowIfNull<T>(this T @object, string paramName)
        {
            if (@object == null)
            {
                throw new ArgumentNullException(paramName: paramName);
            }
        }
    }
}