using System;
using NUnit.Framework;
using StudentAssAttSys.Infrastructure.Repositories;
using StudentAssAttSys.Core.Core;
using Telerik.JustMock;
using System.Collections.Generic;

namespace StudentAssAttSys.Infrastructure.Tests.Repositories
{
    [TestFixture]
    public class ModuleRepositoryTest
    {
        private ModuleRepository Repository = new ModuleRepository();

        [OneTimeSetUp]
        public void InitialeSetup()
        {
            Repository = new ModuleRepository();
        }

        [SetUp]
        public void Setup()
        {
            //Put some Data
            Repository.Add
                ( new Module
                    {
                        Name = "FirstModule",
                        GPAPercentage = 10.00
                    }
                );
        }

        [TearDown]
        public void CleanUp()
        {
            Module[] modules = Repository.GetAll();

            foreach (Module module in modules)
            {
                Repository.Remove(module);
            }
        }

        [Test]
        public void ShouldAddModule()
        {
            Module module = new Module
            {
                Name = "ShouldAddModuleTest",
                GPAPercentage = 10.00
            };

            int result = Repository.Add(module);
            Assert.That(result, Is.GreaterThan(0));
        }

        [Test]
        public void ShouldGetAllModule()
        {
            Module[] modules = Repository.GetAll();
            Assert.That(modules.Length, Is.EqualTo(1));
        }

        [Test]
        public void ShouldGetModuleById()
        {
            int moduleId = Repository.Add(new Module { Name = "ShouldGetModuleByIdTest", GPAPercentage = 1.0 });
            Module module = Repository.GetById(moduleId);
            Assert.That(module.Name, Is.EqualTo("ShouldGetModuleByIdTest"));
        }

        [Test]
        public void ShouldEditModule()
        {
            int moduleId = Repository.Add(new Module { Name = "ShouldEditModuleTest", GPAPercentage = 1.0 });
            Module module = Repository.GetById(moduleId);

            module.Name = "ShouldEditModuleTestEdited";

            bool result = Repository.Edit(module);

            module = Repository.GetById(moduleId);

            //Better to double check
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(true));
                Assert.That(module.Name, Is.EqualTo("ShouldEditModuleTestEdited"));
            });

            

        }

        [Test]
        public void ShouldDeleteModule()
        {
            Module module = Repository.GetAll()[0];

            int moduleId = module.Id;
            bool result = Repository.Remove(module);

            //Better to double check
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(true));
                Assert.That(Repository.GetById(moduleId), null);
            });
            
        }
    }
}
