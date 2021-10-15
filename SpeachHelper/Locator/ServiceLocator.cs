using SpeachHelper.SpeachRecognition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeachHelper.Locator
{
	

    public static class ServiceLocator
    {
        private readonly static Dictionary<Type, object> services = new Dictionary<Type, object>();

        public static T GetService<T>()
        {
            return (T)ServiceLocator.services[typeof(T)];
        }

        public static void Register<T>(T service)
        {
            ServiceLocator.services[typeof(T)] = service;
        }

        public static void Reset()
        {
            ServiceLocator.services.Clear();
        }
    }
}
