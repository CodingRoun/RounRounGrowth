//ElevatorButton.cs

using UnityEngine;

namespace RounRounGrowth.UI
{
    public class ElevatorButton : MonoBehaviour
    {
        [SerializeField] private ElevatorPanel _elevatorPanel;

        public void OnClick()
        {
            if (_elevatorPanel == null)
            {
                Debug.LogWarning("[ElevatorButton] Î´°ó¶¨ElevatorPanel");
                return;
            }
            
            TogglePanel();
        }

        private void TogglePanel()
        {
            bool isPanelShown = _elevatorPanel.gameObject.activeSelf;
            _elevatorPanel.gameObject.SetActive(!isPanelShown);
        }
    }
}

