using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IoCContainer
{
    public class Container
    {
        public T GetInstance<T>()
        {
            return (T)GetInstance((typeof(T)));
        }


        public object GetInstance(Type type)
        {
            var constructor = type.GetConstructors()
                .OrderByDescending(c => c.GetParameters().Length).First();

            var args = constructor.GetParameters()
                .Select(param => GetInstance(param.ParameterType)).ToArray();

            return Activator.CreateInstance(type, args);
        }
    }
}
