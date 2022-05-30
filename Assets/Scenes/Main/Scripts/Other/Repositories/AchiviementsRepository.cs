using UnityEngine;

public class AchiviementsRepository : Repository
{
    private readonly string[] _keys = new string[6] {
        "1Ach", "2Ach", "3Ach", "4Ach", "5Ach", "6Ach"};
    private int[] _isReceivedAch = new int[6];

    public int ReceivedAchiviementsAmount { get; private set; }

    public void SetValue(int i)
    {
        Save(i);
    }

    public override void Initialize()
    {
        ReceivedAchiviementsAmount = 0;

        for(int i = 0; i < _keys.Length; i++)
        {
            _isReceivedAch[i] = (PlayerPrefs.HasKey(_keys[i])) ? PlayerPrefs.GetInt(_keys[i]) : 0;

            if (_isReceivedAch[i] == 1) { ReceivedAchiviementsAmount++; }
        }
    }

    public bool isReceivedAchiviements(int i) => (_isReceivedAch[i] == 0) ? false : true;

    protected override void Save(int i)
    {
        PlayerPrefs.SetInt(_keys[i], 1);
        ReceivedAchiviementsAmount++;
    }
}
