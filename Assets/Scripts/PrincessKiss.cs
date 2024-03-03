using UnityEngine;

public class PrincessKiss : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != 7) return;
        //WIN
        winScreen.SetActive(true);  
        PauseController.isPaused = true;
    }
}
