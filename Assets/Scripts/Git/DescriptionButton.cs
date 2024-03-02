using UnityEngine;
using UnityEngine.UI;

public class DescriptionButton : MonoBehaviour
{
    public Button button;
    public TMPro.TextMeshProUGUI descriptionButtonText;
    public int id;
    
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
            descriptionButtonText.text = "Current version";
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
