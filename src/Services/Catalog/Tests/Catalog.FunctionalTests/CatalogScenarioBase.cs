using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration.Json;
using Catalog.API;
using Microsoft.Extensions.Configuration;
using Catalog.API.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.Extensions.Hosting;

namespace Catalog.FunctionalTests
{
    public class CatalogWebApplication : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            var path = Assembly.GetAssembly(typeof(CatalogScenarioBase)).Location;
            builder.UseContentRoot(Path.GetDirectoryName(path));
            return base.CreateHost(builder);
        }
    }

    public class CatalogScenarioBase
    {
        public CatalogWebApplication CreateServer()
        {
            return new CatalogWebApplication();
        }
    }

    public static class Get
    {
        public static string ItemById(int id)
        {
            return $"api/v1/catalog/items/{id}";
        }
    }
}
