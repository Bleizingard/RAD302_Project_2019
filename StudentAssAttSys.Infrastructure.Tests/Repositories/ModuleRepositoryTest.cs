using System;
using NUnit.Framework;
using StudentAssAttSys.Infrastructure.Repositories;

namespace StudentAssAttSys.Infrastructure.Tests.Repositories
{
    [TestFixture]
    public class ModuleRepositoryTest
    {
        private ModuleRepository Repository = new ModuleRepository();

        [Test]
        public void ShouldAddModule()
        {
        }

        [Test]
        public void ShouldEditModule()
        {
        }

        [Test]
        public void ShouldDeleteModule()
        {
        }

        [Test]
        public void ShouldGetModuleById()
        {
        }

        [Test]
        public void ShouldGetAllModule()
        {
        }

        [Test]
        public void ShouldThrowNotImplementedError()
        {
            Assert.Throws<NotImplementedException>(() => Repository.GetById(string.Empty));
        }
    }
}
