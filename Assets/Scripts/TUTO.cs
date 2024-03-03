using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TUTO : MonoBehaviour
{
    [SerializeField] private GameObject tutoPanel;

    private bool hasBeenActivated = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            tutoPanel.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (hasBeenActivated)
        {
            return;
        }

        tutoPanel.SetActive(true);

        hasBeenActivated = true;
    }
}
