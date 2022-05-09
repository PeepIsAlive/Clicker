using UnityEngine;
using UnityEngine.UI;

public class GameButtonController : MonoBehaviour
{
    [SerializeField] private Button[] _mainButtonsArray;

    public void SetInteractableMainButtons(bool state)
    {
        if (_mainButtonsArray == null) { return; }

        foreach (Button button in _mainButtonsArray)
        {
            if (button != null)
            {
                button.interactable = state;
            }
        }
    }
}
