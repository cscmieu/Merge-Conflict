using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public int Speed = 20;
    private CharacterController _characterController;

    public float RotateSpeed = 5.0f; // Vitesse de rotation de la caméra

    private float _rotationX = 0.0f;
    private float _rotationY = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Cursor.visible = false; // Masque le curseur de la souris

        _characterController = GetComponent<CharacterController>();
        if ( _characterController == null ) Debug.Log("il n'y a pas de character controller sur " + name);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
    }

    void Move()
    {
        var dirVertical = Input.GetAxis("Vertical");
        var dirHorizontal = Input.GetAxis("Horizontal");

        var dirVect = Vector3.forward * dirVertical + Vector3.right * dirHorizontal;
        _characterController.Move(dirVect * Speed * Time.deltaTime);
    }

    void Rotate()
    {
        _rotationX += Input.GetAxis("Mouse X") * RotateSpeed;
        _rotationY -= Input.GetAxis("Mouse Y") * RotateSpeed;

        // Limite la rotation de la caméra sur l'axe Y pour éviter les retournements excessifs
        _rotationY = Mathf.Clamp(_rotationY, -90.0f, 90.0f);

        // Applique la rotation à la caméra
        transform.rotation = Quaternion.Euler(_rotationY, _rotationX, 0);

    }
}
