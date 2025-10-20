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
            Debug.Log($"[TopNavBar] ��ǰ����Ϊ��{currentLocation.Floor}/{currentLocation.Room}");
        }
    }

}
