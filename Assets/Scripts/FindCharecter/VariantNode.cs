using UnityEngine;

public class VariantNode
{
    public VariantNode Left { get; private set; }
    public VariantNode Right { get; private set; }
    public GameObject Platform { get; private set; }
    public CharecterInfo CharecterInfo { get; private set; }

    public VariantNode(GameObject platform, CharecterInfo charecterInfo)
    {
        Platform = platform;
        CharecterInfo = charecterInfo;
    }

    public void Init(VariantNode left, VariantNode right)
    {
        Left = left;
        Right = right;   
    }
}
