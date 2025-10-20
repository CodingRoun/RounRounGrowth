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
                Debug.LogWarning("[TopNavBar] δ�� BuildingNavigator");
                return;
            }
            _navigator.OnRoomChanged += HandleRoomChanged;
            Debug.Log("[TopNavBar] �¼���ע��");
        }

        private void OnDisable()
        {
            if (_navigator == null)
            {
                Debug.LogWarning("[TopNavBar] δ�� BuildingNavigator");
                return;
            }
            _navigator.OnRoomChanged -= HandleRoomChanged;
            Debug.Log("[TopNavBar] �¼���ע��");
        }

        private void HandleRoomChanged(CurrentLocation currentLocation)
        {
            HighlightCurrentRoom(currentLocation.Room); // ͬ¥��ʱ�����¸���
            if (_lastFloor == currentLocation.Floor && _hasGenerated == true) // �����ͬ¥���Ҵ�ǰ�����ɰ�ť�����������ɰ�ť
                return;
            _lastFloor = currentLocation.Floor; // ���¥��仯�����������ɶ�Ӧ¥��İ�ť����������ǰ����
            GenerateButtons(currentLocation.Floor);
            HighlightCurrentRoom(currentLocation.Room);
            _hasGenerated = true;
        }

        public void GenerateButtons(FloorId floor) 
        {
            foreach (Transform child in _container)
                Destroy(child.gameObject); // ������е������ڵİ�ť
            var rooms = BuildingNavigationTable.GetRooms(floor); //���ͬ�����з���IReadOnlyList<RoomId>
            foreach (var room in rooms)
            {
                var button = Instantiate(_buttonPrefab, _container);
                var topNavButton = button.GetComponent<TopNavButton>();
                topNavButton.Initialize(room, room.ToString());
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
