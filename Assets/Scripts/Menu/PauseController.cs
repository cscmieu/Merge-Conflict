using System.Collections;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private CanvasGroup pauseMenuCanvasGroup;
    public static bool isPaused = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Loader.currentVersion > 16)
            {
                return;
            }
            else if (optionsMenu.activeSelf)
            {
                return;
            }
            else if (pauseMenu.activeSelf)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    
    public void ResumeGame()
    {
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        pauseMenuCanvasGroup.LeanAlpha(0, 0.5f).setEaseOutBack();
        Time.timeScale = 1f;
    }
    public void PauseGame()
    {
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseMenu.SetActive(true);
        pauseMenuCanvasGroup.alpha = 0;
        pauseMenuCanvasGroup.LeanAlpha(1, 0.5f).setEaseOutBack();
        StartCoroutine(PauseGameCoroutine());
    }
    
    IEnumerator PauseGameCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0f;
    }
    
}
