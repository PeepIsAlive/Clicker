using UnityEngine;
using UnityEngine.UI;

public class DisplayValueUpdater : MonoBehaviour
{
    private Text _valueText;
    private BankRepository _bankRepository;

    public void Initialize()
    {
        GameController _gameController = GetComponentInParent<GameController>();

        if (_gameController != null)
        {
            _bankRepository = _gameController.RepositoriesBase.GetRepository<BankRepository>();

            if (_bankRepository != null)
            {
                _valueText = GetComponent<Text>();
            }
        }
    }

    public void OnStart()
    {
        SetValue();
    }

    private void FixedUpdate()
    {
        SetValue();
    }

    private void SetValue()
    {
        if (_valueText == null) { return; }

        _valueText.text = _bankRepository.ToString();
    }
}
