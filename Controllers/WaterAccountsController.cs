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
    public IActionResult AddPeople(FormDataModel jsonRequest)
    {
        AccountModel account = CreateNewAccount(jsonRequest);
        accounts.AddAccount(account);
        Console.WriteLine("appartment type: " + account.GetAttributes().appartmentType);
        Console.WriteLine("corporationRatio: " + account.GetAttributes().corporationRatio);
        Console.WriteLine("borewellRatio: " + account.GetAttributes().borewellRatio);
        return View();
    }
    [HttpPost]
    public JsonResult AddWaterAccount(FormDataModel jsonRequest)
    {
        AccountModel account = CreateNewAccount(jsonRequest);
        accounts.AddAccount(account);
        return Json(new
        {
            at = account.GetAttributes().appartmentType,
            cr = account.GetAttributes().corporationRatio,
            br = account.GetAttributes().borewellRatio
        });
    }

    static AccountModel CreateNewAccount(FormDataModel jsonRequest)
    {
        if (jsonRequest.appartmentType != null)
        {
            AccountModel account = new();
            account.SetAppartmentType(jsonRequest.appartmentType);
            account.SetCorporationRatio(jsonRequest.ratio);
            account.SetBorewellRatio(10 - jsonRequest.ratio);
            return account;
        }
        throw new Exception("Json appartment type value is null" + jsonRequest.appartmentType);
    }
}