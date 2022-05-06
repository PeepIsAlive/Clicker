public class BankInteractor : Interactor
{
    private BankRepository _repository;

    public override Repository Repository => _repository;
    public int MoneyAmount { get; private set; }

    public override Repository Initialize()
    {
        _repository = new BankRepository();

        if (_repository != null)
        {
            _repository.Initialize();
            MoneyAmount = _repository.MoneyAmount;
        }

        return _repository;
    }

    public void Addition(int value)
    {
        if (value <= 0) { return; }

        MoneyAmount += value;

        _repository.IncreaseTotalMoney(value);
        _repository.SetValue(MoneyAmount);
    }

    public void Substraction(int value)
    {
        if (value <= 0) { return; }

        MoneyAmount -= value;

        _repository.SetValue(MoneyAmount);
    }
}
