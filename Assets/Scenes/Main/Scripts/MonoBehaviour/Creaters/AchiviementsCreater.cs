using UnityEngine;
using UnityEngine.UI;

public class AchiviementsCreater : ScrollViewElementsCreater
{
    [SerializeField] private Achiviement[] _achiviementsArray;

    public override void OnStart()
    {
        SetElements();
    }

    protected override void SetElements()
    {
        if (base.template == null) { return; }

        SetSizeDelta(base.template, base.content, _achiviementsArray.Length);

        foreach (Achiviement achiviement in _achiviementsArray)
        {
            GameObject achiviementObject = Instantiate(base.template, base.content.transform);

            achiviementObject.transform.GetChild(0).GetComponent<Image>().sprite = achiviement.Image;
            achiviementObject.transform.GetChild(1).GetComponent<Text>().text = achiviement.Name;
            achiviementObject.transform.GetChild(2).GetComponent<Text>().text = achiviement.Description;
        }
    }
}
