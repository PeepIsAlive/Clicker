using UnityEngine;

public class ClickButtonController : MonoBehaviour
{
    [SerializeField] private int _clickValue;
    private BankInteractor _bankInteractor;

    private void Awake()
    {
        GameController _gameController = GetComponentInParent<GameController>();

        if (_gameController != null)
        {
            _bankInteractor = _gameController.InteractorsBase.GetInteractor<BankInteractor>();
        }
    }

    public void Click()
    {
        if (_bankInteractor == null) { return; }

        _bankInteractor.Addition(_clickValue);
    }
}
