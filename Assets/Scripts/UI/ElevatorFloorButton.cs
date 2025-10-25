// ElevatorFloorButton.cs

using RounRounGrowth.Building;
using RounRounGrowth.Core;
using UnityEngine.UI;
using UnityEngine;

namespace RounRounGrowth.UI
{
    public class ElevatorFloorButton : MonoBehaviour
    {
        [SerializeField] private FloorId _floorId;
        [SerializeField] private BuildingNavigator _navigator;
        [SerializeField] private ElevatorOverlay _elevatorOverlay;
        [SerializeField] private Image _background;

        public void Initialize()
        {
            GetComponent<Button>().onClick.AddListener(OnClicked);
        }
        public void SetHighlight()
        {
            bool isCurrentFloor = _floorId == _navigator.Current.Floor;
            _background.color = isCurrentFloor ? new Color(1f, 0.95f, 0.6f) : Color.white;
        }

        private void OnClicked()
        {
            if (_navigator == null)
            {
                Debug.LogWarning("[ElevatorFloorButton] 未绑定 BuildingNavigator");
                return;
            }
            if (_floorId == _navigator.Current.Floor)
                return;
            RoomId defaultRoom = BuildingNavigationTable.GetDefaultRoom(_floorId);
            _navigator.Show(_floorId, defaultRoom);
            _elevatorOverlay.Hide();
            Debug.Log($"已切换至楼层 {_floorId} 的默认房间: {defaultRoom}");
        }
    }
}



