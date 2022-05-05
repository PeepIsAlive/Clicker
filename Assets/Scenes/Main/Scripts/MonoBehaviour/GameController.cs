using UnityEngine;

public class GameController : MonoBehaviour
{
    private InteractorsBase _interactorsBase;
    private RepositoriesBase _repositoriesBase;

    public InteractorsBase InteractorsBase => _interactorsBase;
    public RepositoriesBase RepositoriesBase => _repositoriesBase;

    private void Awake()
    {
        InteractorsInitialize();
        RepositoriesInitialize();
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
}
