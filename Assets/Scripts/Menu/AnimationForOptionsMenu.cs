using System.Collections;
using UnityEngine;

public class AnimationForOptionsMenu : MonoBehaviour
{
    public CanvasGroup background;
    public GameObject hotBar;
    public GameObject mainMenu;

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
        hotBar.SetActive(true);
    }
    
    public void Close()
    {
        background.LeanAlpha(0, 0.5f).setEaseOutBack().setOnComplete(OnComplete);
        hotBar.SetActive(false);
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
        
    }
    
    void OnComplete()
    {
        gameObject.SetActive(false);
    }
    
    
}
