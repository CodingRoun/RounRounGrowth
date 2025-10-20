using UnityEngine;
using RounRounGrowth.Core;
using RounRounGrowth.Building;

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
    }

}
