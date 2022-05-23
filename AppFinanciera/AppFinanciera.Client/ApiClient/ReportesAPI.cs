using AppFinanciera.SharedModel;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AppFinanciera.Client.ApiClient
{
    public class ReportesAPI : HttpClient
    {
        public ReportesAPI(string rootUrl)
        {
            rootUrl += (rootUrl.EndsWith('/')) ? "Reporte/" : "/Reporte/";
            BaseAddress = new Uri(rootUrl);
        }

        public async Task<List<ReporteTO>> GetReporteAsync(FiltroReporte filtro)
            => await this.GetFromJsonAsync<List<ReporteTO>>($"{filtro.IdCliente}/{filtro.IdCuenta}");
    }
}
