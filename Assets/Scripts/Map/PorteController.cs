using System.Collections;
using UnityEngine;

namespace Map
{
    public class PorteController : MonoBehaviour
    {
        private float   _tempsDeDeplacement = 2f;

        private void OnTriggerEnter(Collider other)
        {
            if (!ItemManager.hasKey) return;
            StartCoroutine(MoveUp());
        }

        private IEnumerator MoveUp()
        {
            var position    = transform.position;
            var destination = position + Vector3.up * (position.y * 1.5f);
            var elapsedTime = 0f;

            while (elapsedTime < _tempsDeDeplacement)
            {
                transform.position =  Vector3.Lerp(position, destination, elapsedTime / _tempsDeDeplacement);
                elapsedTime        += Time.deltaTime;
                yield return null;
            }
            // Assurer que la position finale est atteinte exactement
            transform.position = destination;
        }
    }
}
