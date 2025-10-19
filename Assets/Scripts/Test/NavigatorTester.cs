using UnityEngine;
using RounRounGrowth.Building;
using RounRounGrowth.Core;

public class NavigatorTester : MonoBehaviour
{
    [SerializeField] private BuildingNavigator navigator;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            navigator.Show(FloorId.F1, RoomId.Lobby);
            Debug.Log("Key is Down");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
            navigator.Show(FloorId.F2, RoomId.Plan);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            navigator.Show(FloorId.F3, RoomId.Gacha);
    }
}
