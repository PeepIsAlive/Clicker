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
        }

        _valueText = GetComponent<Text>();
    }

    private void FixedUpdate()
    {
        SetValue();
    }

    private void SetValue()
    {
        _valueText.text = _bankRepository.ToString();
    }
}
