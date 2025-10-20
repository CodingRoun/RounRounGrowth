using UnityEngine;
using RounRounGrowth.Core;
using RounRounGrowth.Building;
using TMPro;

namespace RounRounGrowth.UI
{
    public class TopNavBar : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private GameObject _buttonPrefab;
        [SerializeField] private BuildingNavigator _navigator;

        private void OnEnable()
        {
            if (_navigator == null)
            {
                Debug.LogWarning("[TopNavBar] 未绑定 BuildingNavigator");
                return;
            }
            _navigator.OnRoomChanged += HandleRoomChanged;
            Debug.Log("[TopNavBar] 事件已注册");
        }

        private void OnDisable()
        {
            if (_navigator == null)
            {
                Debug.LogWarning("[TopNavBar] 未绑定 BuildingNavigator");
                return;
            }
            _navigator.OnRoomChanged -= HandleRoomChanged;
            Debug.Log("[TopNavBar] 事件已注销");
        }

        private void HandleRoomChanged(CurrentLocation currentLocation)
        {
            Debug.Log($"[TopNavBar] 当前房间为：{currentLocation.Floor}/{currentLocation.Room}");
        }

        public void GenerateButtons(FloorId floor)
        {
            foreach (Transform child in _container)
                Destroy(child.gameObject); // 清除所有导航栏内的按钮
            var rooms = BuildingNavigationTable.GetRooms(floor); //获得同层所有房间IReadOnlyList<RoomId>
            foreach (var room in rooms)
            {
                var button = Instantiate(_buttonPrefab, _container);
                var text = button.GetComponentInChildren<TMP_Text>();
                text.text = room.ToString();
            }
            Debug.Log($"[TopNavBar] 已生成 {_container.childCount} 个按钮");
        }
    }

}
