using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using water_management_project_backend.Models;

namespace water_management_project_backend.Controllers;

public class WaterAccountsController : Controller
{
    public ContentResult Index()
    {
        AccountModel accountModel = new AccountModel("2BHK", 1, 1);
        return Content("Account id: " + accountModel.getId());
    }
}