//MapGestureSimulator.cs

using UnityEngine;
using RounRounGrowth.Building;

namespace RounRounGrowth.UI
{
    public class MapGestureSimulator : MonoBehaviour
    {
        [SerializeField] private BuildingNavigator navigator;

        private void Update()
        {
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.M))
            {
                if (!navigator.IsMapOpen)
                    navigator.OpenMap();
                else
                    Debug.Log("Map已打开，重复捏合无效");
            }
        }
    }
}


