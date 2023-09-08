using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Charecter
{
    Mage,
    Warrior,
    Summoner
}

public class PlayerCharecter : MonoBehaviour
{
    [SerializeField] private Charecter _charecter;

    public Charecter Charecter => _charecter;
}
