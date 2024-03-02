using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.UI.Image;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerData _playerData;
    private int Speed = 200;
    private int mouseSensitivity = 1;
    private int maxLookAngle = 35;
    private int minLookAngle = -30;
    private float jumpForce = 50;
    private bool invertCamera = false;
    private int forceGravity = 10;

    private Rigidbody _rigidbody;
    private bool _isGrounded = true;


    [SerializeField] GameObject _rotateCamera;

    

    // Start is called before the first frame update
    void Start()
    {
        Speed = _playerData.Speed;
        mouseSensitivity = _playerData.MouseSensitivity;
        maxLookAngle = _playerData.MaxLookAngle;
        minLookAngle = _playerData.MinLookAngle;
        jumpForce = _playerData.JumpForce;
        invertCamera = _playerData.invertCamera;
        forceGravity = _playerData.ForceGravity;


        UnityEngine.Cursor.visible = false; // Masque le curseur de la souris


        _rigidbody = GetComponent<Rigidbody>();
        if (_rigidbody == null) Debug.LogError("pas de rigidbody sur le player ");

        if (_rotateCamera == null) Debug.LogError("l'objet vide pour tourner la camera n'est pas SerializeField");
    }

    // Update is called once per frame
    void Update()
    {
        
        Rotate();
        CheckGround();
    }

    void FixedUpdate()
    {
        Move();
        Jump();
        if (!_isGrounded)
        {
            _rigidbody.AddForce(Vector3.down * forceGravity, ForceMode.Acceleration);
        }
    }

    void Move()
    {
        var dirVertical = Input.GetAxisRaw("Vertical");
        var dirHorizontal = Input.GetAxisRaw("Horizontal");
        if (dirHorizontal == 0f && dirVertical == 0f) return;

        var dirVect = (transform.forward * dirVertical + transform.right * dirHorizontal).normalized;

        var vectUp = Vector3.up * 0.4f;
        Debug.DrawRay(transform.position + vectUp, dirVect, Color.red,1f);
        if (Physics.Raycast(transform.position + vectUp, dirVect, out RaycastHit hit, 1))
        {
            return;
        }

        transform.position += Speed * Time.deltaTime * dirVect;
    }

    void Rotate()
    {
        var yaw = Input.GetAxis("Mouse X") * mouseSensitivity;

        var pitch = 0.0f;

        if (!invertCamera)
        {
            pitch = -mouseSensitivity * Input.GetAxis("Mouse Y");
        }
        else
        {
            // Inverted Y
            pitch = mouseSensitivity * Input.GetAxis("Mouse Y");
        }

        // Clamp pitch between lookAngle

        transform.localEulerAngles += new Vector3(0, yaw, 0);

        var rotation = _rotateCamera.transform.localEulerAngles + new Vector3(pitch, 0, 0);

        rotation.x = ClampRotation(rotation.x, minLookAngle, maxLookAngle);

        _rotateCamera.transform.localEulerAngles = rotation;
    }

    float ClampRotation(float angle, float min, float max)
    {
        if (angle < 0) angle += 360;
        if (angle > 180f) return Mathf.Max(angle, 360 + min);
        return Mathf.Min(angle, max);
    }

    void Jump()
    {
        if (_isGrounded)
        {
            if (Input.GetButton("Jump"))
            {
                //Apply a force to this Rigidbody in direction of this GameObjects up axis
                _rigidbody.AddForce(Vector3.up * jumpForce * _rigidbody.mass, ForceMode.Impulse);
            }
        }
    }

    private void CheckGround()
    {
        Vector3 origin = new Vector3(transform.position.x, transform.position.y+0.5f, transform.position.z);
        Vector3 direction = transform.TransformDirection(Vector3.down);
        float distance = 1f;

        if (Physics.Raycast(origin, direction, out RaycastHit hit, distance))
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }
    }
}
