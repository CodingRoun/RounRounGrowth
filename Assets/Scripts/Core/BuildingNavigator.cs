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

        private bool _HasShown = false; // ���Start�Ƿ��Ѿ�ִ�й�Show
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
                return; //����֡������Ŀ�귿�䣬ֱ�ӷ���
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

        // ��Map����Map�ǲ㣬����ԭ����RoomPanel�ڸǲ���
        public void OpenMap()
        {
            if (IsMapOpen) return; 
            _mapPanel.SetActive(true);
        }

        // ��Map���ص���δѡ���κη��䣺�رոǲ�
        public void CancelMap()
        {
            if (!IsMapOpen) return;
            _mapPanel.SetActive(false);
        }

        //��Map��ѡ���˷��䣺��ҳ���ر�Map
        public void ConfirmMap(FloorId floor, RoomId room)
        {
            if (!IsMapOpen) return;
            Show(floor, room);
            _mapPanel.SetActive(false);
        }
    }
}


