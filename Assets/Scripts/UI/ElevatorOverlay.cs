// ElevatorOverlay.cs

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace RounRounGrowth.UI
{
    public class ElevatorOverlay : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private RectTransform _elevatorPanel;

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_elevatorPanel == null)
            {
                Debug.LogWarning("[ElevatorOverlay] 未绑定 ElevatorPanel");
                return;
            }
            bool isClickOutsidePanel = !RectTransformUtility.RectangleContainsScreenPoint(
                _elevatorPanel, 
                eventData.position
                );
            bool isPanelShown = gameObject.activeSelf;
            if (isPanelShown && isClickOutsidePanel)
                Hide();
        }

        public void Show() // 打开电梯菜单
        {
            gameObject.SetActive(true);
        }

        public void Hide() // 关闭电梯菜单
        {
            gameObject.SetActive(false);
        }
    }
}

