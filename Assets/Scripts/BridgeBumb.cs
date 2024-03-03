using Characters;
using UnityEngine;

public class BridgeBumb : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent<PlayerController>(out var feur))
        {
/*            feur.Bump();*/
        }
    }
}
