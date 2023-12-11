using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Level", order = 52)]
public class Level : ScriptableObject
{
    [SerializeField] private int _sceneIndex;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isOpenAsDefault;
    [SerializeField] private Level _nextLevel;

    public int SceneIndex => _sceneIndex;
    public Sprite Icon => _icon;
    public bool OpenAsDefault => _isOpenAsDefault;
    public Level NextLevel => _nextLevel;
}
