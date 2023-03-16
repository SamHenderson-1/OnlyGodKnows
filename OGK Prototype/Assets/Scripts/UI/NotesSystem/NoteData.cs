using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace NoteSystem
{
    public class NoteData : MonoBehaviour
    {
        #region Variables

        [Header("UI")]
        [SerializeField] Image bgImage = null;
        [SerializeField] TextMeshProUGUI label = null;

        [Header("Private and Properties")]
        private Note note = null;
        private RectTransform rect = null;
        public RectTransform Rect
        {
            get
            {
                if (rect == null)
                {
                    rect = GetComponent<RectTransform>();
                    if (rect == null) { rect = gameObject.AddComponent<RectTransform>(); }
                }
                return rect;
            }
        }

        #endregion

        public void UpdateInfo(Note note, Color color)
        {
            this.note = note;

            label.text = note.Label;
            bgImage.color = color;
        }
        public void Display()
        {
            NotesSystem.Display(note);
        }
    }
}