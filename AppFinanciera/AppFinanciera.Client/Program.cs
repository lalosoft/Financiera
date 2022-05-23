using AppFinanciera.Client.ApiClient;
using AppFinanciera.Client.BL;
using AppFinanciera.SharedModel;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AppFinanciera.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            var http = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
            var config = await http.GetFromJsonAsync<Settings>("appsettings.json");

            builder.Services.AddTransient(ca => new ClientesAPI(config.UrlApi));
            builder.Services.AddSingleton<ClientesBL>();

            builder.Services.AddTransient(ch => new CuentasAhorroAPI(config.UrlApi));
            builder.Services.AddSingleton<CuentasAhorroBL>();

            builder.Services.AddTransient(ch => new ReportesAPI(config.UrlApi));
            builder.Services.AddSingleton<ReportesBL>();

            await builder.Build().RunAsync();
        }
    }
}
