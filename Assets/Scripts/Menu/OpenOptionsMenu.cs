using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenOptionsMenu : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Close();
        }
    }
    void Start()
    {
        transform.localScale = Vector2.zero;
    }

    public void Open()
    {
        gameObject.SetActive(true);
        transform.LeanScale(Vector2.one, 0.8f).setEaseOutBack();
        StartCoroutine(OnAnimationCoroutine());
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
    IEnumerator OnAnimationCoroutine()
    {
        Time.timeScale = 1f;
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0f;
    }
    
}
