namespace water_management_project_backend.Models;
public class AccountsModel
{
    public static List<AccountModel>? accounts;
    public void addAccount(AccountModel accountModel)
    {
        accounts?.Add(accountModel);
    }
}
