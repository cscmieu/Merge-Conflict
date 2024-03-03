using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporter : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject destination;
    [SerializeField] private GameObject backDestination;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            teleport();
        }

        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            teleportBack();
        }
    }

    private void teleport()
    {
        backDestination.transform.position = player.transform.position;

        player.transform.position = destination.transform.position;
    }

    private void teleportBack()
    {
        player.transform.position = backDestination.transform.position;
    }
}
