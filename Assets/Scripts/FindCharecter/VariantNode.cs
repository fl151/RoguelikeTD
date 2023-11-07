using UnityEngine;

public class VariantNode
{
    public VariantNode Left { get; private set; }
    public VariantNode Right { get; private set; }
    public GameObject Platform { get; private set; }
    public CharecterType Charecter { get; private set; }

    public VariantNode(GameObject platform)
    {
        Platform = platform;
        Charecter = platform.GetComponentInChildren<Charecter>().CharecterType;
    }

    public void Init(VariantNode left, VariantNode right)
    {
        Left = left;
        Right = right;
    }
}
