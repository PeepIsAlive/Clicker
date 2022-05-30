using UnityEngine;

public class GameController : MonoBehaviour
{
    private MoneyController _moneyController;
    private OfflineTimeController _offlineTimeController;
    private AchiviementsCreater _achiviementsCreater;
    private StoreElementsCreater _storeElementsCreater;

    public InteractorsBase InteractorsBase { get; private set; }
    public RepositoriesBase RepositoriesBase { get; private set; }

    private void Awake()
    {
        InteractorsInitialize();
        RepositoriesInitialize();

        ControllersInitialize();
    }

    private void Start()
    {
        ControllersOnStart();
    }

    private bool InteractorsInitialize()
    {
        InteractorsBase = new InteractorsBase();

        if (InteractorsBase != null)
        {
            InteractorsBase.CreateInteractors();
            InteractorsBase.InitializeInteractors();
        }

        return (InteractorsBase != null) ? true : false;
    }

    private bool RepositoriesInitialize()
    {
        if (InteractorsBase == null) { return false; }

        RepositoriesBase = new RepositoriesBase();

        if (RepositoriesBase != null)
        {
            RepositoriesBase.AddRepository<BankRepository>(InteractorsBase.GetInteractor<BankInteractor>());
            RepositoriesBase.AddRepository<AchiviementsRepository>(InteractorsBase.GetInteractor<AchiviementsInteractor>());
        }

        return (RepositoriesBase != null) ? true : false;
    }

    private void ControllersInitialize()
    {
        _moneyController = GetComponentInChildren<MoneyController>();
        _achiviementsCreater = GetComponentInChildren<AchiviementsCreater>();
        _storeElementsCreater = GetComponentInChildren<StoreElementsCreater>();
        _offlineTimeController = GetComponentInChildren<OfflineTimeController>();

        _moneyController.Initialize();
        _achiviementsCreater.Initialize();
        _storeElementsCreater.Initialize();
    }

    private void ControllersOnStart()
    {
        _offlineTimeController.OnStart(_moneyController.ValuePerSeconds);
        _moneyController.OnStart(_offlineTimeController.ValueForOfflineTime);
        _achiviementsCreater.OnStart();
        _storeElementsCreater.OnStart();
    }

#if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            _offlineTimeController.SaveLastSessionDate();
        }
        else
        {
            _offlineTimeController.OnStart(_moneyController.ValuePerSeconds);
            _moneyController.AdditionMoney(_offlineTimeController.ValueForOfflineTime);
        }
    }
#else
    private void OnApplicationQuit()
    {
        _offlineTimeController.SaveLastSessionDate();
    }
#endif
}
