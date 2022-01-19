using Microsoft.AspNetCore.OData;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Shopping.Infrastructure.Providers
{
    public static class ODataProvider
    {
        public static IMvcBuilder AddODataConfiguration(this IMvcBuilder serviceCollection, IConfiguration configuration)
        {
            return serviceCollection
                .AddOData(options => {
                    var oDataEdmProvider = new ODataEdmProvider();

                    options.AddRouteComponents("odata", oDataEdmProvider.GetEdmModel());
                    options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null);
                });
        }
    }
}
