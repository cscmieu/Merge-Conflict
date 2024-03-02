using System;
using TMPro;
using UnityEngine;

public class Carousel : MonoBehaviour
{
    public TextMeshProUGUI printSpace;
    public String choice0;
    public String choice1;
    public String choice2;
    public int index = 0;

    private void OnEnable()
    {
        Refresh();
    }

    private void Refresh()
    {
        if (index % 3 == 0)
        {
            printSpace.text = choice0;
        }
        else if (index % 3 == 1)
        {
            printSpace.text = choice1;
        }
        else if (index % 3 == 2)
        {
            printSpace.text = choice2;
        }
    }

    public void Next()
    {
        index++;
        Refresh();
    }
    
    public void Previous()
    {
        index--;
        Refresh();
    }
    
}
