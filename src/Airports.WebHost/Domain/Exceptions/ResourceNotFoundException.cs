using System;

namespace Airports.WebHost.Domain.Exceptions
{
    public class ResourceNotFoundException : InvalidOperationException
    {
        public ResourceNotFoundException(string message)
            : base(message)
        {
        }

        public static ResourceNotFoundException FromEntity<T>(string id)
        {
            return new ResourceNotFoundException($"Cannot find entity of type {typeof(T).Name} with id:{id}");
        }
    }
}