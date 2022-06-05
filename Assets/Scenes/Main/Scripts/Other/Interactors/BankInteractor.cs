public class BankInteractor : Interactor
{
    private BankRepository _repository;

    public override Repository Repository => _repository;
    private int _moneyAmount;

    public override Repository Initialize()
    {
        _repository = new BankRepository();

        if (_repository != null)
        {
            _repository.Initialize();

            _moneyAmount = BankRepository.MoneyAmount;
        }

        return _repository;
    }

    public void AdditionMoney(int value)
    {
        if (value <= 0) { return; }

        _moneyAmount += value;

        _repository.IncreaseTotalMoney(value);
        _repository.SetMoneyAmount(_moneyAmount);
    }

    public void SubstractionMoney(int value)
    {
        if (value <= 0) { return; }

        _moneyAmount -= value;

        _repository.SetMoneyAmount(_moneyAmount);
    }
    
    public void IncreaseMoneyAmountByClick(int value)
    {
        if (value <= 0) { return; }

        _repository.IncreaseMoneyAmountByClick(value);
    }

    public void IncreaseMoneyAmountPerSecond(int value)
    {
        if (value <= 0) { return; }

        _repository.IncreaseMoneyAmountPerSecond(value);
    }
}
