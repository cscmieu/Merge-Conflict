using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ItemManager.hasKey = true;
        Destroy(gameObject);
    }
}
