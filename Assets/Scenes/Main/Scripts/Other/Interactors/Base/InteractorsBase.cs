using System;
using System.Collections.Generic;

public class InteractorsBase
{
    private Dictionary<Type, Interactor> _interactorsDict;

    public int InteractorsAmount => _interactorsDict.Count;

    public InteractorsBase()
    {
        _interactorsDict = new Dictionary<Type, Interactor>();
    }

    public T GetInteractor<T>() where T : Interactor => (T) _interactorsDict[typeof(T)];

    public void CreateInteractors()
    {
        if (_interactorsDict == null) { return; }

        CreateInteractor<BankInteractor>();
    }

    public void InitializeInteractors()
    {
        foreach (Interactor interactor in _interactorsDict.Values)
        {
            interactor.Initialize();
        }
    }

    private void CreateInteractor<T>() where T : Interactor, new()
    {
        var interactor = new T();
        var type = typeof(T);

        _interactorsDict.Add(type, interactor);
    }
}
