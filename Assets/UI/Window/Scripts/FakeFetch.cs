using System.Collections;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI.Window.Scripts
{
    public class FakeFetch : MonoBehaviour
    {
        [SerializeField] private TMP_Text smallText;
        [SerializeField]   private TMP_Text bigText;

        
        
        public void DoTheThing()
        {
            StopAllCoroutines();
            StartCoroutine(FetchCoroutine());
        }
        
        private IEnumerator FetchCoroutine()
        {
            smallText.text = "Hang on ...";
            bigText.text   = "Fetching Origin";
            yield return new WaitForSeconds(1f);
            smallText.text = "Already up to date";
            bigText.text   = "Fetch Origin";
            yield return null;
        }
    }
}
