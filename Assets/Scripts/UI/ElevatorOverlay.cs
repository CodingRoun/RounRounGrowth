// ElevatorOverlay.cs

using RounRounGrowth.Building;
using RounRounGrowth.Core;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace RounRounGrowth.UI
{
    public class ElevatorOverlay : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private RectTransform _elevatorPanel;
        [SerializeField] private BuildingNavigator _navigator;
        [SerializeField] private FloorButtonRef[] _floorButtonRefs;

        [System.Serializable]
        public class FloorButtonRef
        {
            public FloorId Floor;
            public Button Button;
        }

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            if (_floorButtonRefs == null || _floorButtonRefs.Length == 0)
            {
                Debug.LogWarning("[ElevatorOverlay] δ��¥�㰴ť����");
                return;
            }
            foreach (var refData in _floorButtonRefs)
            {
                if (refData == null || refData.Button == null)
                {
                    Debug.LogWarning("[ElevatorOverlay] ĳ�� FloorButtonRef δ��");
                    continue;
                }

                refData.Button.onClick.RemoveAllListeners(); // ��ֹ�ظ���
                refData.Button.onClick.AddListener(() =>
                {
                    OnFloorButtonClicked(refData.Floor);
                });
                SetHighlight(_navigator.Current, refData); // ��Ϊ�㲥ʱ��������״̬���޷������¼�������������ȡ��ǰλ��
            }
        }

        private void SetHighlight(CurrentLocation currentLocation, FloorButtonRef refData)
        {
            bool isCurrentFloor = refData.Floor == currentLocation.Floor;
            refData.Button.image.color = isCurrentFloor ? new Color(1f, 0.95f, 0.6f) : Color.white;
        }

        private void OnFloorButtonClicked(FloorId floor)
        {
            Debug.Log($"�����¥�㰴ť��{floor}");
        }

        public void OnPointerClick(PointerEventData eventData) // ������ElevatorPanel�⣬��ر�ElevatorOverlay
        {
            if (_elevatorPanel == null)
            {
                Debug.LogWarning("[ElevatorOverlay] δ�� ElevatorPanel");
                return;
            }
            bool isClickOutsidePanel = !RectTransformUtility.RectangleContainsScreenPoint(
                _elevatorPanel,
                eventData.position
                );
            bool isPanelShown = gameObject.activeSelf;
            if (isPanelShown && isClickOutsidePanel)
                Hide();
        }

        public void Show() // �򿪵��ݲ˵�
        {
            gameObject.SetActive(true);
        }

        public void Hide() // �رյ��ݲ˵�
        {
            gameObject.SetActive(false);
        }
    }
}

