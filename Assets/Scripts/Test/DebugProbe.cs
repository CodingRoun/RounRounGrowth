using RounRounGrowth.Core;
using UnityEngine;

public class DebugProbe : MonoBehaviour
{
    void Start()
    {
        var rooms = BuildingNavigationTable.GetRooms(FloorId.F2);
        Debug.Log(string.Join(",", rooms));

        var next = BuildingNavigationTable.GetNextRoomId(FloorId.F2, RoomId.Plan, +1);
        Debug.Log(next);
    }
}

