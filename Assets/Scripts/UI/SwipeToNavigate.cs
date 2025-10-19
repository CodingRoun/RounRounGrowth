using RounRounGrowth.Building;
using RounRounGrowth.Core;
using UnityEngine;

namespace RounRounGrowth.UI
{
    public class SwipeToNavigate : MonoBehaviour
    {
        [SerializeField] private BuildingNavigator _navigator;

        private void OnEnable() => PageSwipeDetector.OnSwipe += HandleSwipe; 
        private void OnDisable() => PageSwipeDetector.OnSwipe -= HandleSwipe;

        private void HandleSwipe(int dir)
        {
            var current = _navigator.Current;
            var nextRoom = BuildingNavigationTable.GetNextRoomId(current.Floor, current.Room, dir);
            if (nextRoom == null)
            {
                Debug.Log("�ѵ��߽磬�޷���������");
                return;
            }
            _navigator.Show(current.Floor, nextRoom.Value); 
        }
    }

}
