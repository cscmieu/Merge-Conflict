using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public int Speed = 20;
    public int mouseSensitivity = 1;
    public int maxLookAngle = 35;
    public int minLookAngle = -30;
    public float jumpForce = 100;

    private CharacterController _characterController;
    private Rigidbody _rigidbody;
    private bool _isGrounded = true;

    public float RotateSpeed = 5.0f; // Vitesse de rotation de la caméra


    [SerializeField] GameObject _rotateCamera;

    public bool invertCamera =  false;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Cursor.visible = false; // Masque le curseur de la souris

        _characterController = GetComponent<CharacterController>();
        if ( _characterController == null ) Debug.LogError("il n'y a pas de character controller sur " + name);

        _rigidbody = GetComponent<Rigidbody>();
        if (_rigidbody == null) Debug.LogError("pas de rigidbody sur le player ");

        if (_rotateCamera == null) Debug.LogError("l'objet vide pour tourner la camera n'est pas SerializeField");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
        CheckGround();
        Jump();
    }

    void Move()
    {
        var dirVertical = Input.GetAxis("Vertical");
        var dirHorizontal = Input.GetAxis("Horizontal");

        var dirVect = transform.forward * dirVertical + transform.right * dirHorizontal;
        _characterController.Move(dirVect * Speed * Time.deltaTime);
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
                _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }

    private void CheckGround()
    {
        Vector3 origin = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector3 direction = transform.TransformDirection(Vector3.down);
        float distance = .2f;

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
