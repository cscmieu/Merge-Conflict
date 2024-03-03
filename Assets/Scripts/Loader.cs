using System.Collections;
using System.Collections.Generic;
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

        // test with numpad up to 9
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            setCurrentVersion(0);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            setCurrentVersion(1);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            setCurrentVersion(2);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            setCurrentVersion(3);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            setCurrentVersion(4);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            setCurrentVersion(5);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            setCurrentVersion(6);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            setCurrentVersion(7);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            setCurrentVersion(8);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            setCurrentVersion(9);
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
        UnloadPlayer(lastVersion);

        // Load map and player
        maps[versionIndex].SetActive(true);
        players[versionIndex].SetActive(true);
        switch (versionIndex)
        {
            case 7:
                ItemManager.cannotMove = false;
                break;
            case 26:
                LoadSkybox(1);
                break;
            case 27:
                LoadSkybox(2);
                break;
            case 28:
                LoadSkybox(3);
                Application.targetFrameRate = 10;
                break;
            default:
                LoadSkybox(0);
                Application.targetFrameRate = -1;
                break;
        }
    }

    private void UnloadMap(int mapIndex)
    {
        if (mapIndex < 0 || mapIndex > maxVersion) return;

        // Unload the map
        maps[mapIndex].SetActive(false);
    }

    private void UnloadPlayer(int playerIndex)
    {
        if (playerIndex < 0 || playerIndex > maxVersion) return;

        // Unload the player
        players[playerIndex].SetActive(false);
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
            Debug.Log("Music already playing");
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
