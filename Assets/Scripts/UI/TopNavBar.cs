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
        private FloorId _lastFloor;
        private bool _hasGenerated => _lastFloor != default;

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
            if (_lastFloor == currentLocation.Floor && _hasGenerated == true)
                return;
            _lastFloor = currentLocation.Floor;
            GenerateButtons(currentLocation.Floor);
        }

        public void GenerateButtons(FloorId floor)
        {
            foreach (Transform child in _container)
                Destroy(child.gameObject); // ������е������ڵİ�ť
            var rooms = BuildingNavigationTable.GetRooms(floor); //���ͬ�����з���IReadOnlyList<RoomId>
            foreach (var room in rooms)
            {
                var button = Instantiate(_buttonPrefab, _container);
                var text = button.GetComponentInChildren<TMP_Text>();
                text.text = room.ToString();
            }
        }
    }

}
