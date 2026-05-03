using Microsoft.AspNetCore.Mvc;
using StockManagement.Core;
using StockManagement.Interface;

namespace Stock_Management.Controllers
{
    public class MatchFrontAnalysisController : Controller
    {
        private readonly ILineService _lineService;

        public MatchFrontAnalysisController(ILineService lineService)
        {
            _lineService = lineService;
        }

        // GET: MatchFrontAnalysis
        public IActionResult MatchFrontAnalysis()
        {
            var lines = _lineService.GetAll();
            return View(lines);
        }
    }
}
