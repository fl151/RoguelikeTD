using UnityEngine;

[CreateAssetMenu(menuName = "CharecterInfo", fileName = "CharecterInfo", order = 52)]
public class CharecterInfo : ScriptableObject
{
    [SerializeField] private CharecterType _type;
    [SerializeField] private GameObject _model;
    [SerializeField] private string _name;
    [SerializeField] private string _info;
    [SerializeField] private GameObject _tower1;
    [SerializeField] private GameObject _tower2;

    public CharecterType CharecterType => _type;
    public GameObject Model => _model;
    public string Name => _name;
    public string Info => _info;
    public GameObject Tower1 => _tower1;
    public GameObject Tower2 => _tower2;
}
