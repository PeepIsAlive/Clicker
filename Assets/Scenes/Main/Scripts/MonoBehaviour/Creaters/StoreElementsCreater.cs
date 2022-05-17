using UnityEngine;
using UnityEngine.UI;

public class StoreElementsCreater : ScrollViewElementsCreater
{
    [SerializeField] private StoreElement[] _storeElementsArray;

    public override void OnStart()
    {
        SetElements();
    }

    protected override void SetElements()
    {
        if (base.template == null) { return; }

        SetSizeDelta(base.template, base.content, _storeElementsArray.Length);

        foreach (StoreElement storeElement in _storeElementsArray)
        {
            GameObject storeElementObject = Instantiate(base.template, base.content.transform);

            storeElementObject.transform.GetChild(0).GetComponent<Image>().sprite = storeElement.Image;
            storeElementObject.transform.GetChild(1).GetComponent<Text>().text = storeElement.Name;
            storeElementObject.transform.GetChild(2).GetComponent<Text>().text = storeElement.Description;
        }
    }
}
