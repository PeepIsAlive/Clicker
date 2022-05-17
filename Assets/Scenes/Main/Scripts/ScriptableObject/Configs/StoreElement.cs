using UnityEngine;

public class StoreElement : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _image;
    [SerializeField] private int _price;

    public string Name => _name;
    public string Description => _description;
    public Sprite Image => _image;
    public int Price => _price;
}
