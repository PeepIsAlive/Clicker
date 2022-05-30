using UnityEngine;
using UnityEngine.UI;

public class DisplayValueUpdater : MonoBehaviour
{
    private Text _valueText;

    public void Initialize()
    {
        _valueText = GetComponent<Text>();
    }

    public void SetValue()
    {
        if (_valueText == null) { return; }

        _valueText.text = BankRepository.MoneyAmount.ToString() + "$";
    }
}
