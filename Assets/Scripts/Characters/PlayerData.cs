using UnityEngine;

namespace Characters
{
    [CreateAssetMenu]
    public class PlayerData : ScriptableObject
    {
        [Range(1, 20)]
        [Tooltip("Vitesse")]
        public int Speed = 1;

        [Range(1, 20)]
        [Tooltip("jumpForce")]
        public int JumpForce = 5;

        [Range(1, 100)]
        [Tooltip("forceGravity")]
        public int ForceGravity = 10;

        [Range(20, 1000)]
        [Tooltip("mouseSensitivity")]
        public int MouseSensitivity = 1;

        [Range(-45, -20)]
        [Tooltip("minAngleCamera")]
        public int MinLookAngle = -30;

        [Range(20, 45)]
        [Tooltip("maxAngleCamera")]
        public int MaxLookAngle = 35;

        [Tooltip("invertCamera")]
        public bool invertCamera;
    }
}
