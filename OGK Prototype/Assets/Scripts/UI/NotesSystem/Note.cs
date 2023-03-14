using Unity.VisualScripting;
using UnityEngine;

namespace NotesSystem
{
    [CreateAssetMenu(fileName = "new Note", menuName = "Notes System/new Note")]
    public class Note : ScriptableObject
    {
        [SerializeField] string label = string.Empty;
        public string Label { get { return label; } }

        [SerializeField] Page[] pages = new Page[0];
        public Page[] Pages { get { return pages; } }
    }
}