// MapInputBlocker.cs

using UnityEngine;
using UnityEngine.EventSystems;

namespace RounRounGrowth.UI
{
    public class MapInputBlocker : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private GameObject blockerPanel;

        void Start()
        {
            Debug.Log($"当前 dragThreshold = {EventSystem.current.pixelDragThreshold}");
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.dragging) return;
            Debug.Log($"[CLICK] 接收到点击事件 - {eventData.pointerId}");
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            
            Debug.Log($"[DRAG-START] 开始拖拽 - {eventData.pointerId}");
        }

        public void OnDrag(PointerEventData eventData)
        {

            Debug.Log($"[DRAG] 拖拽中 - {eventData.delta}");
        }

        public void OnEndDrag(PointerEventData eventData)
        {

            Debug.Log($"[DRAG-END] 结束拖拽 - {eventData.pointerId}");
        }

        public void SetActive(bool state)
        {
            state = false;
            blockerPanel.SetActive(state);
        }
    }
}


