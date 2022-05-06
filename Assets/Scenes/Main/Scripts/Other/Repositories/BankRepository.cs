using UnityEngine;

public class BankRepository : Repository
{
    private const string Key = "Money";
    private const string KeyTotal = "TotalMoney";

    public int MoneyAmount { get; private set; }
    public int TotalMoneyAmount { get; private set; }

    public void SetValue(int value)
    {
        MoneyAmount = value;
        Save(Key, MoneyAmount);
    }

    public void IncreaseTotalMoney(int value)
    {
        TotalMoneyAmount += value;
        Save(KeyTotal, TotalMoneyAmount);
    }

    public override string ToString() => MoneyAmount.ToString() + "$";

    public override void Initialize()
    {
        TotalMoneyAmount = PlayerPrefs.GetInt(KeyTotal);
        MoneyAmount = PlayerPrefs.GetInt(Key);
    }

    protected override void Save(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }
}
