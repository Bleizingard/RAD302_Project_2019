//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Text;
//using System.Web.Http;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using StudentAssAttSys.API;
//using StudentAssAttSys.API.Controllers;

//namespace StudentAssAttSys.API.Tests.Controllers
//{
//    [TestClass]
//    public class ModulesControllerTest
//    {
//        [TestMethod]
//        public void Get()
//        {
//            // Réorganiser
//            ModulesController controller = new ModulesController();

//            // Agir
//            IEnumerable<string> result = controller.Get();

//            // Déclarer
//            Assert.IsNotNull(result);
//            Assert.AreEqual(2, result.Count());
//            Assert.AreEqual("value1", result.ElementAt(0));
//            Assert.AreEqual("value2", result.ElementAt(1));
//        }

//        [TestMethod]
//        public void GetById()
//        {
//            // Réorganiser
//            ModuleController controller = new ModuleController();

//            // Agir
//            string result = controller.Get(5);

//            // Déclarer
//            Assert.AreEqual("value", result);
//        }

//        [TestMethod]
//        public void Post()
//        {
//            // Réorganiser
//            ModuleController controller = new ModuleController();

//            // Agir
//            controller.Post("value");

//            // Déclarer
//        }

//        [TestMethod]
//        public void Put()
//        {
//            // Réorganiser
//            ModuleController controller = new ModuleController();

//            // Agir
//            controller.Put(5, "value");

//            // Déclarer
//        }

//        [TestMethod]
//        public void Delete()
//        {
//            // Réorganiser
//            ModuleController controller = new ModuleController();

//            // Agir
//            controller.Delete(5);

//            // Déclarer
//        }
//    }
//}
