using System;
using TMPro;
using UnityEngine;

namespace UI.GitWindow.Scripts
{
    public class DescriptionButton : MonoBehaviour
    {
        public GameObject      currentVersionText;
        public TextMeshProUGUI descriptionButtonText;
        public int             id;

        private void Start()
        {
            currentVersionText.SetActive(false);
        }

        public void SwitchVersion()
        {
            Loader.currentVersion = id;
            Debug.Log("New version : " + Loader.currentVersion);
        }

        public void RefreshDescriptionButton(int newID)
        {
            id = newID;
            descriptionButtonText.gameObject.SetActive(true);
            if (id == Loader.currentVersion)
            {
                currentVersionText.SetActive(true);
                descriptionButtonText.gameObject.SetActive(false);
            }
            else if (id > Loader.currentVersion)
            {
                descriptionButtonText.text = "Go to commit";
                currentVersionText.SetActive(false);
            }
            else
            {
                descriptionButtonText.text = "Revert to commit";
                currentVersionText.SetActive(false);
            }
        }
    }
}
