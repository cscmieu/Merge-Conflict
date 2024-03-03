using TMPro;
using UnityEngine;

namespace UI.GitWindow.Scripts
{
    public class ButtonDescription : MonoBehaviour
    {
        public ButtonDescriptionData buttonDescriptionData = new();
        public TextMeshProUGUI       title;
        public TextMeshProUGUI       pseudo;
        public TextMeshProUGUI       date;
    
        private void Start()
        {
            title.text  = buttonDescriptionData.title;
            pseudo.text = buttonDescriptionData.pseudo;
            date.text   = buttonDescriptionData.date;
        }
    }

    [System.Serializable]
    public class ButtonDescriptionData
    {
        public string title;
        public string pseudo;
        public string date;
        public string description;
        public int    id;
    }
}