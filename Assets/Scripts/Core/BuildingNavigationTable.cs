// BuildingNavigationTable.cs

using System;
using System.Collections.Generic;

namespace RounRounGrowth.Core
{
    public static class BuildingNavigationTable
    {
        private static readonly Dictionary<FloorId, RoomId[]> _roomOrder = new()
        {
            { FloorId.F1, new[] {RoomId.Lobby, RoomId.Mood} },
            { FloorId.F2, new[] {RoomId.Plan, RoomId.Schedule, RoomId.Focus} },
            { FloorId.F3, new[] {RoomId.Gacha, RoomId.Toilet} },
            { FloorId.F4, new[] {RoomId.Boss, RoomId.Settings} },
        };

        private static readonly Dictionary<FloorId, RoomId> _defaultRoomId = new()
        {
            {FloorId.F1, RoomId.Lobby},
            {FloorId.F2, RoomId.Plan},
            {FloorId.F3, RoomId.Gacha},
            {FloorId.F4, RoomId.Boss},
        };

        public static IReadOnlyList<RoomId> GetRooms(FloorId floor)
        {
            return _roomOrder[floor];
        }
        public static RoomId GetDefaultRoom(FloorId floor)
        {
            return _defaultRoomId[floor];
        }

        public static RoomId? GetNextRoomId(FloorId currentFloor, RoomId currentRoom, int dir)//dir用于改变方向，为+1或-1
        {
            RoomId[] list = _roomOrder[currentFloor];
            int index = Array.IndexOf(list, currentRoom);
            int nextIndex = index + dir;

            if (nextIndex < 0 || nextIndex > list.Length - 1)
            {
                return null;
            }
            return list[nextIndex];
        }
    }
}
