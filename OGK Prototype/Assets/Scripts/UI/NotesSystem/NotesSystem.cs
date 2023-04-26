using StarterAssets;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace NoteSystem
{
    [Serializable()]
    public struct UIElements
    {
        [SerializeField] TextMeshProUGUI textObj;
        public TextMeshProUGUI TextObj { get { return textObj; } }

        [SerializeField] TextMeshProUGUI subscript;
        public TextMeshProUGUI Subscript { get { return subscript; } }

        [SerializeField] CanvasGroup subscriptGroup;
        public CanvasGroup SubscriptGroup { get { return subscriptGroup; } }

        [SerializeField] Image page;
        public Image Page { get { return page; } }

        [SerializeField] Image lines;
        public Image Lines { get { return lines; } }

        [SerializeField] CanvasGroup noteCanvasGroup;
        public CanvasGroup NoteCanvasGroup { get { return noteCanvasGroup; } }

        [SerializeField] CanvasGroup listCanvasGroup;
        public CanvasGroup ListCanvasGroup { get { return listCanvasGroup; } }

        [SerializeField] CanvasGroup readButton;
        public CanvasGroup ReadButton { get { return readButton; } }

        [SerializeField] CanvasGroup nextButton;
        public CanvasGroup NextButton { get { return nextButton; } }

        [SerializeField] CanvasGroup previousButton;
        public CanvasGroup PreviousButton { get { return previousButton; } }

        [SerializeField] NoteData noteDataPrefab;
        public NoteData NoteDataPrefab { get { return noteDataPrefab; } }

        [SerializeField] RectTransform listRect;
        public RectTransform ListRect { get { return listRect; } }
    }
    public class NotesSystem : MonoBehaviour
    {
        #region Variables

        #region Data and Actions

        [Header("References")]
        [SerializeField] UIElements UI = new UIElements();

        [Header("Colors")]
        [SerializeField] Color color1 = Color.grey;
        [SerializeField] Color color2 = Color.gray;
        [SerializeField] FirstPersonController player;

        private static Dictionary<string, Note> Notes = new Dictionary<string, Note>();
        public List<NoteData> noteDatas = new List<NoteData>();
        private static Action<Note> A_Display = delegate { };
        #endregion

        #region Audio

        [Header("Audio")]
        [SerializeField]
        private AudioSource[] sources = null;
        [Space]
        [SerializeField] AudioClip openNoteSFX = null;
        [SerializeField] AudioClip closeNoteSFX = null;
        [Space]
        [SerializeField] AudioClip[] turnPageSFX = null;

        #endregion

        #region Properties and Private

        public Note activeNote = null;
        private Page ActivePage
        {
            get
            {
                return activeNote.Pages[currentPage];
            }
        }

        private int currentPage = 0;
        private bool readSubscript = false;
        private Sprite defaultPageTexture = null;
        private bool usingNotesSystem = false;

        #endregion

        #endregion

        #region Unity's Default Methods

        private void OnEnable()
        {
            A_Display += DisplayNote;
        }
        private void OnDisable()
        {
            A_Display -= DisplayNote;
        }

        private void Start()
        {
            Close(false);

            defaultPageTexture = UI.Page.sprite;
            Display(activeNote);
        }

        #endregion

        #region Display and Hide Methods

        public void Open()
        {
            UpdateList();
            UpdateCanvasGroup(true, UI.ListCanvasGroup);
        }
        public void Close(bool playSFX)
        {
            CloseNote(playSFX);
            UpdateCanvasGroup(false, UI.ListCanvasGroup);
        }

        public void DisplayNote(Note note)
        {
            if (note == null) { return; }

            PlaySound(openNoteSFX);

            UpdateCanvasGroup(true, UI.NoteCanvasGroup);
            activeNote = note;

            DisplayPage(0);
        }
        private void DisplayPage(int page)
        {
            UI.ReadButton.interactable = activeNote.Pages[page].Type == PageType.Texture;

            //sources[1].Stop();
            //if (activeNote.Pages[page].Narration != null)
            //{
            //    if (!activeNote.Pages[page].NarrationPlayed)
            //    {
            //        sources[1].clip = activeNote.Pages[page].Narration;
            //        sources[1].Play();
            //        if (activeNote.Pages[page].Narration_PlayOnce)
            //        {
            //            activeNote.Pages[page].NarrationPlayed = true;
            //        }
            //    }
            //}

            switch (activeNote.Pages[page].Type)
            {
                case PageType.Text:
                    print(activeNote.Pages[page].Text);
                    UI.Page.sprite = defaultPageTexture;
                    UI.TextObj.text = activeNote.Pages[page].Text;
                    break;
                case PageType.Texture:
                    UI.Page.sprite = activeNote.Pages[page].Texture;
                    UI.TextObj.text = string.Empty;
                    break;
            }
            UpdateUI();
        }

        public void Display(Note note)
        {
            DisplayNote(note);
        }
        public static void Display(string key)
        {
            var note = GetNote(key);
            A_Display(note);
        }

        public void CloseNote(bool playSFX)
        {
            if (playSFX)
            { PlaySound(closeNoteSFX); }

            UpdateCanvasGroup(false, UI.NoteCanvasGroup);
            OnNoteClose();
        }

        #endregion

        #region Navigation Methods

        public void Next()
        {
            PlaySound(turnPageSFX);

            currentPage++;
            if (activeNote.Pages[currentPage].Type != PageType.Texture)
            { readSubscript = false; }
            else { if (readSubscript) { UpdateSubscript(); } }

            DisplayPage(currentPage);
        }
        public void Previous()
        {
            PlaySound(turnPageSFX);

            currentPage--;
            if (activeNote.Pages[currentPage].Type != PageType.Texture)
            { readSubscript = false; }
            else { if (readSubscript) { UpdateSubscript(); } }

            DisplayPage(currentPage);
        }
        public void Read()
        {
            readSubscript = !readSubscript;

            UpdateSubscript();
            UpdateUI();
        }

        #endregion

        #region Update Methods

        private void UpdateSubscript()
        {
            UI.Subscript.text = readSubscript ? ActivePage.Text : string.Empty;
        }
        private void UpdateUI()
        {
            UI.PreviousButton.interactable = !(currentPage == 0);
            UI.NextButton.interactable = !(currentPage == activeNote.Pages.Length - 1);

            var useSubscript = ActivePage.Type == PageType.Texture && ActivePage.UseSubscript;

            UI.ReadButton.alpha = useSubscript ? (readSubscript ? .5f : 1f) : 0;
            UpdateCanvasGroup(readSubscript, UI.SubscriptGroup);

            UI.Lines.enabled = ActivePage.DisplayLines;
        }
        private void UpdateList()
        {
            ClearList();

            int index = 0;
            float height = 0.0f;
            foreach (var note in Notes)
            {
                Color color = index % 2 == 0 ? color1 : color2;

                var newNotePrefab = Instantiate(UI.NoteDataPrefab, UI.ListRect);
                noteDatas.Add(newNotePrefab);

                newNotePrefab.UpdateInfo(note.Value, color);

                newNotePrefab.Rect.anchoredPosition = new Vector2(0, height);
                height -= newNotePrefab.Rect.sizeDelta.y;

                index++;
            }
        }
        private void UpdateCanvasGroup(bool state, CanvasGroup canvasGroup)
        {
            switch (state)
            {
                case true:
                    canvasGroup.alpha = 1.0f;
                    canvasGroup.blocksRaycasts = true;
                    canvasGroup.interactable = true;
                    break;
                case false:
                    canvasGroup.alpha = 0.0f;
                    canvasGroup.blocksRaycasts = false;
                    canvasGroup.interactable = false;
                    break;
            }
        }

        #endregion

        #region Getters and Utility Methods

        public static void AddNote(string key, Note note)
        {
            if (Notes.ContainsKey(key) == false)
            {
                Notes.Add(key, note);
            }
        }
        public static Note GetNote(string key)
        {
            if (Notes.ContainsKey(key))
            {
                return Notes[key];
            }
            return null;
        }

        private void PlaySound(AudioClip[] clips)
        {
            if (clips != null)
            {
                var sfx = turnPageSFX[UnityEngine.Random.Range(0, clips.Length)];
                sources[0].PlayOneShot(sfx);
            }
        }
        private void PlaySound(AudioClip clip)
        {
            if (clip)
            {
                sources[0].PlayOneShot(clip);
            }
        }

        private void OnNoteClose()
        {
            activeNote = null;
            currentPage = 0;
            readSubscript = false;
            //sources[1].Stop();
        }
        private void ClearList()
        {
            foreach (var note in noteDatas)
            {
                Destroy(note.gameObject);
            }
            noteDatas.Clear();
        }

        #endregion
    }
}