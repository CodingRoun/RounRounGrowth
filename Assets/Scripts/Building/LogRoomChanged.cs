//LogRoomChanged.cs

using RounRounGrowth.Core;
using UnityEngine;
using UnityEngine.UI;

namespace RounRounGrowth.Building
{
    public class LogRoomChanged : MonoBehaviour
    {
        [SerializeField] private BuildingNavigator navigator;
        private void OnEnable()
        {
            if (navigator != null)
            {
                navigator.OnRoomChanged += HandleCurrentLoc;
            }
                
        }

        private void OnDisable()
        {
            if (navigator != null)
            {
                navigator.OnRoomChanged -= HandleCurrentLoc;
            }
        }

        public void HandleCurrentLoc(CurrentLocation loc)
        {
            Debug.Log($"[OnRoomChanged] Now at {loc.Floor}/{loc.Room}");
        }
    }
}
