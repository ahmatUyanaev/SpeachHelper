using System;
using System.Collections.Generic;

namespace SpeachHelper.Domain.DI
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, object> services
          = new Dictionary<Type, object>();

        public static T GetService<T>()
        {
            return (T)services[typeof(T)];
        }

        public static void Register<T>(T service)
        {
            services[typeof(T)] = service;
        }

        public static void Reset()
        {
            services.Clear();
        }
    }
}