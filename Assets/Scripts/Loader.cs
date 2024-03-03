using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Loader : MonoBehaviour
{
    [Header("Objects to load")]
    [SerializeField] private List<GameObject> maps;
    [SerializeField] private List<GameObject> players;
    [SerializeField] private List<Material>   skyboxes;

    [Header("Music and their versions")]
    [SerializeField] private List<AudioSource> musics;
    [SerializeField] private List<int> music1Versions;
    [SerializeField] private List<int> music2Versions;
    [SerializeField] private List<int> music3Versions;

    [Header("Settings")]
    [SerializeField] private int startVersion;

    private Dictionary<int, AudioSource> musicDatabase = new();
    private List<List<int>>              musicVersions = new();

    public static int currentVersion;
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

        currentVersion = startVersion - 1;
        
    }

    // Start is called before the first frame update
    private void Start()
    {
        //load the musicVersions in the musicVersions list
        musicVersions.Add(music1Versions);
        musicVersions.Add(music2Versions);
        musicVersions.Add(music3Versions);

        if (musicVersions.Count != musics.Count)
        {
            Debug.LogError("musicVersions and musics list must have the same size");
        }

        // load the musicDatabase dictionary
        foreach (var musicXVersion in musicVersions)
        {
            foreach (var version in musicXVersion)
            {
                musicDatabase.Add(version, musics[musicVersions.IndexOf(musicXVersion)]);
            }
        }

        if (musicDatabase.Count != maxVersion + 1)
        {
            Debug.LogError("Music database is too large ou too small");
        }

        
        // unload all maps and players and init the start version
        foreach (var map in maps)
        {
            map.SetActive(false);
        }

        foreach (var player in players)
        {
            player.SetActive(false);
        }

        if (maps[currentVersion].activeSelf == false && players[currentVersion].activeSelf == false)
        {
            LoadMapAndPLayer(currentVersion);
        }

        // Mute all the music
        foreach (var music in musics)
        {
            music.mute = true;
        }

        // Unmute the music of the start version
        ChangeMusic(currentVersion);
    }

    // Update is called once per frame
    private void Update()
    {
        if (currentVersion != lastVersion)
        {
            LoadMapAndPLayer(currentVersion);
            ChangeMusic(currentVersion);
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
        UnloadMap(lastVersion);
        UnloadPlayer();

        // Load map and player
        maps[versionIndex].SetActive(true);
        players[versionIndex].SetActive(true);

        Application.targetFrameRate = -1;
        LoadSkybox(0);
        switch (versionIndex)
        {
            case 6:
                ItemManager.cannotMove = false;
                break;
            case 10:
                ItemManager.cannotMove = true;
                break;
            case 25:
                LoadSkybox(1);
                break;
            case 26:
                LoadSkybox(2);
                break;
            case 27:
                LoadSkybox(3);
                Application.targetFrameRate = 10;
                break;
            default:
                if (lastVersion == 10)
                {
                    ItemManager.cannotMove = false;
                }
                break;
        }
    }

    private void UnloadMap(int mapIndex)
    {
        if (mapIndex < 0 || mapIndex > maxVersion) return;

        // Unload the map
        maps[mapIndex].SetActive(false);
    }

    private void UnloadPlayer()
    {

        // Unload the player
        foreach (var player in players)
        {
            player.SetActive(false);
        }
    }

    private void ChangeMusic(int versionIndex)
    {

        // verify if the versionIndex is valid
        if (versionIndex < 0 || versionIndex > maxVersion)
        {
            Debug.LogError("Invalid version index");
            return;
        }

        // verify if the music is already playing
        if (!musicDatabase[versionIndex].mute)
        {
            return;
        }

        // mute the current music
        foreach (var music in musics)
        {
            music.mute = true;
        }

        // unmute the music we want to play
        musicDatabase[versionIndex].mute = false;
    }
    
    private void LoadSkybox(int skyboxIndex)
    {
        RenderSettings.skybox = skyboxes[skyboxIndex];
    }
}
