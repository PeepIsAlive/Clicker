public class AchiviementsInteractor : Interactor
{
    private AchiviementsRepository _repository;

    public override Repository Repository => _repository;
    public int ReceivedAchiviementsAmount => _repository.ReceivedAchiviementsAmount;

    public override Repository Initialize()
    {
        _repository = new AchiviementsRepository();

        if (_repository != null)
        {
            _repository.Initialize();
        }

        return _repository;
    }

    public bool isReceivedAchiviements(int i) => _repository.isReceivedAchiviements(i);

    public void GetAchiviement(int i)
    {
        _repository.SetValue(i);
    }
}
