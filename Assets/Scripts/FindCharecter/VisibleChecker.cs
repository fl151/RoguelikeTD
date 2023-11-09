using UnityEngine;

public class VisibleChecker : MonoBehaviour
{
    public bool IsVisible { get; private set; }

    private void OnBecameVisible()
    {
        IsVisible = true;
    }

    private void OnBecameInvisible()
    {
        IsVisible = false;
    }
}
