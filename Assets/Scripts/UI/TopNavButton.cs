//TopNavButton.cs

using UnityEngine;
using TMPro;
using RounRounGrowth.Core;
using UnityEngine.UI;
using RounRounGrowth.Building;

namespace RounRounGrowth.UI
{
    public class TopNavButton : MonoBehaviour
    {
        public RoomId RoomId { get; private set; }
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Image _background;
        private BuildingNavigator _navigator; 

        public void Initialize(RoomId roomId, string displayName, BuildingNavigator navigator) 
        {
            RoomId = roomId; 
            _text.text = displayName; 
            _navigator = navigator; 
            GetComponent<Button>().onClick.AddListener(OnClicked); 
        }

        public void OnClicked()
        {
            if (_navigator != null)
                _navigator.Show(_navigator.Current.Floor, RoomId);
        }

        public void SetHighlight(bool isHighlighted)
        {
            _background.color = isHighlighted ? new Color(1f, 0.95f, 0.6f) : Color.white;
        }
    }
}

