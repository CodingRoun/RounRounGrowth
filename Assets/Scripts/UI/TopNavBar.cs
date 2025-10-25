// TopNavBar.cs

using UnityEngine;
using RounRounGrowth.Core;
using RounRounGrowth.Building;
using TMPro;
using UnityEngine.UI;

namespace RounRounGrowth.UI
{
    public class TopNavBar : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private GameObject _buttonPrefab;
        [SerializeField] private BuildingNavigator _navigator;
        private FloorId _lastFloor;
        private bool _hasGenerated = false;

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
            HighlightCurrentRoom(currentLocation.Room); // 同楼层时，更新高亮
            if (_lastFloor == currentLocation.Floor && _hasGenerated == true) // 如果在同楼层且此前已生成按钮，则不重新生成按钮
                return;
            _lastFloor = currentLocation.Floor; // 如果楼层变化，则重新生成对应楼层的按钮，并高亮当前房间
            GenerateButtons(currentLocation.Floor);
            HighlightCurrentRoom(currentLocation.Room);
            _hasGenerated = true;
        }

        public void GenerateButtons(FloorId floor) 
        {
            foreach (Transform child in _container)
                Destroy(child.gameObject); // 清除所有导航栏内的按钮
            var rooms = BuildingNavigationTable.GetRooms(floor); //获得同层所有房间IReadOnlyList<RoomId>
            foreach (var room in rooms)
            {
                var button = Instantiate(_buttonPrefab, _container); 
                var topNavButton = button.GetComponent<TopNavButton>();
                topNavButton.Initialize(room, room.ToString(), _navigator);
            }
        }

        private void HighlightCurrentRoom(RoomId currentRoom)
        {
            foreach (Transform child in _container)
            {
                var topNavButton = child.GetComponent<TopNavButton>();
                topNavButton.SetHighlight(topNavButton.RoomId == currentRoom);
            }
        }
    }
}

