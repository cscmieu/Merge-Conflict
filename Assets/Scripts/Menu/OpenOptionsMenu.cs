using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class OpenOptionsMenu : MonoBehaviour
{
    void Start()
    {
        transform.localScale = Vector2.zero;
    }

    public void Open()
    {
        gameObject.SetActive(true);
        transform.LeanScale(Vector2.one, 0.8f).setEaseOutBack();
    }
    
    public void Close()
    {   
        if (transform.localScale == Vector3.zero) return;
        else
        {
            
            transform.LeanScale(Vector2.zero, 0.01f).setEaseInBack();
            gameObject.SetActive(false);
        }
    }
    
}
