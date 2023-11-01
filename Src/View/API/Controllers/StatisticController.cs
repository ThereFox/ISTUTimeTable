using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ISTUTimeTable.Entitys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ISTUTimeTable.View.Controllers;

[Route("statistic")]
public class StatisticController : Controller
{
    private readonly ILogger<StatisticController> _logger;

    public StatisticController(ILogger<StatisticController> logger)
    {
        _logger = logger;
    }


    [Route("/user/{id:int}")]
    [HttpGet]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.Client, NoStore = true)]
    public IActionResult StatisticByUser(int userid)
    {
        return View();
    }

    [Route("/group/{id:int}")]
    [HttpGet]
    public IActionResult StatisticByGroup(int groupId)
    {
        return View();
    }

}
