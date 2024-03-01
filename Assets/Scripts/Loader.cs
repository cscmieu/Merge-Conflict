using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    [Header("Objects to load")]
    [SerializeField] private List<GameObject> maps;
    [SerializeField] private List<GameObject> players;

    [Header("Settings")]
    [SerializeField] private int startMap = 0;
    [SerializeField] private int startPlayer = 0;


    private int currentMap = 0;
    private int currentPlayer = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject map in maps)
        {
            map.SetActive(false);
        }

        if (maps[startMap].activeSelf == false)
        {
            LoadMap(startMap);
        }



        foreach (GameObject player in players)
        {
            player.SetActive(false);
        }

        if (players[startPlayer].activeSelf == false)
        {
            LoadPlayer(startPlayer);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void LoadMap(int mapIndex)
    {
        // Unload the current map
        UnloadMap(currentMap);

        // Load the map
        maps[mapIndex].SetActive(true);

        currentMap = mapIndex;
    }

    private void UnloadMap(int mapIndex)
    {
        // Unload the map
        maps[mapIndex].SetActive(false);
    }




    private void LoadPlayer(int playerIndex)
    {
        // Unload the current player
        UnloadPlayer(currentPlayer);

        // Load the player
        players[playerIndex].SetActive(true);

        currentPlayer = playerIndex;
    }

    private void UnloadPlayer(int playerIndex)
    {
        // Unload the player
        players[playerIndex].SetActive(false);
    }
}
