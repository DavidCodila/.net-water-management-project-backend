using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using water_management_project_backend.Models;
using System.Net.Http;

namespace water_management_project_backend.Controllers;


public class WaterAccountsController : Controller
{
    AccountsModel accounts = new();
    public ContentResult Index()
    {
        AccountModel account = new AccountModel();
        return Content("Account id: " + account.GetId());
    }
    public IActionResult AddAccount()
    {
        return View();
    }
    [HttpPost]
    public JsonResult AddWaterAccount(FormDataModel jsonRequest)
    {
        AccountModel account = CreateNewAccount(jsonRequest);
        accounts.AddAccount(account);
        FormDataModel data = account.GetAttributes();
        return Json(new { accountId = account.GetId(), apartmentType = data.appartmentType, corporationRatio = data.corporationRatio, borewellRatio = data.borewellRatio });
    }

    static AccountModel CreateNewAccount(FormDataModel jsonRequest)
    {
        if (jsonRequest.appartmentType != null)
        {
            AccountModel account = new();
            account.SetAppartmentType(jsonRequest.appartmentType);
            account.SetBorewellRatio(jsonRequest.borewellRatio);
            account.SetCorporationRatio(jsonRequest.corporationRatio);
            return account;
        }
        throw new Exception(jsonRequest.appartmentType);
    }
}