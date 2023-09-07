using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeViewData", menuName = "UpgradeViewData", order = 51)]
public class ViewData : ScriptableObject
{
    [SerializeField] private string _title;
    [SerializeField] private Sprite _sprite;

    public string Title => _title;
    public Sprite Sprite => _sprite;
}
