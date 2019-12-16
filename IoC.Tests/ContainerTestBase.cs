using IoCContainer;
using NUnit.Framework;
using ShouldBeAssertions.Core;

namespace IoC.Tests
{
    public class ContainerTestBase
    {
        protected Container Container;

        [SetUp]
        public void BeforeEach()
        {
            Container = new Container();
        }

        [TearDown]
        public void AfterEach()
        {
            Container = null;
        }
    }

    [TestFixture]
    public class Container_GetInstance : ContainerTestBase
    {
        [Test]
        public void CreateInstanceWithNoParams()
        {
            var subject = (A) Container.GetInstance(typeof(A));
            Assert.AreEqual(typeof(A), subject.GetType());
        }

        [Test]
        public void CreateInstanceWithParams()
        {
            var subject = (B)Container.GetInstance(typeof(B));
            Assert.AreEqual(typeof(A), subject.A.GetType());
        }

        [Test]
        public void AllowsAParameterlessConstructor()
        {
            var subject = (C)Container.GetInstance(typeof(C));
            Assert.AreEqual(true, subject.Invoked);
        }

        [Test]
        public void AllowsGenericInitialization()
        {
            var subject = (A)Container.GetInstance(typeof(A));
            Assert.AreEqual(typeof(A), subject.GetType());
        }
    }
    class A { }
    class B 
    { 
        public A A { get; }

        public B() { }

        public B(A a)
        {
            A = a;
        }

    }

    public class C
    {
        public bool? Invoked { get; set; }

        public C()
        {
            Invoked = true;
        }
    }
}
