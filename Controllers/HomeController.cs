using CodingTests.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CodingTests.Controllers
{
	public class HomeController : Controller
	{
		private IWebHostEnvironment Environment;

		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger, IWebHostEnvironment _environment)
		{
			_logger = logger;
			Environment = _environment;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public  IActionResult Index(EmployeeDetails empdetails)
		{
			string wwwPath = this.Environment.WebRootPath;
			wwwPath = wwwPath+ "\\Submissionfile.json";
			string json = new JavaScriptSerializer().Serialize(empdetails);
			System.IO.File.WriteAllText(wwwPath, json);
			return View(empdetails);
		}
	}
}
