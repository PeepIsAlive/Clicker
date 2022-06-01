using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AchiviementsCreater : ScrollViewElementsCreater
{
    [SerializeField] private Achiviement[] _achiviementsArray;
    private AchiviementsInteractor _interactor;

    public override void Initialize()
    {
        base.Initialize();

        GameController gameController = GetComponentInParent<GameController>();

        if (gameController != null)
        {
            _interactor = gameController.InteractorsBase.GetInteractor<AchiviementsInteractor>();
        }
    }

    public override void OnStart()
    {
        SetElements();
    }

    protected override void SetElements()
    {
        if (base.template == null || _interactor == null) { return; }

        SetSizeDelta(base.template, base.content, _achiviementsArray.Length - _interactor.ReceivedAchiviementsAmount);

        for (int i = 0; i < _achiviementsArray.Length; i++)
        {
            if (!_interactor.isReceivedAchiviements(i))
            {
                GameObject achiviementObject = Instantiate(base.template, base.content.transform);
                Button achiviementButton = achiviementObject.GetComponent<Button>();
                Image achiviementImage = achiviementObject.GetComponent<Image>();

                if (achiviementObject != null)
                {
                    int index = i;
                    achiviementObject.transform.GetChild(0).GetComponent<Image>().sprite = _achiviementsArray[i].Image;
                    achiviementObject.transform.GetChild(1).GetComponent<Text>().text = _achiviementsArray[i].Name;
                    achiviementObject.transform.GetChild(2).GetComponent<Text>().text = _achiviementsArray[i].Description;
                    
                    DisableUselessComponents(achiviementImage, achiviementButton);
                    StartCoroutine(IsAvailableAchRoutine(_achiviementsArray[index], achiviementImage, achiviementButton));

                    achiviementButton.onClick.AddListener(() =>
                    {
                        _interactor.GetAchiviement(index);
                        DisableUselessComponents(achiviementImage, achiviementButton);
                    });
                }
            }
        }
    }

    private IEnumerator IsAvailableAchRoutine(Achiviement achiviement, Image achiviementImage, Button achiviementButton)
    {
        if (achiviement.Value < BankRepository.TotalMoneyAmount)
        {
            EnableNecessaryComponents(achiviementImage, achiviementButton);
            yield break;
        }
        else
        {
            yield return new WaitForSeconds(availableCheckDelay);
            yield return StartCoroutine(IsAvailableAchRoutine(achiviement, achiviementImage, achiviementButton));
        }
    }
}
