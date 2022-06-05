using UnityEngine;

public class BankRepository : Repository
{
    private const string _moneyKey = "Money";
    private const string _moneyTotalKey = "TotalMoney";
    private const string _moneyByClickKey = "MoneyByClickKey";
    private const string _moneyPerSecondKey = "MoneyPerSecondKey";

    public static int MoneyAmount { get; private set; }
    public static int TotalMoneyAmount { get; private set; }
    public static int MoneyAmountByClick { get; private set; }
    public static int MoneyAmountPerSecond { get; private set; }

    public void SetMoneyAmount(int value)
    {
        MoneyAmount = value;
        Save(_moneyKey, MoneyAmount);
    }

    public void IncreaseMoneyAmountByClick(int value)
    {
        MoneyAmountByClick += value;
        Save(_moneyByClickKey, MoneyAmountByClick);
    }

    public void IncreaseMoneyAmountPerSecond(int value)
    {
        MoneyAmountPerSecond += value;
        Save(_moneyPerSecondKey, MoneyAmountPerSecond);
    }

    public void IncreaseTotalMoney(int value)
    {
        TotalMoneyAmount += value;
        Save(_moneyTotalKey, TotalMoneyAmount);
    }

    public override void Initialize()
    {
        TotalMoneyAmount = PlayerPrefs.GetInt(_moneyTotalKey);
        MoneyAmount = PlayerPrefs.GetInt(_moneyKey);
        MoneyAmountByClick = PlayerPrefs.GetInt(_moneyByClickKey);
        MoneyAmountPerSecond = PlayerPrefs.GetInt(_moneyPerSecondKey);
    }

    protected override void Save(string _moneyKey, int value)
    {
        PlayerPrefs.SetInt(_moneyKey, value);
    }
}
