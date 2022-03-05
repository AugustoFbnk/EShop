using Catalog.API.Controllers;
using Catalog.API.Infrastructure;
using Catalog.API.IntegrationEvents;
using Catalog.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Catalog.UnitTests.Application
{
    public class CatalogControllerTest
    {
        private readonly DbContextOptions<CatalogContext> _dbOptions;
        public CatalogControllerTest()
        {
            _dbOptions = new DbContextOptionsBuilder<CatalogContext>()
            .UseInMemoryDatabase(databaseName: "in-memory")
            .Options;

            using (var dbContext = new CatalogContext(_dbOptions))
            {
                dbContext.AddRange(GetFakeCatalog());
                dbContext.SaveChanges();
            }
        }

        [Fact]
        public async Task Get_catalog_item_success()
        {
            //Arrange
            var catalogContext = new CatalogContext(_dbOptions);
            var integrationServicesMock = new Mock<ICatalogIntegrationEventService>();

            //Act
            var orderController = new CatalogController(catalogContext, integrationServicesMock.Object);
            var actionResult = await orderController.ItemByIdAsync(1);

            //Assert
            Assert.IsType<ActionResult<CatalogItem>>(actionResult);
            var item = Assert.IsAssignableFrom<CatalogItem>(actionResult.Value);
            Assert.Equal(1, item.Id);
        }

        private List<CatalogItem> GetFakeCatalog()
        {
            return new List<CatalogItem>()
            {
                new CatalogItem()
                {
                    Id = 1,
                    Name = "fakeItemA",
                    Description = "fake Item A",
                    CatalogTypeId = 2,
                    CatalogBrandId = 1,
                    PictureFileName = "fakeItemA.png"
                },
                new CatalogItem()
                {
                    Id = 2,
                    Name = "fakeItemB",
                    Description = "fake Item B",
                    CatalogTypeId = 2,
                    CatalogBrandId = 1,
                    PictureFileName = "fakeItemB.png"
                },
                new CatalogItem()
                {
                    Id = 3,
                    Name = "fakeItemC",
                    Description = "fake Item C",
                    CatalogTypeId = 2,
                    CatalogBrandId = 1,
                    PictureFileName = "fakeItemC.png"
                },
                new CatalogItem()
                {
                    Id = 4,
                    Name = "fakeItemD",
                    Description = "fake Item D",
                    CatalogTypeId = 2,
                    CatalogBrandId = 1,
                    PictureFileName = "fakeItemD.png"
                },
                new CatalogItem()
                {
                    Id = 5,
                    Name = "fakeItemE",
                    Description = "fake Item E",
                    CatalogTypeId = 2,
                    CatalogBrandId = 1,
                    PictureFileName = "fakeItemE.png"
                },
                new CatalogItem()
                {
                    Id = 6,
                    Name = "fakeItemF",
                    Description = "fake Item F",
                    CatalogTypeId = 2,
                    CatalogBrandId = 1,
                    PictureFileName = "fakeItemF.png"
                }
            };
        }
    }
}
