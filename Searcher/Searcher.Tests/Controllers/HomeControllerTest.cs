using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Searcher;
using Searcher.Controllers;
using Searcher.Models;
using System.IO;
namespace Searcher.Tests.Controllers
{
   [TestClass]
   public class HomeControllerTest
   {
      [TestMethod]
      public void Index()
      {
         // Arrange
         PeopleController controller = new PeopleController();

         // Act
         ViewResult result = controller.Index(null,null) as ViewResult;

         // Assert
         Assert.AreEqual("Index",result.ViewName);
      }
      [TestMethod]
      public void Create()
      {
         // Arrange
         PeopleController controller = new PeopleController();

         // Act
         ViewResult result = controller.Create() as ViewResult;

         // Assert
         Assert.AreEqual("Create", result.ViewName);
      }
   }
}
