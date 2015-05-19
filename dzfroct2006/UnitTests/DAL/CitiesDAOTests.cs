using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;
using dzfroct2006.DAL;
using dzfroct2006.Models;
using Moq;
using System.Data.Entity;

namespace UnitTests.DAL
{
    [TestFixture]
    class CitiesDAOTests
    {
        private CitiesDAO DAO;
        private Mock<HotelsDBContext> MockContext;

        [SetUp]
        public void init()
        {
            //add any global init here
              
        }

        [TestCase] 
        public void GetAllCities_IfNoCity_ReturnsEmptyList()
        {
            //Arrange
            var data = new List<City>().AsQueryable();

            var mockSet = new Mock<DbSet<City>>();
            mockSet.As<IQueryable<City>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<City>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<City>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<City>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            MockContext = new Mock<HotelsDBContext>();
            MockContext.Setup(c => c.City).Returns(mockSet.Object);
            
            DAO = new CitiesDAO(MockContext.Object);  

            //Act
            var Result = DAO.GetAllCities();

            //Assert
            Assert.AreEqual(0, Result.Count());
        }

         [TestCase]
        public void GetAllCities_ReturnsTheRightCountOfCities()
        {
            //Arrange
            var data = new List<City> 
            { 
                new City { Commune = "Alger"}, 
                new City { Commune = "Blida" }, 
                new City { Commune = "Batna" }, 
            }.AsQueryable();

            var mockSet = new Mock<DbSet<City>>();
            mockSet.As<IQueryable<City>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<City>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<City>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<City>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            MockContext = new Mock<HotelsDBContext>();
            MockContext.Setup(c => c.City).Returns(mockSet.Object);
             
            DAO = new CitiesDAO(MockContext.Object);        
            
             //Act
            var Result = DAO.GetAllCities();

            //Assert
            Assert.AreEqual(3, Result.Count);
            Assert.AreEqual("Alger", Result[0].Commune);
            Assert.AreEqual("Batna", Result[1].Commune);
            Assert.AreEqual("Blida", Result[2].Commune); 

        }

         [TestCase]
        public void CitiesStartWith_ReturnsNullIfNoCityStartingWithString()
        {
             //Arrange
            var data = new List<City> 
            { 
                new City { Commune = "Alger", Wilaya = "Alger"}, 
                new City { Commune = "Blida", Wilaya = "Blida" }, 
                new City { Commune = "Batna", Wilaya = "Batna" }, 
            }.AsQueryable();

            var mockSet = new Mock<DbSet<City>>();
            mockSet.As<IQueryable<City>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<City>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<City>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<City>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            MockContext = new Mock<HotelsDBContext>();
            MockContext.Setup(c => c.City).Returns(mockSet.Object);
             
            DAO = new CitiesDAO(MockContext.Object);        
            
             //Act
            var Result = DAO.CitiesStartWith("Noo");
             //Assert
            Assert.AreEqual(0, Result.Count);
        }

         [TestCase]
        public void CitiesStartWith_ReturnsAllCitiesStartingWithString()
        {
             //Arrange
            var data = new List<City> 
            { 
                new City { Commune = "Alger", Wilaya = "Alger"}, 
                new City { Commune = "Blida", Wilaya = "Blida" }, 
                new City { Commune = "Batna", Wilaya = "Batna" }, 
            }.AsQueryable();

            var mockSet = new Mock<DbSet<City>>();
            mockSet.As<IQueryable<City>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<City>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<City>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<City>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            MockContext = new Mock<HotelsDBContext>();
            MockContext.Setup(c => c.City).Returns(mockSet.Object);
             
            DAO = new CitiesDAO(MockContext.Object);        
             
             //Act
            var Result = DAO.CitiesStartWith("AL");
             
             //Assert
            Assert.AreEqual(1, Result.Count);
        }
    }
}
