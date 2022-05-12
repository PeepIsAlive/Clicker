using UnityEngine;
using UnityEngine.UI;

public class ButtonsStateChanger : MonoBehaviour
{
    [SerializeField] private Button[] _buttonsArray;

    public void SetInteractableMainButtons(bool state)
    {
        if (_buttonsArray == null) { return; }

        foreach (Button button in _buttonsArray)
        {
            if (button != null)
            {
                button.interactable = state;
            }
        }
    }
}
