using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using water_management_project_backend.Models;

namespace water_management_project_backend.Controllers;

public class WaterAccountsController : Controller
{
    public ContentResult Index()
    {
        return Content("Hello World");
    }
}