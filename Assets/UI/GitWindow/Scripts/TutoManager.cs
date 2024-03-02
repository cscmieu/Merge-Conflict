using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoManager : MonoBehaviour
{
    [Header("Tuto scenes")]
    [SerializeField] private List<GameObject> tutoScenes;


    private bool isTutoActive = true;

    // Start is called before the first frame update
    void Start()
    {
        if (isTutoActive)
        {
            tutoScenes[0].SetActive(true);
            isTutoActive = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && tutoScenes[0].activeSelf)
        {
            NextTuto1();
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && tutoScenes[1].activeSelf)
        {
            NextTuto2();
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && tutoScenes[2].activeSelf)
        {
            tutoScenes[2].SetActive(false);
        }
    }

    private void NextTuto1()
    {
        tutoScenes[0].SetActive(false);
        tutoScenes[1].SetActive(true);
    }
    private void NextTuto2()
    {
        tutoScenes[1].SetActive(false);
        tutoScenes[2].SetActive(true);
    }
}
