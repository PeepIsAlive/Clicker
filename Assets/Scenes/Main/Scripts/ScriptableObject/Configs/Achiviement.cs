using UnityEngine;

[CreateAssetMenu(fileName = "New achiviement", menuName = "Config/Achiviement", order = 52)]
public class Achiviement : ScriptableObject
{
    [SerializeField] private Sprite _image;
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private int _value;

    public Sprite Image => _image;
    public string Name => _name;
    public string Description => _description;
    public int Value => _value;
}
