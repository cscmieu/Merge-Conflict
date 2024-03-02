using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonDescription : MonoBehaviour
{
    public ButtonDescriptionData ButtonDescriptionData = new ButtonDescriptionData();
    public TextMeshProUGUI title;
    public TextMeshProUGUI pseudo;
    public TextMeshProUGUI date;
    
    private void Start()
    {
        title.text = ButtonDescriptionData.title;
        pseudo.text = ButtonDescriptionData.pseudo;
        date.text = ButtonDescriptionData.date;
    }
}

[System.Serializable]
public class ButtonDescriptionData
{
    public string title;
    public string pseudo;
    public string date;
    public string description;
    public int id;
}

