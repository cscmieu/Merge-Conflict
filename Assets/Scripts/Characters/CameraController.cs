using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;

    public float minCamTerrainHeight = 0.15f;
    public float smoothTime = 0.1f;
    private Vector3 velocity = Vector3.zero;

    private Vector3 _cameraLocalPosition;
    private RaycastHit hit;
    private bool _colliding = false;

    void Start()
    {
        _cameraLocalPosition = _cameraTransform.localPosition;
    }
    // Update is called once per frame
    void Update()
    {
        if (_colliding)
        {
            transform.localPosition = Vector3.SmoothDamp(transform.localPosition, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - minCamTerrainHeight), ref velocity, smoothTime);
        }
        Debug.DrawLine(transform.position, _cameraTransform.position);
        if (Physics.Linecast(transform.position, _cameraTransform.position, out hit) && hit.transform.gameObject.layer != 6)
        {
            _cameraTransform.localPosition = new Vector3(0, 0, -Vector3.Distance(transform.position, hit.point));
        }
        else
        {
            _cameraTransform.localPosition = Vector3.Lerp(_cameraTransform.localPosition, _cameraLocalPosition, Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
            _colliding = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
            _colliding = false;
    }
}
