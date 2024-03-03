using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject _parent;

    private float smoothTime = 10f;
    private Vector3 velocity = Vector3.zero;

    private Vector3 _camera_offset;
    private RaycastHit hit;
    private bool _colliding = false;

    void Start()
    {
        _camera_offset = transform.localPosition;
    }
    // Update is called once per frame
    void Update()
    {
        if (_colliding)
        {
            transform.position -= smoothTime*Time.deltaTime*(transform.position-_parent.transform.position).normalized;
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, _camera_offset, Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        _colliding = true;
    }

    void OnTriggerExit(Collider other)
    {
        _colliding = false;
    }
}
