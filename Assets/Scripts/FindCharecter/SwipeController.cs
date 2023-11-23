using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SwipeController : MonoBehaviour
{
    [SerializeField] private Button _leftSwipeButton;
    [SerializeField] private Button _rightSwipeButton;
    [SerializeField] private PlatformsController _platformsController;

    private Queue<Swipe> _swipes = new Queue<Swipe>();

    public event UnityAction<Swipe> OnSwipe;

    private void OnEnable()
    {
        _leftSwipeButton.onClick.AddListener(OnLeftSwipe);
        _rightSwipeButton.onClick.AddListener(OnRightSwipe);
        _platformsController.SwipeFinished += OnLastSwipeFinished;
    }

    private void OnDisable()
    {
        _leftSwipeButton.onClick.RemoveListener(OnLeftSwipe);
        _rightSwipeButton.onClick.RemoveListener(OnRightSwipe);
        _platformsController.SwipeFinished -= OnLastSwipeFinished;
    }

    private void OnRightSwipe()
    {
        AddSwipe(Swipe.Right);
    }

    private void OnLeftSwipe()
    {
        AddSwipe(Swipe.Left);
    }

    private void OnLastSwipeFinished()
    {
        if (_swipes.Count > 0)
            _swipes.Dequeue();

        if (_swipes.Count > 0)
            OnSwipe?.Invoke(_swipes.Peek());
    }

    private void AddSwipe(Swipe swipe)
    {
        if (_swipes.Count < 2)
        {
            _swipes.Enqueue(swipe);
        }

        if (_swipes.Count == 1)
        {
            OnSwipe?.Invoke(swipe);
        }
    }
}
