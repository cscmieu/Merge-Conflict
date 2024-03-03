using UnityEngine;

public class PrincessKiss : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != 7) return;
        //WIN
    }
}
