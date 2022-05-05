using UnityEngine;

public class BankRepository : Repository
{
    private int _moneyAmount = 0;
    private const string Key = "Money";

    public int MoneyAmount => _moneyAmount;

    public void SetValue(int value)
    {
        _moneyAmount = value;
        Save();
    }

    public override string ToString() => MoneyAmount.ToString() + "$";

    public override void Initialize()
    {
        _moneyAmount = PlayerPrefs.GetInt(Key);
    }

    protected override void Save()
    {
        PlayerPrefs.SetInt(Key, _moneyAmount);
    }
}
