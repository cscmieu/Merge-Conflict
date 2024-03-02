using System;
using TMPro;
using UnityEngine;

namespace UI.GitWindow.Scripts
{
    public class DescriptionButton : MonoBehaviour
    {
        public GameObject                currentVersion ;
        public TextMeshProUGUI descriptionButtonText;
        public int                   id;

        private void Start()
        {
            currentVersion.SetActive(false);
        }

        public void SwitchVersion()
        {
            Loader.currentVersion = id;
            Debug.Log("New version : " + Loader.currentVersion);
        }

        public void RefreshDescriptionButton(int newID)
        {
            id = newID;
            if (id == Loader.currentVersion)
            {
                currentVersion.SetActive(true);
                descriptionButtonText.text = "";
            }
            else if (id > Loader.currentVersion)
            {
                descriptionButtonText.text = "Go to commit";
            }
            else
            {
                descriptionButtonText.text = "Revert to commit";
            }
        }
    }
}
