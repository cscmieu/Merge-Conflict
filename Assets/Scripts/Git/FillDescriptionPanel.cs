using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FillDescriptionPanel : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public TextMeshProUGUI idText;
    public void RefreshDescriptionPanel()
    {
        title.text =  GetComponent<ButtonDescription>().ButtonDescriptionData.title;
        description.text = GetComponent<ButtonDescription>().ButtonDescriptionData.description;
        idText.text = "ID : " + GetComponent<ButtonDescription>().ButtonDescriptionData.id;
    }
}

