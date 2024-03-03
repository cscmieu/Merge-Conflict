using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private SoundManager soundManager;
        
        public void PlayGame()
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        public void QuitGame()
        {
            Application.Quit();
        }
    
        public void LoadMainMenu()
        {
            SceneManager.LoadScene(0);
        }
        
    }
}

