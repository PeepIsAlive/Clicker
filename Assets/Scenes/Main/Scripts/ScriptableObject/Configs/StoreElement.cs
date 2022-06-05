using UnityEngine;

[CreateAssetMenu(fileName = "New store element", menuName = "Config/StoreElement", order = 52)]
public class StoreElement : ScriptableObject
{
    [SerializeField] private Sprite _image;
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private int _price;
    [SerializeField] private int _addedClickValue;
    [SerializeField] private int _addedValuePerSecond;

    public Sprite Image => _image;
    public string Name => _name;
    public string Description => _description;
    public int Price => _price;
    public int AddedClickValue => _addedClickValue;
    public int AddedValuePerSecond => _addedValuePerSecond;
}
