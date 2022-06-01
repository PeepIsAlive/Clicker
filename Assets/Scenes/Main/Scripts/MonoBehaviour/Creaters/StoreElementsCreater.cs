using System.Collections;
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

        for(int i = 0; i < _storeElementsArray.Length; i++)
        {
            GameObject storeElementObject = Instantiate(base.template, base.content.transform);
            Button storeElementButton = storeElementObject.transform.GetChild(3).GetComponent<Button>();
            Image storeElementImage = storeElementObject.transform.GetChild(3).GetComponent<Image>();

            if (storeElementObject != null) {
                int index = i;
                storeElementObject.transform.GetChild(0).GetComponent<Image>().sprite = _storeElementsArray[index].Image;
                storeElementObject.transform.GetChild(1).GetComponent<Text>().text = _storeElementsArray[index].Name;
                storeElementObject.transform.GetChild(2).GetComponent<Text>().text = _storeElementsArray[index].Description;
            
                DisableUselessComponents(storeElementImage, storeElementButton);
                StartCoroutine(IsAvailableElemRoutine(_storeElementsArray[index], storeElementImage, storeElementButton));

                storeElementButton.onClick.AddListener(() =>
                {
                    DisableUselessComponents(storeElementImage, storeElementButton);
                });
            }
        }
    }

    private IEnumerator IsAvailableElemRoutine(StoreElement storeElement, Image elemImage, Button elemButton)
    {
        if (storeElement.Price < BankRepository.MoneyAmount)
        {
            EnableNecessaryComponents(elemImage, elemButton);
            yield break;
        }
        else
        {
            yield return new WaitForSeconds(availableCheckDelay);
            yield return StartCoroutine(IsAvailableElemRoutine(storeElement, elemImage, elemButton));
        }
    }
}
