using UnityEngine;

public class Charecter : MonoBehaviour
{
    [SerializeField] private CharecterType _type;

    public CharecterType CharecterType => _type;
}
