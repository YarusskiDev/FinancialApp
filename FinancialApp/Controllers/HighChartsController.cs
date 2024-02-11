using Highsoft.Web.Mvc.Charts;
using Microsoft.AspNetCore.Mvc;

namespace FinancialApp.Controllers
{
    public partial class HighChartsController : Controller
    {
        public ActionResult Column3DInteractive()
        {
            List<PieSeriesData> pieData = new List<PieSeriesData>();

            pieData.Add(new PieSeriesData { Name = "FireFox", Y = 45.0 });
            pieData.Add(new PieSeriesData { Name = "IE", Y = 26.8 });
            pieData.Add(new PieSeriesData { Name = "Chrome", Y = 12.8, Sliced = true, Selected = true });
            pieData.Add(new PieSeriesData { Name = "Safari", Y = 8.5 });
            pieData.Add(new PieSeriesData { Name = "Opera", Y = 6.2 });
            pieData.Add(new PieSeriesData { Name = "Others", Y = 0.7 });
            pieData.Add(new PieSeriesData { Name = "Meu Teste", Y = 80 });

            ViewData["pieData"] = pieData;

            return View();
        }
    }
}
