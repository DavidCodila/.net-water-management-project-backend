using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using water_management_project_backend.Models;
using System.Net.Http;

namespace water_management_project_backend.Controllers;

public class WaterAccountsController : Controller
{
    public ContentResult Index()
    {
        AccountModel accountModel = new AccountModel();
        return Content("Account id: " + accountModel.getId());
    }
    public IActionResult AddAccount()
    {
        return View();
    }
    [HttpPost]
    public JsonResult AddWaterAccount(FormDataModel jsonRequest)
    {
        return Json(new { appartment_type = jsonRequest });
    }
}