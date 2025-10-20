//TopNavButton.cs

using UnityEngine;
using TMPro;
using RounRounGrowth.Core;
using UnityEngine.UI;

namespace RounRounGrowth.UI
{
    public class TopNavButton : MonoBehaviour
    {
        public RoomId RoomId { get; private set; }
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Image _background;

        public void Initialize(RoomId roomId, string displayname)
        {
            RoomId = roomId;
            _text.text = displayname;
        }

        public void SetHighlight(bool isHighlighted)
        {
            _background.color = isHighlighted ? new Color(1f, 0.95f, 0.6f) : Color.white;
        }
    }
}

