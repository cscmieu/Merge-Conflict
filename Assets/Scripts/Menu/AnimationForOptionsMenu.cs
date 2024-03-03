using System.Collections;
using UnityEngine;

public class AnimationForOptionsMenu : MonoBehaviour
{
    public CanvasGroup background;
    public GameObject hotBar;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Close();
        }
    }

    private void OnEnable()
    {
        background.alpha = 0;
        background.LeanAlpha(1, 0.5f).setEaseOutBack();
        StartCoroutine(OnEnableCoroutine());
    }
    
    public void Close()
    {
        background.LeanAlpha(0, 0.5f).setEaseOutBack().setOnComplete(OnComplete);
        hotBar.SetActive(false);
        gameObject.SetActive(false);
    }
    
    void OnComplete()
    {
        gameObject.SetActive(false);
    }
    
    IEnumerator OnEnableCoroutine()
    {
        Time.timeScale = 1f;
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0f;
    }
    
}
