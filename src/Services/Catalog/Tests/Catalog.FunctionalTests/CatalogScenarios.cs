using System.Threading.Tasks;
using Xunit;

namespace Catalog.FunctionalTests
{
    public class CatalogScenarios : CatalogScenarioBase
    {
        [Fact]
        public async Task Get_get_catalogitem_by_id_and_response_ok_status_code()
        {
            using (var server = CreateServer())
            {
                var response = await server.CreateClient()
                    .GetAsync(Get.ItemById(1));

                response.EnsureSuccessStatusCode();
            }
        }
    }
}