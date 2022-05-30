using UnityEngine;

public class BankRepository : Repository
{
    private const string key = "Money";
    private const string keyTotal = "TotalMoney";

    public static int MoneyAmount { get; private set; }
    public static int TotalMoneyAmount { get; private set; }

    public void SetValue(int value)
    {
        MoneyAmount = value;
        Save(key, MoneyAmount);
    }

    public void IncreaseTotalMoney(int value)
    {
        TotalMoneyAmount += value;
        Save(keyTotal, TotalMoneyAmount);
    }

    public override void Initialize()
    {
        TotalMoneyAmount = PlayerPrefs.GetInt(keyTotal);
        MoneyAmount = PlayerPrefs.GetInt(key);
    }

    protected override void Save(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }
}
