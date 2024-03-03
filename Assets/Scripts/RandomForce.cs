using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
public class RandomForce : MonoBehaviour
{
    public float forceMagnitude = 10f;
    public float forceInterval = 1f;
    private Rigidbody _rb;


    private void Start()
    {
        var scaleDice = Random.Range(1, 5);
        transform.localScale = new Vector3(scaleDice,scaleDice ,scaleDice);
        _rb                  = GetComponent<Rigidbody>();
        // Call the StartCoroutine method to apply a random force to the object's Rigidbody every "forceInterval" seconds
        StartCoroutine(ApplyRandomForce());
        
    }

    private IEnumerator ApplyRandomForce()
    {
        while (true)
        {
            // Generate a random direction vector
            var randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));

            // Normalize the vector to ensure consistent force magnitude
            randomDirection.Normalize();

            // Add a force to the object's Rigidbody in the random direction
            _rb.velocity = Vector3.zero;
            _rb.AddForce(randomDirection * forceMagnitude, ForceMode.Impulse);

            // Wait for "forceInterval" seconds before applying the next random force
            yield return new WaitForSeconds(forceInterval);
        }
    }
}