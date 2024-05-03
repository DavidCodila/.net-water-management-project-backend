namespace water_management_project_backend.Models;
public static class AccountsModel
{
    private static readonly List<AccountModel> accounts = new List<AccountModel>();

    public static void AddAccount(AccountModel accountModel)
    {
        accounts?.Add(accountModel);
    }
    public static AccountModel? GetAccountById(string Id)
    {
        if (accounts == null)
        {
            throw new Exception();
        }
        else
        {
            foreach (AccountModel account in accounts)
            {
                if (account.GetId() == Id)
                {
                    return account;
                }
            }
        }
        return null;
    }
}
