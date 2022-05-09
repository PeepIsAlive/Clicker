using UnityEngine;

[CreateAssetMenu(fileName = "New achiviement", menuName = "Config/Achiviement", order = 52)]
public class Achiviement : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _image;

    public string Name => _name;
    public string Description => _description;
    public Sprite Image => _image;
}
