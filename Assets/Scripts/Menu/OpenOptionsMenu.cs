using System.Collections;
using UnityEngine;

namespace Menu
{
    public class OpenOptionsMenu : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Close();
            }
        }

        private void Start()
        {
            transform.localScale = Vector2.zero;
        }

        public void Open()
        {
            if (!ItemManager.hasAccessToPause) return;
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

        private static IEnumerator OnAnimationCoroutine()
        {   
            Time.timeScale = 1f;
            yield return new WaitForSeconds(0.5f);
            Time.timeScale = 0f;
        }
        public void SwitchMode()
        {
            if (gameObject.activeSelf)
            {
                Close();
            }
            else
            {
                Open();
            }
        }
    
    }
}
