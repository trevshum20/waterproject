using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WaterProject.Models;
using WaterProject.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WaterProject.Controllers
{
    public class HomeController : Controller
    {

        // New way: Controller no longer accesses the context directly

        private IWaterProjectRepository repo;

        public HomeController (IWaterProjectRepository temp)
        {
            repo = temp;
        }

        // Old way we don't do it like this anymore
        // private WaterProjectContext context { get; set; }

        //public HomeController (WaterProjectContext temp)
        //{
        //    context = temp;
        //}

        // this lamda function is the same as the aboce one
        // the result of the home controller constructor is that context is set equal to temp
        // can't do logic in a lamda funciton

        //public HomeController(WaterProjectContext temp) => context = temp;

        public IActionResult Index(string projectType, int pageNum = 1)
        {
            int pageSize = 5;

            var x = new ProjectsViewModel
            {
                Projects = repo.Projects
                    .Where(p => p.ProjectType == projectType || projectType == null)
                    .OrderBy(p => p.ProjectName)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),


                PageInfo = new PageInfo
                {
                    TotalNumProjects =
                        (projectType == null
                            ? repo.Projects.Count()
                            : repo.Projects.Where(x => x.ProjectType == projectType).Count()),
                    ProjectsPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

           
            return View(x);
        }
    }
}
