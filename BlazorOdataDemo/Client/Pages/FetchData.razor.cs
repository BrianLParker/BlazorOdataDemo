using System.Net.Http.Json;
using BlazorOdataClient;
using BlazorOdataClient.Services.Odata;
using BlazorOdataDemo.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazorOdataDemo.Client.Pages;

public partial class FetchData
{
    private int itemCount = 0;
    private bool updateDisabled = false;
    private OdataVirtualize<WeatherForecast>? view;
    private IOdataService<WeatherForecast> weatherService;

    [Inject]
    private IOdataClientFactory odataClientFactory { get; set; }

    protected override async Task OnInitializedAsync()
    {
        updateDisabled = true;
        weatherService = odataClientFactory.Create<WeatherForecast>(
            httpClientName: "Server.Api",
            endPoint: "WeatherForecast");

        itemCount = await weatherService.GetItemCountAsync();
        updateDisabled = false;
    }

    private async Task Update()
    {
        updateDisabled = true;
        var http = HttpClientFactory.CreateClient(name: "Server.Api");
        await http.PostAsJsonAsync(requestUri: "api/WeatherForecast", itemCount);
        updateDisabled = false;
        await view.RefreshDataAsync();
    }
}
