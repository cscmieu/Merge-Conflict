using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
public class RandomForce : MonoBehaviour
{
    public float forceMagnitude = 10f;
    public float forceInterval = 1f;
    private Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Call the StartCoroutine method to apply a random force to the object's Rigidbody every "forceInterval" seconds
        StartCoroutine(ApplyRandomForce());
        
    }

    IEnumerator ApplyRandomForce()
    {
        while (true)
        {
            // Generate a random direction vector
            Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));

            // Normalize the vector to ensure consistent force magnitude
            randomDirection.Normalize();

            // Add a force to the object's Rigidbody in the random direction
            rb.velocity = Vector3.zero;
            rb.AddForce(randomDirection * forceMagnitude, ForceMode.Impulse);

            // Wait for "forceInterval" seconds before applying the next random force
            yield return new WaitForSeconds(forceInterval);
        }
    }
}