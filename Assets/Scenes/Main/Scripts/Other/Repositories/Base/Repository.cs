public abstract class Repository
{
    public abstract void Initialize();
    protected virtual void Save() { }
    protected virtual void Save(string key, int value) { }
}
