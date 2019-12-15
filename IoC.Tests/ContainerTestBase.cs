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
        public void CreateInstanceWithParams()
        {
            var subject = (A) Container.GetInstance(typeof(A));
            Assert.AreEqual(typeof(A), subject.GetType());
        }
    }
    class A { }

}
