using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    [Header("Objects to load")]
    [SerializeField] private List<GameObject> maps;
    [SerializeField] private List<GameObject> players;

    [Header("Settings")]
    [SerializeField] private int startVersion = 0;

    public static int currentVersion = 0;

    private int lastVersion = -1;
    private int maxVersion;

    private void Awake() 
    {
        if (maps.Count != players.Count)
        {
            Debug.LogError("Maps and players lists must have the same size");
        }

        // constant definition
        maxVersion = maps.Count - 1;

        currentVersion = startVersion;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        // unload all maps and players and init the start version

        foreach (GameObject map in maps)
        {
            map.SetActive(false);
        }

        foreach (GameObject player in players)
        {
            player.SetActive(false);
        }

        if (maps[currentVersion].activeSelf == false && players[currentVersion].activeSelf == false)
        {
            LoadMapAndPLayer(currentVersion);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentVersion != lastVersion)
        {
            LoadMapAndPLayer(currentVersion);
            lastVersion = currentVersion;
        }

    }

    public static void setCurrentVersion(int versionIndex)
    {
        currentVersion = versionIndex;
    }


    private void LoadMapAndPLayer(int versionIndex)
    {
        //verfiy if the versionIndex is valid
        if (versionIndex < 0 || versionIndex > maxVersion)
        {
            Debug.LogError("Invalid version index");
            return;
        }

        // Unload current map and current player
        UnloadMap(currentVersion);
        UnloadPlayer(currentVersion);

        // Load map and player
        maps[versionIndex].SetActive(true);
        players[versionIndex].SetActive(true);

        currentVersion = versionIndex;
    }

    private void UnloadMap(int mapIndex)
    {
        // Unload the map
        maps[mapIndex].SetActive(false);
    }

    private void UnloadPlayer(int playerIndex)
    {
        // Unload the player
        players[playerIndex].SetActive(false);
    }
}
