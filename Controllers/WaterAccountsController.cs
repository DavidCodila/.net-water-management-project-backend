using Microsoft.AspNetCore.Mvc;
using water_management_project_backend.Models;
using accounts = water_management_project_backend.Models.AccountsModel;

namespace water_management_project_backend.Controllers;


public class WaterAccountsController : Controller
{
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
    public IActionResult PrintBill()
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
        ViewBag.id = account.GetId();
        //ViewBag.accounts = accounts;
        return View();
    }
    [HttpPost]
    public JsonResult AddWaterAccount(FormDataModel jsonRequest)
    {
        //accounts = ViewBag.accounts;
        AccountModel account = CreateNewAccount(jsonRequest);
        accounts.AddAccount(account);
        return Json(new
        {
            at = account.GetAttributes().appartmentType,
            cr = account.GetAttributes().corporationRatio,
            br = account.GetAttributes().borewellRatio
        });
    }
    [HttpPut]
    public JsonResult AddPeopleToAccount(AddPeopleRequestModel request)
    {
        //dynamic request = JObject.Parse(jsonRequest);
        //JObject request = JObject.Parse(jsonRequest);
        //AccountsModel accountsLocalVar = ViewBag.accounts;
        if (request.id != null)
        {
            AccountModel? account = accounts.GetAccountById(request.id);
            account?.AddPeople(request.peopleToAdd);

            string jsonResponse = "message: There has been " + account?.GetAdditionalPeople() + " added to this account.";
            return Json(new
            {
                response = "There has been " + account?.GetAdditionalPeople() + " added to this account."
            });
        }
        else
        {
            throw new Exception("Json id field was null");
        }
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