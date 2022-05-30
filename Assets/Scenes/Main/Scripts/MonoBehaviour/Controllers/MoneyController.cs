using System.Collections;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    [SerializeField] private int _valuePerSeconds;
    [SerializeField] private int _clickValue;
    [SerializeField] private ParticleSystem _onClickVFX;
    [SerializeField] private DisplayValueUpdater _updater;
    private BankInteractor _interactor;

    public int ValuePerSeconds => _valuePerSeconds;

    public void Initialize()
    {
        GameController _gameController = GetComponentInParent<GameController>();

        if (_gameController != null)
        {
            _interactor = _gameController.InteractorsBase.GetInteractor<BankInteractor>();
        }

        _updater.Initialize();
    }

    public void OnStart(int valueForOfflineTime)
    {
        AdditionMoney(valueForOfflineTime);
        _updater.SetValue();
        StartCoroutine(AdditionValuePerSeconds());
    }

    public void OnClick()
    {
        if (_interactor == null) { return; }

        AdditionMoney(_clickValue);
        _updater.SetValue();

        if (_onClickVFX != null)
        {
            if (_onClickVFX.isStopped)
            {
                _onClickVFX.Play();
            }
        }
    }

    public void AdditionMoney(int value)
    {
        _interactor.Addition(value);
    }

    private IEnumerator AdditionValuePerSeconds()
    {
        yield return new WaitForSeconds(1f);
        AdditionMoney(_valuePerSeconds);
        _updater.SetValue();
        yield return StartCoroutine(AdditionValuePerSeconds());
    }
}
