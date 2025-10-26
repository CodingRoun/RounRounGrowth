// ElevatorOverlay.cs

using RounRounGrowth.Building;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RounRounGrowth.UI
{
    public class ElevatorOverlay : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private RectTransform _elevatorPanel;
        [SerializeField] private BuildingNavigator _navigator;
        [SerializeField] private MapOverlay _mapOverlay;
        [SerializeField] private ElevatorFloorButton[] _floorButtons;
        private bool _wasMapOpen;

        private void Awake() 
        {
            if (!ValidateBindings())
            {
#if UNITY_EDITOR
                Debug.LogWarning($"[{nameof(ElevatorOverlay)}] 缺少引用，组件已禁用。");
#endif
                enabled = false;
                return;
            }
            // 场景加载时默认关闭电梯面板
            gameObject.SetActive(false);
        }

        private void OnEnable() // 打开电梯面板时高亮当前楼层
        {
            SetButtonHighlight();
        }

        private void Update() // 打开地图时关闭ElevatorOverlay，每帧检测
        {
            bool isMapOpen = _mapOverlay.gameObject.activeSelf;
            if (isMapOpen && !_wasMapOpen)
            {
#if UNITY_EDITOR
                Debug.Log($"[{nameof(_mapOverlay)}] 检测到地图打开，关闭电梯面板");
#endif
                Hide();
            }
            _wasMapOpen = isMapOpen;
        }

        public void OnPointerClick(PointerEventData eventData) // 如点击在ElevatorPanel外，则关闭ElevatorOverlay
        {
            if (!ValidateBindings()) return;
            bool isClickOutsidePanel = !RectTransformUtility.RectangleContainsScreenPoint(
                _elevatorPanel,
                eventData.position
                );
            bool isPanelShown = gameObject.activeSelf;
            if (isPanelShown && isClickOutsidePanel)
                Hide();
        }

        public void Show() // 打开电梯菜单
        {
            gameObject.SetActive(true);
        }

        public void Hide() // 关闭电梯菜单
        {
            gameObject.SetActive(false);
        }

        private void SetButtonHighlight() // 高亮按钮
        {
            foreach (var button in _floorButtons)
            {
                button.SetHighlight();
            }
        }
        private bool ValidateBindings()
        {
            bool isValid = true;
            string missing = "";

            if (_elevatorPanel == null)
            {
                missing += $"{nameof(_elevatorPanel)}，";
                isValid = false;
            }

            if (_navigator == null)
            {
                missing += $"{nameof(_navigator)}，";
                isValid = false;
            }

            if (_mapOverlay == null)
            {
                missing += $"{nameof(_mapOverlay)}，";
                isValid = false;
            }

            if (_floorButtons == null || _floorButtons.Length == 0)
            {
                missing += $"{nameof(_floorButtons)}，";
                isValid = false;
            }

#if UNITY_EDITOR
            if (!isValid)
                Debug.LogWarning($"[{nameof(ElevatorOverlay)}] 缺少引用：{missing.TrimEnd('，')}");
#endif
            return isValid;
        }
    }
}


