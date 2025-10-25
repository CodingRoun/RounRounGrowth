// ElevatorOverlay.cs

using RounRounGrowth.Building;
using UnityEngine;
using UnityEngine.EventSystems;
namespace RounRounGrowth.UI
{
    public class ElevatorOverlay : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private RectTransform _elevatorPanel;
        [SerializeField] private BuildingNavigator _navigator;
        [SerializeField] private MapOverlay _mapOverlay;
        [SerializeField] private ElevatorFloorButton[] _floorButtons;
        private bool _wasMapOpen;

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        private void OnEnable() // 初始化按钮
        {
            foreach (var button in _floorButtons)
                button.Initialize();
            SetButtonHighlight();
        }

        private void Update()
        {
            if (_mapOverlay == null)
            {
                Debug.LogWarning("[ElevatorOverlay] 未绑定 MapOverlay");
                return;
            }
            bool isMapOpen = _mapOverlay.gameObject.activeSelf;
            if (isMapOpen && !_wasMapOpen)
            {
                Debug.Log("[ElevatorOverlay] 检测到地图打开，关闭电梯面板");
                Hide();
            }
            _wasMapOpen = isMapOpen;
                
        }

        

        public void OnPointerClick(PointerEventData eventData) // 如点击在ElevatorPanel外，则关闭ElevatorOverlay
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

        private void SetButtonHighlight()
        {
            foreach (var button in _floorButtons)
            {
                button.SetHighlight();
            }
        }
    }
}


