//ElevatorButton.cs

using UnityEngine;

namespace RounRounGrowth.UI
{
    public class ElevatorButton : MonoBehaviour
    {
        [SerializeField] private ElevatorOverlay _elevatorOverlay;

        public void OnClick()
        {
            if (_elevatorOverlay == null)
            {
                Debug.LogWarning("[ElevatorButton] Î´°ó¶¨ElevatorOverlay");
                return;
            }
            
            TogglePanel();
        }

        private void TogglePanel()
        {
            bool isOverlayActive = _elevatorOverlay.gameObject.activeSelf;
            if (isOverlayActive)
                _elevatorOverlay.Hide();
            else
                _elevatorOverlay.Show();
        }
    }
}

