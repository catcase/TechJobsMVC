using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results
        public IActionResult Results(string SearchTerm, string SearchType)
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";

            if (SearchType.Equals("all"))
            {
                //Console.WriteLine("Search all fields not yet implemented.");
                //pull in find by value data to search all jobs across columns
                ViewBag.jobs = JobData.FindByValue(SearchTerm);
            }
            else
            {
                ViewBag.jobs = JobData.FindByColumnAndValue(SearchType, SearchTerm);
            }

            return View("Index");

        }
    }
}
