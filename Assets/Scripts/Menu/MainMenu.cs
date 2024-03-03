using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class MainMenu : MonoBehaviour
    {
        public void PlayGame()
        {
            StartCoroutine(OnStartCoroutine());
        }
        public void QuitGame()
        {
            StartCoroutine(OnQuitCoroutine());
        }
    
        public void LoadMainMenu()
        {
            StartCoroutine(MenuCoroutine());
        }
        
        static IEnumerator OnStartCoroutine()
        {   
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
        static IEnumerator MenuCoroutine()
        {   
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(0);
        }
        
        static IEnumerator OnQuitCoroutine()
        {   
            yield return new WaitForSeconds(2f);
            Application.Quit();
        }
        
        
        
    }
}

