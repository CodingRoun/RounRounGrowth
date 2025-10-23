// PageSwipeDetector.cs

using UnityEngine;
using UnityEngine.EventSystems;

namespace RounRounGrowth.UI
{
    public class PageSwipeDetector : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private Vector2 _startPos;
        private const float SwipeThreshold = 100f;
        public static event System.Action<int> OnSwipe;

        public void OnPointerDown(PointerEventData eventData)
        {
            _startPos = eventData.position;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Vector2 endPos = eventData.position; 
            float deltaX = endPos.x - _startPos.x;
            if (Mathf.Abs(deltaX) < SwipeThreshold)
                return; // ºöÂÔ¶Ì»¬¶¯
            int dir = deltaX > 0 ? -1 : 1;
            Debug.Log($"Swipe {(dir > 0 ? "Prev" : "Next")}");
            OnSwipe?.Invoke(dir);
        }
    }
}

