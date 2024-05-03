using System.Linq.Expressions;

namespace water_management_project_backend.Models;

public class AccountModel
{
    const int CORPORATION_WATER_RATE = 1;
    const double BOREWELL_WATER_RATE = 1.5;
    const int PERSONAL_WATER_ALLOWANCE = 10;
    const int DAYS_IN_A_MONTH = 30;
    const double PERSONAL_WATER_ALLOWANCE_PER_MONTH =
      PERSONAL_WATER_ALLOWANCE * DAYS_IN_A_MONTH;

    private string? id;
    private string? appartmentType;
    private int corporationRatio;
    private int borewellRatio;
    private int initalPeople;
    private int additionalPeople { get; set; }
    private int initalWaterAmmount { get; set; }
    private int additionalWaterAmount { get; set; }
    private int cost { get; set; }

    public AccountModel()
    {
        GenerateID();
        additionalPeople = 0;
        initalWaterAmmount = 0;
        additionalWaterAmount = 0;
        cost = 0;

    }
    public string? GetId()
    {
        return id;
    }
    public int GetInitalPeople()
    {
        return initalPeople;
    }
    public int GetAdditionalPeople()
    {
        return additionalPeople;
    }
    public void AddPeople(int people)
    {
        additionalPeople += people;
    }

    public string GenerateID()
    {
        Random randomNumberGenatator = new Random();
        id = randomNumberGenatator.Next(1, 1000).ToString();
        return id;
    }
    public void SetAppartmentType(string appartment_type)
    {
        switch (appartment_type)
        {
            case "2BHK":
                initalPeople = 3;
                break;
            case "3BHK":
                initalPeople = 5;
                break;
            default:
                appartmentType = "";
                throw new Exception(appartment_type);
        }
        appartmentType = appartment_type;
    }
    public void SetCorporationRatio(int ratio)
    {
        corporationRatio = ratio;
    }
    public void SetBorewellRatio(int ratio)
    {
        borewellRatio = ratio;
    }
    public FormDataModel GetAttributes()
    {
        FormDataModel data = new()
        {
            appartmentType = appartmentType,
            borewellRatio = borewellRatio,
            corporationRatio = corporationRatio
        };
        return data;
    }
}