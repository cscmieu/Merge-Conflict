using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TUTO : MonoBehaviour
{
    [SerializeField] private GameObject tutoPanel;

    private bool hasBeenActivated = false;

    private bool IsIn = false;

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





        if (Input.GetKeyDown(KeyCode.Space) && !hasBeenActivated && IsIn)
            {
                tutoPanel.SetActive(true);

                hasBeenActivated = true;
            }
    }

    private void OnTriggerEnter(Collider other) 
    {

        if (other.gameObject.layer == 7)
        {
            IsIn = true;
        }
        
    }

    private void OnTriggerExit(Collider other) 
    {

        if (other.gameObject.layer == 7)
        {
            IsIn = false;
        }
        
    }
}
