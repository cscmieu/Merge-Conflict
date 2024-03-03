using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GitActivate : MonoBehaviour
{
     [SerializeField] private GameObject gitPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            OpenGitPanel();
        }
    }


    public void CloseGitPanel()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        gitPanel.SetActive(false);
    }

    private void OpenGitPanel()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        gitPanel.SetActive(true);
    }
}
