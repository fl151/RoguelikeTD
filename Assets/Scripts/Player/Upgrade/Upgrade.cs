using UnityEngine;

//[CreateAssetMenu(fileName = "", menuName = "Upgrade/", order = 51)]
public abstract class Upgrade : ScriptableObject
{
    [SerializeField] protected string _title;
    [SerializeField] protected Sprite _sprite;

    public string Title => _title;
    public Sprite Sprite => _sprite;

    public abstract void Realize();
}