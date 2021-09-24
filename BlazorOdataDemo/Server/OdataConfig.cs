using BlazorOdataDemo.Shared;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace BlazorOdataDemo.Server;

public static class OdataConfig
{
    public static IEdmModel GetEdmModel()
    {
        var odataBuilder = new ODataConventionModelBuilder();
        odataBuilder.EntitySet<WeatherForecast>(name: "WeatherForecast");
        return odataBuilder.GetEdmModel();
    }
}
