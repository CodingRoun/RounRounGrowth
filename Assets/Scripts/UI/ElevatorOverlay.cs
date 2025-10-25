// ElevatorOverlay.cs

using RounRounGrowth.Building;
using RounRounGrowth.Core;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace RounRounGrowth.UI
{
    public class ElevatorOverlay : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private RectTransform _elevatorPanel;
        [SerializeField] private BuildingNavigator _navigator;
        [SerializeField] private FloorButtonRef[] _floorButtonRefs;
        [SerializeField] private MapOverlay _mapOverlay;
        private bool _wasMapOpen;

        [System.Serializable]
        public class FloorButtonRef
        {
            public FloorId Floor;
            public Button Button;
        }

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            if (_floorButtonRefs == null || _floorButtonRefs.Length == 0)
            {
                Debug.LogWarning("[ElevatorOverlay] 未绑定楼层按钮引用");
                return;
            }
            foreach (var floorButtonRef in _floorButtonRefs)
            {
                if (floorButtonRef == null || floorButtonRef.Button == null)
                {
                    Debug.LogWarning("[ElevatorOverlay] 某个 FloorButtonRef 未绑定");
                    continue;
                }

                floorButtonRef.Button.onClick.RemoveAllListeners(); // 防止重复绑定
                floorButtonRef.Button.onClick.AddListener(() =>
                {
                    OnFloorButtonClicked(floorButtonRef.Floor);
                });
                SetHighlight(_navigator.Current, floorButtonRef); // 因为广播时处于隐藏状态，无法订阅事件，所以主动获取当前位置
            }
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
        private void SetHighlight(CurrentLocation currentLocation, FloorButtonRef floorButtonRef)
        {
            bool isCurrentFloor = floorButtonRef.Floor == currentLocation.Floor;
            floorButtonRef.Button.image.color = isCurrentFloor ? new Color(1f, 0.95f, 0.6f) : Color.white;
        }

        private void OnFloorButtonClicked(FloorId targetFloor)
        {
            if (_navigator == null)
            {
                Debug.LogWarning("[ElevatorOverlay] 未绑定 BuildingNavigator");
                return;
            }
            if (targetFloor == _navigator.Current.Floor) // 这里又没使用订阅获取，什么时候使用订阅，什么时候主动获取？
                return;
            RoomId defaultRoom = BuildingNavigationTable.GetDefaultRoom(targetFloor);
            _navigator.Show(targetFloor, defaultRoom);
            Hide();
            Debug.Log($"已切换至楼层 {targetFloor} 的默认房间: {defaultRoom}");
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
    }
}

