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
            Debug.Log($"��ǰ dragThreshold = {EventSystem.current.pixelDragThreshold}");
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.dragging) return;
            Debug.Log($"[CLICK] ���յ�����¼� - {eventData.pointerId}");
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            
            Debug.Log($"[DRAG-START] ��ʼ��ק - {eventData.pointerId}");
        }

        public void OnDrag(PointerEventData eventData)
        {

            Debug.Log($"[DRAG] ��ק�� - {eventData.delta}");
        }

        public void OnEndDrag(PointerEventData eventData)
        {

            Debug.Log($"[DRAG-END] ������ק - {eventData.pointerId}");
        }

        public void SetActive(bool state)
        {
            state = false;
            blockerPanel.SetActive(state);
        }
    }
}

