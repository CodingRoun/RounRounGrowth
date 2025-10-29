// BuildingTypes.cs

using System;

namespace RounRounGrowth.Core
{
    public enum FloorId { F1, F2, F3, F4 };
    public enum RoomId { Lobby, Mood, Plan, Schedule, Focus, Gacha, Toilet, Boss, Settings };

    public readonly struct CurrentLocation
    {
        public FloorId Floor { get; }
        public RoomId Room { get; }

        public CurrentLocation(FloorId floor, RoomId room)
        {
            Floor = floor;
            Room = room;
        }

        public override string ToString() => $"{Floor}/{Room}";
    }
}
