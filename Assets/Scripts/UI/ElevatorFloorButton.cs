// ElevatorFloorButton.cs

using RounRounGrowth.Building;
using RounRounGrowth.Core;
using UnityEngine.UI;
using UnityEngine;

namespace RounRounGrowth.UI
{
    public class ElevatorFloorButton : MonoBehaviour
    {
        [SerializeField] private FloorId _floorId;
        [SerializeField] private BuildingNavigator _navigator;
        [SerializeField] private ElevatorOverlay _elevatorOverlay;
        [SerializeField] private Image _background;
        private Button _button;

        public void Awake()
        {
            _button = GetComponent<Button>();
            if (!ValidateBindings()) return;
            _button.onClick.RemoveListener(OnClicked);
            _button.onClick.AddListener(OnClicked);
        }

        public void SetHighlight()
        {
            if (!ValidateBindings()) return;
            bool isCurrentFloor = _floorId == _navigator.Current.Floor;
            _background.color = isCurrentFloor ? new Color(1f, 0.95f, 0.6f) : Color.white;
        }

        private void OnClicked()
        {
            if (!ValidateBindings()) return;
            if (_floorId == _navigator.Current.Floor)
                return;
            RoomId defaultRoom = BuildingNavigationTable.GetDefaultRoom(_floorId);
            _navigator.Show(_floorId, defaultRoom);
            _elevatorOverlay.Hide();
            Debug.Log($"已切换至楼层 {_floorId} 的默认房间: {defaultRoom}");
        }
        private bool ValidateBindings()
        {
            bool isValid = true;
            string missing = "";

            if (_navigator == null)
            {
                missing += $"[{nameof(_navigator)}]，";
                isValid = false;
            }

            if (_elevatorOverlay == null)
            {
                missing += $"[{nameof(_elevatorOverlay)}]，";
                isValid = false;
            }

            if (_background == null)
            {
                missing += $"[{nameof(_background)}]，";
                isValid = false;
            }

#if UNITY_EDITOR
            if (!isValid)
                Debug.LogWarning($"[{nameof(ElevatorFloorButton)}] 缺少引用：{missing.TrimEnd('，')}");
#endif
            return isValid;
        }
    }
}



