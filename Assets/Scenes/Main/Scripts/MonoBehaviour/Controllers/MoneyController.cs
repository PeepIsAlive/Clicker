using System;
using System.Collections;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    [SerializeField] private ParticleSystem _onClickVFX;
    [SerializeField] private DisplayValueUpdater _moneyAmountUpdater;
    [SerializeField] private DisplayValueUpdater _moneyPerSecondUpdater;
    private BankInteractor _interactor;

    public void Initialize()
    {
        GameController _gameController = GetComponentInParent<GameController>();

        if (_gameController != null)
        {
            _interactor = _gameController.InteractorsBase.GetInteractor<BankInteractor>();
        }

        _moneyAmountUpdater.Initialize();
        _moneyPerSecondUpdater.Initialize();
    }

    public void OnStart(int valueForOfflineTime)
    {
        AdditionMoney(valueForOfflineTime);
        StartCoroutine(AdditionValuePerSecond());
        PrintToDisplayMoneyState();
    }

    public void OnClick()
    {
        if (_interactor == null) { return; }

        AdditionMoney(BankRepository.MoneyAmountByClick);

        if (_onClickVFX != null)
        {
            if (_onClickVFX.isStopped)
            {
                _onClickVFX.Play();
            }
        }
    }

    public void AdditionValuePerSecond(int value)
    {
        if (_interactor == null || value <= 0) { return; }

        _interactor.IncreaseMoneyAmountPerSecond(value);

        if (_moneyPerSecondUpdater != null)
        {
            _moneyPerSecondUpdater.SetValue(BankRepository.MoneyAmountPerSecond, "+");
        }
    }

    public void AdditionClickValue(int value)
    {
        if (_interactor == null || value <= 0) { return; }

        _interactor.IncreaseMoneyAmountByClick(value);
    }

    public void SubstractionMoney(int value)
    {
        if (_interactor == null || value <= 0) { return; }

        _interactor.SubstractionMoney(value);

        if (_moneyAmountUpdater != null)
        {
            _moneyAmountUpdater.SetValue(BankRepository.MoneyAmount, "");
        }
    }

    public void AdditionMoney(int value)
    {
        if (_interactor == null || value <= 0) { return; }

        _interactor.AdditionMoney(value);

        if (_moneyAmountUpdater != null)
        {
            _moneyAmountUpdater.SetValue(BankRepository.MoneyAmount, "");
        }
    }

    private IEnumerator AdditionValuePerSecond()
    {
        yield return new WaitForSeconds(1f);
        AdditionMoney(BankRepository.MoneyAmountPerSecond);
        yield return StartCoroutine(AdditionValuePerSecond());
    }

    private void PrintToDisplayMoneyState()
    {
        if (_moneyPerSecondUpdater != null)
        {
            _moneyPerSecondUpdater.SetValue(BankRepository.MoneyAmountPerSecond, "+");
        }
    }
}
