namespace water_management_project_backend.Models;

public class AccountModel
{
    const int CORPORATION_WATER_RATE = 1;
    const double BOREWELL_WATER_RATE = 1.5;
    const int PERSONAL_WATER_ALLOWANCE = 10;
    const int DAYS_IN_A_MONTH = 30;
    const double PERSONAL_WATER_ALLOWANCE_PER_MONTH =
      PERSONAL_WATER_ALLOWANCE * DAYS_IN_A_MONTH;

    private string id;
    private string appartmentType;
    private int corporationRatio;
    private int borewellRatio;
    private int initalPeople;
    private int additionalPeople;
    private int initalWaterAmmount;
    private int additionalWaterAmount;
    private int cost;

    public AccountModel(
        string appartmentType,
        int corporationRatio,
        int borewellRatio)
    {
        Random randomNumberGenatator = new Random();
        id = randomNumberGenatator.Next(1, 1000).ToString();
        this.appartmentType = appartmentType;
        this.corporationRatio = corporationRatio;
        this.borewellRatio = borewellRatio;
        if (appartmentType == "2BHK")
        {
            initalPeople = 3;
        }
        else initalPeople = 5;
        additionalPeople = 0;
        initalWaterAmmount = 0;
        additionalWaterAmount = 0;
        cost = 0;

    }
    public string getId()
    {
        return id;
    }

}