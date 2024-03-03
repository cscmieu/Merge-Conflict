using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private List<GameObject> players;
    [SerializeField] private Transform destination;
    private Transform backDestination;
    
    // Update is called once per frame
    private void Update()
    {
    }

    public void teleport()
    {
        backDestination.position = players[Loader.currentVersion-1].transform.position;
        foreach (var player in players)
        {
            player.transform.position = destination.transform.position;
        }
    }

    public void teleportBack()
    {
        foreach (var player in players)
        {
            player.transform.position = backDestination.transform.position;
        }
    }
}
