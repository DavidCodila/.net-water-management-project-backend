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
        return Content("Account id: " + accountModel.GetId());
    }
    public IActionResult AddAccount()
    {
        return View();
    }
    [HttpPost]
    public JsonResult AddWaterAccount(FormDataModel jsonRequest)
    {
        if (jsonRequest.appartmentType != null)
        {
            AccountModel accountModel = new AccountModel();
            accountModel.SetAppartmentType(jsonRequest.appartmentType);
            accountModel.SetBorewellRatio(jsonRequest.borewellRatio);
            accountModel.SetCorporationRatio(jsonRequest.corporationRatio);
            AccountsModel.accounts?.Add(accountModel);
            return Json(new { accountId = accountModel.GetId() });
        }
        return Json(new { accountId = "error" });
    }
}