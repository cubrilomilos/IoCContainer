﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IoCContainer
{
    public class Container
    {
        private readonly Dictionary<Type, Func<object>> _registeredTypes = new Dictionary<Type, Func<object>>();

        public void Register<TInterface, TImplementation>()
        {
            _registeredTypes.Add(typeof(TInterface), () => GetInstance(typeof(TImplementation)));
        }
        public void RegisterSingleton<T>(T obj)
        {
            _registeredTypes.Add(typeof(T), () => obj);
        }

        public T GetInstance<T>()
        {
            return (T)GetInstance((typeof(T)));
        }

        public object GetInstance(Type type)
        {
            if (_registeredTypes.ContainsKey(type))
            {
                return _registeredTypes[type]();
            }

            var constructor = type.GetConstructors()
                .OrderByDescending(c => c.GetParameters().Length).First();

            var args = constructor.GetParameters()
                .Select(param => GetInstance(param.ParameterType)).ToArray();

            return Activator.CreateInstance(type, args);
        }
    }
}
