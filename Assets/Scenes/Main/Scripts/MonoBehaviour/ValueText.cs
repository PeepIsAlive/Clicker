using UnityEngine;
using UnityEngine.UI;

public class ValueText : MonoBehaviour
{
    private Text _valueText;
    private BankRepository _bankRepository;

    private void Awake()
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
