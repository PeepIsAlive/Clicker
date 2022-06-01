using UnityEngine;
using UnityEngine.UI;

public abstract class ScrollViewElementsCreater : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private GameObject _content;
    protected const float availableCheckDelay = 5f;

    protected GameObject template => _template;
    protected GameObject content => _content;

    public virtual void Initialize()
    {
        if (_content != null)
        {
            OptionPanel optionPanel = GetComponent<OptionPanel>();
            RectTransform rectTransform = _content.GetComponent<RectTransform>();

            if (optionPanel != null)
            {
                optionPanel.Initialize();
            }
            rectTransform.transform.localPosition = Vector3.zero;
        }
    }

    public abstract void OnStart();

    protected abstract void SetElements();

    protected void SetSizeDelta(GameObject template, GameObject content, int arrayLength)
    {
        if (template == null || content == null) { return; }

        GameObject example = Instantiate(template, content.transform);
        RectTransform contentRectTransform = content.GetComponent<RectTransform>();
        float exampleHeight = example.GetComponent<RectTransform>().rect.height;
        Vector2 contentSize = new Vector2(contentRectTransform.rect.width, exampleHeight * arrayLength);

        contentRectTransform.transform.localPosition = Vector3.zero;
        contentRectTransform.sizeDelta = contentSize;
        Destroy(example);
    }
    
    protected void DisableUselessComponents(Image image, Button button)
    {
        image.raycastTarget = false;
        button.interactable = false;
    }

    protected void EnableNecessaryComponents(Image image, Button button)
    {
        image.raycastTarget = true;
        button.interactable = true;
    }
}
