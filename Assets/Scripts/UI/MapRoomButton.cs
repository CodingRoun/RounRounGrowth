// MapRoomButton.cs

using UnityEngine;
using RounRounGrowth.Core;
using RounRounGrowth.Building;

namespace RounRounGrowth.UI
{
    public class MapRoomButton : MonoBehaviour
    {
        [SerializeField] private BuildingNavigator navigator;
        [SerializeField] private FloorId floor;
        [SerializeField] private RoomId room;

        public void Onclick()
        {
            if (navigator != null)
                navigator.ConfirmMap(floor, room);
        }
    }
}
