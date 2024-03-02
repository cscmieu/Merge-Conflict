using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private CanvasGroup pauseMenuCanvasGroup;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (optionsMenu.activeSelf)
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
        pauseMenu.SetActive(false);
        pauseMenuCanvasGroup.LeanAlpha(0, 0.5f).setEaseOutBack();
        Time.timeScale = 1f;
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        pauseMenuCanvasGroup.alpha = 0;
        pauseMenuCanvasGroup.LeanAlpha(1, 0.5f).setEaseOutBack();
        Time.timeScale = 1f;
    }
}
