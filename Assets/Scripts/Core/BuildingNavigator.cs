// BuildingNavigator.cs

using RounRounGrowth.Core;
using System;
using UnityEngine;

namespace RounRounGrowth.Building
{
    public class BuildingNavigator : MonoBehaviour
    {
        public CurrentLocation Current { get; private set; }
        public CurrentLocation? ReturnTo { get; set; }
        private static readonly FloorId FirstFloor = FloorId.F1;
        private static readonly RoomId FirstRoom = BuildingNavigationTable.GetDefaultRoom(FirstFloor);

        public event Action<CurrentLocation> OnRoomChanged;


        [Header("Scene References")]
        [SerializeField] private BuildingManager _manager;
        [SerializeField] private GameObject _mapPanel;

        private bool _HasShown = false; // 检查Start是否已经执行过Show
        public bool IsMapOpen
            => _mapPanel != null && _mapPanel.activeSelf;

        private void Start()
        {
            _mapPanel.SetActive(false);
            Show(FirstFloor, FirstRoom);
        }

        public void Show(FloorId floor, RoomId room)
        {
            if (_HasShown && Current.Floor == floor && Current.Room == room)
                return; //非首帧且已在目标房间，直接返回
            _manager.DeactivateAll();
            _manager.ActivateTarget(floor, room);
            AfterSwitch(new CurrentLocation(floor, room));
            _HasShown = true;
        }

        public void AfterSwitch(CurrentLocation newLoc)
        {
            Current = newLoc;
            OnRoomChanged?.Invoke(Current);
        }

        // 打开Map：打开Map盖层，保留原来的RoomPanel在盖层下
        public void OpenMap()
        {
            if (IsMapOpen) return; 
            _mapPanel.SetActive(true);
        }

        // 从Map返回但是未选择任何房间：关闭盖层
        public void CancelMap()
        {
            if (!IsMapOpen) return;
            _mapPanel.SetActive(false);
        }

        //在Map中选择了房间：切页并关闭Map
        public void ConfirmMap(FloorId floor, RoomId room)
        {
            if (!IsMapOpen) return;
            Show(floor, room);
            _mapPanel.SetActive(false);
        }
    }
}


