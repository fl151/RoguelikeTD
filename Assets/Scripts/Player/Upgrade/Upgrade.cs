using UnityEngine;
using UnityEngine.Events;

//[CreateAssetMenu(fileName = "", menuName = "Upgrade/", order = 51)]
public abstract class Upgrade : ScriptableObject
{
    [SerializeField] protected string _title;
    [SerializeField] protected Sprite _sprite;

    public string Title => _title;
    public Sprite Sprite => _sprite;

    public abstract void Realize();

    public event UnityAction<string> TitleChanged;

    public void SetTitle(string newTitle)
    {
        _title = newTitle;
        TitleChanged?.Invoke(_title);
    }
}
