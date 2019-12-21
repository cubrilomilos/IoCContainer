using Entities;
using FluentAssertions;
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
            subject.Should().BeOfType<A>();
        }

        [Test]
        public void CreateInstanceWithParams()
        {
            var subject = (B)Container.GetInstance(typeof(B));
            subject.A.Should().BeOfType<A>();
        }

        [Test]
        public void AllowsAParameterlessConstructor()
        {
            var subject = (C)Container.GetInstance(typeof(C));
            subject.Invoked.Should().BeTrue();          
        }

        [Test]
        public void AllowsGenericInitialization()
        {
            var subject = (A)Container.GetInstance(typeof(A));
            subject.Should().BeOfType<A>();
        }
    }
    
    [TestFixture]
    public class Container_Register : ContainerTestBase
    {
        [Test]
        public void RegisterTypeFromAnInteface()
        {
            Container.Register<IVehicle, Car>();
            var subject = Container.GetInstance<IVehicle>();
            subject.Should().BeOfType<Car>();
        }

        [Test]
        public void InitializeObjectWithDependencies()
        {
            Container.Register<IVehicle, Truck>();
            var subject = (Truck)Container.GetInstance<IVehicle>();
            subject.Wagon.Should().BeOfType<Wagon>();
        }    
    }

    public class Container_RegisterSingleton : ContainerTestBase
    {
        [Test]
        public void ReturnsASingleInstance()
        {
            var factory = new Factory();
            Container.RegisterSingleton(factory);
            var subject = Container.GetInstance<Factory>();
            subject.Should().Be(factory);
        }
    }
}
