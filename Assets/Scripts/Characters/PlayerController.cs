using UnityEngine;

namespace Characters
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Fonctionalitées")] 
        [SerializeField] private bool canJump;
        [SerializeField] private bool  hasGravity;
        [SerializeField] private float gravityMultiplier = 1;
        
        
        [Header("Components")]
        [SerializeField] private PlayerData playerData;
        [SerializeField] private GameObject rotateCamera;
        private                  int        _speed            = 200;
        private                  int        _mouseSensitivity = 1;
        private                  int        _maxLookAngle     = 35;
        private                  int        _minLookAngle     = -30;
        private                  float      _jumpForce        = 50;
        private                  bool       _invertCamera;
        private                  int        _forceGravity = 10;
        private                  Rigidbody  _rigidbody;
        private                  bool       _isGrounded = true;
        private                  Transform  _transform;
        private                  float      _groundCheckDistance = 0.7f;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _transform = transform;
        }

        private void Start()
        {
            _speed                = playerData.Speed;
            _mouseSensitivity     = playerData.MouseSensitivity;
            _maxLookAngle         = playerData.MaxLookAngle;
            _minLookAngle         = playerData.MinLookAngle;
            _jumpForce            = playerData.JumpForce;
            _invertCamera         = playerData.invertCamera;
            _forceGravity         = playerData.ForceGravity;
            _rigidbody.useGravity = hasGravity;
            
            Cursor.lockState = CursorLockMode.Locked; // Masque le curseur de la souris
            if (rotateCamera == null) Debug.LogError("l'objet vide pour tourner la camera n'est pas SerializeField");
        }


        private void Update()
        {
            Rotate();
            CheckGround();
        }

        private void FixedUpdate()
        {
            Jump();
            Move();
            if (!_isGrounded)
            {
                _rigidbody.AddForce(Vector3.down * (_forceGravity * gravityMultiplier), ForceMode.Acceleration);
            }
        }

        private void Move()
        {
            var dirVertical   = Input.GetAxisRaw("Vertical");
            var dirHorizontal = Input.GetAxisRaw("Horizontal");
            if (dirHorizontal == 0f && dirVertical == 0f) return;

            var dirVect = (_transform.forward * dirVertical + _transform.right * dirHorizontal).normalized;

            var vectUp = Vector3.up * 0.45f;
            RaycastHit hit;
            Debug.DrawRay(_transform.position + vectUp, dirVect, Color.red, 1f);
            if (Physics.Raycast(_transform.position + vectUp, dirVect, out hit, 1))
            {
                if (hit.transform.gameObject.layer != 3) return;
            }

            transform.position += _speed * Time.deltaTime * dirVect;
        }

        private void Rotate()
        {
            var yaw = Input.GetAxis("Mouse X") * _mouseSensitivity;

            float pitch;

            if (!_invertCamera)
            {
                pitch = -_mouseSensitivity * Input.GetAxis("Mouse Y");
            }
            else
            {
                // Inverted Y
                pitch = _mouseSensitivity * Input.GetAxis("Mouse Y");
            }

            // Clamp pitch between lookAngle

            transform.localEulerAngles += new Vector3(0, yaw, 0);

            var rotation = rotateCamera.transform.localEulerAngles + new Vector3(pitch, 0, 0);

            rotation.x = ClampRotation(rotation.x, _minLookAngle, _maxLookAngle);

            rotateCamera.transform.localEulerAngles = rotation;
        }

        private static float ClampRotation(float angle, float min, float max)
        {
            if (angle < 0) angle += 360;
            return angle > 180f ? Mathf.Max(angle, 360 + min) : Mathf.Min(angle, max);
        }

        private void Jump()
        {
            if (!_isGrounded) return;
            if (!canJump) return;
            if (Input.GetButton("Jump"))
            {
                //Apply a force to this Rigidbody in direction of this GameObjects up axis
                _rigidbody.AddForce(Vector3.up * (_jumpForce * _rigidbody.mass), ForceMode.Impulse);
            }
        }

        private void CheckGround()
        {
            var position  = _transform.position;
            var origin    = new Vector3(position.x, position.y+0.5f, position.z);
            var direction = _transform.TransformDirection(Vector3.down);

            Debug.DrawRay(origin, direction);
            _isGrounded = Physics.Raycast(origin, direction, _groundCheckDistance);
        }
    }
}
