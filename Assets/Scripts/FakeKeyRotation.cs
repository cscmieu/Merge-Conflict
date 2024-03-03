using UnityEngine;

public class FakeKeyRotation : MonoBehaviour
{
    private Transform _transform;
    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        _transform.Rotate(0f, 90f*Time.deltaTime, 0f);
    }
}
