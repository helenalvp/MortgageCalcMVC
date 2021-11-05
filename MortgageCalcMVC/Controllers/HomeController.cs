using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MortgageCalcMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MortgageCalcMVC.Helpers;

namespace MortgageCalcMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult App()
        {
            Loan loan =new();

            loan.Payment = 0.0m;
            loan.TotalInterest = 0.0m;
            loan.TotalCost = 0.0m;
            loan.Rate = 0.0m;
            loan.Amount = 150000m;
            loan.Term = 60;

            return View(loan);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        
        public IActionResult App(Loan loan)
        {
            var loanHelper = new LoanHelper();

            Loan newLoan = loanHelper.GetPayments(loan);

            return View(newLoan);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
