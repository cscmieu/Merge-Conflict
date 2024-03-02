using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PorteController : MonoBehaviour
{
    private Vector3 position = Vector3.zero;
    private float _tempsDeDeplacement = 2f;

    void Start()
    {
        position = transform.position;
    }
    void OnTriggerEnter()
    {
        StartCoroutine(MoveUp());
    }

/*    void OnTriggerExit()
    {
        StartCoroutine(MoveDown());
    }*/
    IEnumerator MoveUp()
    {
        var destination = transform.position + Vector3.up*transform.position.y* 1.5f;
        float elapsedTime = 0f;
        Vector3 positionInitiale = transform.position;

        while (elapsedTime < _tempsDeDeplacement)
        {
            transform.position = Vector3.Lerp(positionInitiale, destination, elapsedTime / _tempsDeDeplacement);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        // Assurer que la position finale est atteinte exactement
        transform.position = destination;
        elapsedTime = 0f;
    }

/*    IEnumerator MoveDown()
    {
        var destination = position;
        float elapsedTime = 0f;
        Vector3 positionInitiale = transform.position;

        while (elapsedTime < _tempsDeDeplacement)
        {
            transform.position = Vector3.Lerp(positionInitiale, destination, elapsedTime / _tempsDeDeplacement);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        // Assurer que la position finale est atteinte exactement
        transform.position = destination;
        elapsedTime = 0f;
    }*/
}
