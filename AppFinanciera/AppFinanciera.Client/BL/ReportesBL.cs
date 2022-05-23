using AppFinanciera.Client.ApiClient;
using AppFinanciera.SharedModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFinanciera.Client.BL
{
    public class ReportesBL
    {
        private ReportesAPI reportesAPI;

        public ReportesBL(ReportesAPI api)
        {
            reportesAPI = api;
        }

        public async Task<List<ReporteTO>> GetReporte(FiltroReporte filtro)
            => await reportesAPI.GetReporteAsync(filtro);
    }
}
