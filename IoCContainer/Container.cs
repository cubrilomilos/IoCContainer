using System;
using System.Collections.Generic;
using System.Text;

namespace IoCContainer
{
    public class Container
    {
        public object GetInstance(Type type)
        {
            return Activator.CreateInstance(type);
        }
    }
}
