using UnityEngine;
using UnityEngine.UI;

public class AchiviementsController : MonoBehaviour
{
    [SerializeField] private GameObject _achiviementTemplate;
    [SerializeField] private GameObject _content;
    [SerializeField] private Achiviement[] _achiviementsArray;
    private Animator _animator;

    public void Initialize()
    {
        if (_content != null)
        {
            RectTransform rectTransform = _content.GetComponent<RectTransform>();
            _animator = GetComponent<Animator>();
            rectTransform.transform.localPosition = Vector3.zero;
        }
    }

    public void OnStart()
    {
        SetAchiviements();
    }

    public void Open()
    {
        if (_animator == null) { return; }

        _animator.enabled = true;
        _animator.SetTrigger("Open");
    }

    public void Close()
    {
        if (_animator == null) { return; }

        _animator.SetTrigger("Close");
    }

    public void OnClose()
    {
        _animator.enabled = false;
    }

    private void SetAchiviements()
    {
        if (_achiviementTemplate == null) { return; }

        SetSizeDelta(_achiviementTemplate, _content);

        foreach (Achiviement achiviement in _achiviementsArray)
        {
            GameObject achiviementObject = Instantiate(_achiviementTemplate, _content.transform);

            achiviementObject.transform.GetChild(0).GetComponent<Image>().sprite = achiviement.Image;
            achiviementObject.transform.GetChild(1).GetComponent<Text>().text = achiviement.Name;
            achiviementObject.transform.GetChild(2).GetComponent<Text>().text = achiviement.Description;
        }
    }

    private void SetSizeDelta(GameObject template, GameObject content)
    {
        if (template == null || content == null) { return; }

        GameObject example = Instantiate(template, content.transform);
        RectTransform contentRectTransform = content.GetComponent<RectTransform>();
        float exampleHeight = example.GetComponent<RectTransform>().rect.height;
        Vector2 contentSize = new Vector2(contentRectTransform.rect.width, exampleHeight * _achiviementsArray.Length);

        contentRectTransform.transform.localPosition = Vector3.zero;
        contentRectTransform.sizeDelta = contentSize;
        Destroy(example);
    }
}
