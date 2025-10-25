using UnityEngine;
namespace RounRounGrowth.UI
{
    public class MapOverlay : MonoBehaviour
    {
        [SerializeField] private GameObject _floatingUI;

        private void OnEnable()
        {
            if (_floatingUI == null)
            {
                Debug.LogWarning("[MapOverlay] 未绑定 FloatingUI");
                return;
            }
            _floatingUI.SetActive(false);
        }
        private void OnDisable()
        {
            if (_floatingUI == null)
            {
                Debug.LogWarning("[MapOverlay] 未绑定 FloatingUI");
                return;
            }
            _floatingUI.SetActive(true);
        }
    }
}


