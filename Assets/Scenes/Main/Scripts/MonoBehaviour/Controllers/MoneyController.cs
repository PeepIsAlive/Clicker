using System.Collections;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    [SerializeField] private int _valuePerSeconds;
    [SerializeField] private int _clickValue;
    [SerializeField] private ParticleSystem _onClickVFX;
    private BankInteractor _bankInteractor;

    public int ValuePerSeconds => _valuePerSeconds;

    public void Initialize()
    {
        GameController _gameController = GetComponentInParent<GameController>();

        if (_gameController != null)
        {
            _bankInteractor = _gameController.InteractorsBase.GetInteractor<BankInteractor>();
        }
    }

    public void OnStart(int valueForOfflineTime)
    {
        AdditionMoney(valueForOfflineTime);
        StartCoroutine(AdditionValuePerSeconds());
    }

    public void OnClick()
    {
        if (_bankInteractor == null) { return; }

        AdditionMoney(_clickValue);

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
        _bankInteractor.Addition(value);
    }

    private IEnumerator AdditionValuePerSeconds()
    {
        yield return new WaitForSeconds(1f);
        AdditionMoney(_valuePerSeconds);
        yield return StartCoroutine(AdditionValuePerSeconds());
    }
}
