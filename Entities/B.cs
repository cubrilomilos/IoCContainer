using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class B
    {
        public A A { get; }

        public B() { }

        public B(A a)
        {
            A = a;
        }

    }
}
