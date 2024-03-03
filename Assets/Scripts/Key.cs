using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        ItemManager.hasKey = true;
        Destroy(gameObject);
    }
}
