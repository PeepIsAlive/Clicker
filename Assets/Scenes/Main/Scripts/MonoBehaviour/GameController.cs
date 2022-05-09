using UnityEngine;

public class GameController : MonoBehaviour
{
    private InteractorsBase _interactorsBase;
    private RepositoriesBase _repositoriesBase;

    private MoneyController _moneyController;
    private ValueController _valueController;
    private OfflineTimeController _offlineTimeController;
    private AchiviementsController _achiviementsController;

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
        _valueController = GetComponentInChildren<ValueController>();
        _achiviementsController = GetComponentInChildren<AchiviementsController>();
        _offlineTimeController = GetComponentInChildren<OfflineTimeController>();

        _moneyController.Initialize();
        _valueController.Initialize();
        _achiviementsController.Initialize();
    }

    private void ControllersOnStart()
    {
        _offlineTimeController.OnStart(_moneyController.ValuePerSeconds);
        _moneyController.OnStart(_offlineTimeController.ValueForOfflineTime);
        _valueController.OnStart();
        _achiviementsController.OnStart();
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
