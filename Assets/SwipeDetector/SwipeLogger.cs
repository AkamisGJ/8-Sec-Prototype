using UnityEngine;

public class SwipeLogger : MonoBehaviour
{
    [SerializeField] private bool logging;
    private void Awake() 
    {
        SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;
    }

    private void SwipeDetector_OnSwipe(SwipeData data)
    {
        if (logging)
        {
            Debug.Log("Swipe in Direction: " + data.Direction);
        }
    }
}