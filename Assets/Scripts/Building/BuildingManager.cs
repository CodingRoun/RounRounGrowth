// BuildingManager.cs

using System.Collections.Generic;
using UnityEngine;
using RounRounGrowth.Core;

namespace RounRounGrowth.Building
{
    public class BuildingManager : MonoBehaviour
    {
        [SerializeField] private List<FloorPanels> _floors;
        private Dictionary<(FloorId, RoomId), GameObject> _lookup;

        private void Awake()
        {
            _lookup = new();
            if (_floors == null) return;

            foreach (var floor in _floors)
            {
                foreach (var roomPanelRef in floor.RoomPanels)
                {
                    if (roomPanelRef == null) continue;
                    var value = roomPanelRef.Panel;
                    if (value == null) continue;
                    var key = (floor.Floor, roomPanelRef.Room);
                    if (_lookup.ContainsKey(key))
                    {
                        Debug.LogWarning($"Duplicate mapping: {key}");
                        continue;
                    }
                    if (_lookup.ContainsValue(value))
                    {
                        Debug.LogWarning($"Panel {value} is already used by another room.");
                        continue;
                    }
                    _lookup[key] = value;
                }
            }
            Debug.Log($"[BuildingNavigator] lookup count = {_lookup.Count}");
        }

        public bool TryGetPanel(FloorId floor, RoomId room, out GameObject panel)
        {
            if (_lookup == null)
            {
                panel = null;
                return false;
            }
            return _lookup.TryGetValue((floor, room), out panel);
        }

        public void DeactivateAll()
        {
            foreach (var panel in _lookup.Values)
            {
                if (panel == null) continue;
                panel.SetActive(false);
            }
        }
        public void ActivateTarget(FloorId floor, RoomId room)
        {
            TryGetPanel(floor, room, out var panel);
            panel.SetActive(true);
        }
    }

    [System.Serializable]
    public class RoomPanelRef
    {
        public RoomId Room;
        public GameObject Panel;
    }

    [System.Serializable]
    public class FloorPanels
    {
        public FloorId Floor;
        public RoomPanelRef[] RoomPanels;
    }

}
