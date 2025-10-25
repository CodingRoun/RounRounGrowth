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
        [SerializeField] private MapOverlay _mapOverlay;
        private bool _wasMapOpen;

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
            foreach (var floorButtonRef in _floorButtonRefs)
            {
                if (floorButtonRef == null || floorButtonRef.Button == null)
                {
                    Debug.LogWarning("[ElevatorOverlay] ĳ�� FloorButtonRef δ��");
                    continue;
                }

                floorButtonRef.Button.onClick.RemoveAllListeners(); // ��ֹ�ظ���
                floorButtonRef.Button.onClick.AddListener(() =>
                {
                    OnFloorButtonClicked(floorButtonRef.Floor);
                });
                SetHighlight(_navigator.Current, floorButtonRef); // ��Ϊ�㲥ʱ��������״̬���޷������¼�������������ȡ��ǰλ��
            }
        }

        private void Update()
        {
            if (_mapOverlay == null)
            {
                Debug.LogWarning("[ElevatorOverlay] δ�� MapOverlay");
                return;
            }
            bool isMapOpen = _mapOverlay.gameObject.activeSelf;
            if (isMapOpen && !_wasMapOpen)
            {
                Debug.Log("[ElevatorOverlay] ��⵽��ͼ�򿪣��رյ������");
                Hide();
            }
            _wasMapOpen = isMapOpen;
                
        }
        private void SetHighlight(CurrentLocation currentLocation, FloorButtonRef floorButtonRef)
        {
            bool isCurrentFloor = floorButtonRef.Floor == currentLocation.Floor;
            floorButtonRef.Button.image.color = isCurrentFloor ? new Color(1f, 0.95f, 0.6f) : Color.white;
        }

        private void OnFloorButtonClicked(FloorId targetFloor)
        {
            if (_navigator == null)
            {
                Debug.LogWarning("[ElevatorOverlay] δ�� BuildingNavigator");
                return;
            }
            if (targetFloor == _navigator.Current.Floor) // ������ûʹ�ö��Ļ�ȡ��ʲôʱ��ʹ�ö��ģ�ʲôʱ��������ȡ��
                return;
            RoomId defaultRoom = BuildingNavigationTable.GetDefaultRoom(targetFloor);
            _navigator.Show(targetFloor, defaultRoom);
            Hide();
            Debug.Log($"���л���¥�� {targetFloor} ��Ĭ�Ϸ���: {defaultRoom}");
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

