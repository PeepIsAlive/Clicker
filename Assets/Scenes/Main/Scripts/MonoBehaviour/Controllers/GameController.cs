using UnityEngine;

public class GameController : MonoBehaviour
{
    private InteractorsBase _interactorsBase;
    private RepositoriesBase _repositoriesBase;

    private MoneyController _moneyController;
    private DisplayValueUpdater _displayValueUpdater;
    private OfflineTimeController _offlineTimeController;
    private AchiviementsCreater _achiviementsCreater;
    private StoreElementsCreater _storeElementsCreater;

    public InteractorsBase InteractorsBase => _interactorsBase;
    public RepositoriesBase RepositoriesBase => _repositoriesBase;

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
        _interactorsBase = new InteractorsBase();

        if (_interactorsBase != null)
        {
            _interactorsBase.CreateInteractors();
            _interactorsBase.InitializeInteractors();
        }

        return (_interactorsBase != null) ? true : false;
    }

    private bool RepositoriesInitialize()
    {
        if (_interactorsBase == null) { return false; }

        _repositoriesBase = new RepositoriesBase();

        if (_repositoriesBase != null)
        {
            _repositoriesBase.AddRepository<BankRepository>(_interactorsBase.GetInteractor<BankInteractor>());
        }

        return (_repositoriesBase != null) ? true : false;
    }

    private void ControllersInitialize()
    {
        _moneyController = GetComponentInChildren<MoneyController>();
        _displayValueUpdater = GetComponentInChildren<DisplayValueUpdater>();
        _achiviementsCreater = GetComponentInChildren<AchiviementsCreater>();
        _storeElementsCreater = GetComponentInChildren<StoreElementsCreater>();
        _offlineTimeController = GetComponentInChildren<OfflineTimeController>();

        _moneyController.Initialize();
        _displayValueUpdater.Initialize();
        _achiviementsCreater.Initialize();
        _storeElementsCreater.Initialize();
    }

    private void ControllersOnStart()
    {
        _offlineTimeController.OnStart(_moneyController.ValuePerSeconds);
        _moneyController.OnStart(_offlineTimeController.ValueForOfflineTime);
        _displayValueUpdater.OnStart();
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
